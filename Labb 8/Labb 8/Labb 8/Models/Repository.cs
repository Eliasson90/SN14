using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Xml.Linq;

namespace Labb_8.Models
{
    public class Repository : Labb_8.Models.IRepository
    {
        private static readonly string PhysicalPath;
        private XDocument _document;

        private XDocument Document
        {

            get
            {
                // Lazy load
                return _document ?? (_document = XDocument.Load(PhysicalPath));
            }
        }

        static Repository()
        {
            var dataDir = AppDomain.CurrentDomain.GetData("DataDirectory");
            PhysicalPath = Path.Combine(dataDir.ToString(), "contacts.Xml");
        }

        public List<Contact> GetAllContacts()
        {

            var contact = Document.Descendants("Contact")
                .Select(element => new Contact
                {
                    ContactId = Guid.Parse(element.Element("Id").Value),
                    FirstName = element.Element("FirstName").Value,
                    LastName = element.Element("LastName").Value,
                    Email = element.Element("Email").Value,
                    Datum = DateTime.Parse(element.Element("Datum").Value),

                })
                .OrderByDescending(x => x.Datum)
                .ToList();

            return contact;

        }
        public Contact GetContactById(Guid id)
        {
            var contact = Document.Descendants("Contact")
                .Where(element => Guid.Parse(element.Element("Id").Value) == id)
                 .Select(element => new Contact
                 {
                     ContactId = Guid.Parse(element.Element("Id").Value),
                     FirstName = element.Element("FirstName").Value,
                     LastName = element.Element("LastName").Value,
                     Email = element.Element("Email").Value,
                     Datum = DateTime.Parse(element.Element("Datum").Value),

                 })
                 .FirstOrDefault();

            return contact;
        }

        public void Add(Contact contact)
        {

            var element = new XElement("Contact",
                new XElement("Id", contact.ContactId.ToString()),
                new XElement("FirstName", contact.FirstName),
                new XElement("LastName", contact.LastName),
                new XElement("Email", contact.Email),
                new XElement("Datum", contact.Datum.ToShortDateString())
                );


            Document.Root.Add(element);

        }

        public void Update(Contact contact)
        {
            if (contact == null)
            {
                throw new ArgumentNullException("contact");
            }

            var element = Document.Descendants("Contact")
                .Where(el => Guid.Parse(el.Element("Id").Value) == contact.ContactId)
                 .FirstOrDefault();

            if (element != null)
            {
                element.Element("FirstName").Value = contact.FirstName;
                element.Element("LastName").Value = contact.LastName;
                element.Element("Email").Value = contact.Email;

            }
        }

        public void Delete(Contact contact)
        {
            var elementToDelete = Document.Descendants("Contact")
                .Where(element => Guid.Parse(element.Element("Id").Value) == contact.ContactId)
                .FirstOrDefault();

            if (elementToDelete != null)
            {
                elementToDelete.Remove();
            }
        }

        public void Save()
        {
            Document.Save(PhysicalPath);
        }
    }
}