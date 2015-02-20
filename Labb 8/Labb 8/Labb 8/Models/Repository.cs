using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Linq;

namespace Labb_8.Models
{
    public class Repository
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

        public List<Contact> GetALContacts()
        {
          
            var contact = Document.Descendants("Contact")
                .Select(element => new Contact
                {
                    ContactId = Guid.Parse(element.Attribute("Id").Value),
                    FirstName = element.Element("FirstName").Value,
                    LastName = element.Element("LastName").Value,
                    Email = element.Element("Email").Value,
                })
                .OrderBy(x => x.Name)
                .ToList();

            return contact;

        }
        public Contact GetContactById(Guid id)
        {
            var contact = Document.Descendants("Contact")
                .Where(element => Guid.Parse(element.Attribute("Id").Value) == id)
                 .Select(element => new Contact
                 {
                     ContactId = Guid.Parse(element.Attribute("Id").Value),
                     FirstName = element.Element("FirstName").Value,
                     LastName = element.Element("LastName").Value,
                     Email = element.Element("Email").Value,
                 })
                 .FirstOrDefault();

            return contact;
        }

    //    public List<Contact> GetLastContacts([int count = 20])
    //{

    //}


        public void Add(Contact contact)
        {
          
            var element = new XElement("Contact",
                new XAttribute("Id", contact.ContactId.ToString()),
                new XElement("Förnamn", contact.FirstName),
                new XElement("Efternamn", contact.LastName),
                new XElement("Email", contact.Email),
                );


            Document.Root.Add(element);
            
        }

        public void Update(Contact contact)
        {
           if(contact == null)
           {
               throw new ArgumentNullException("contact");
           }

           var element = Document.Descendants("Contact")
               .Where(el => Guid.Parse(el.Attribute("Id").Value) == contact.Contactid)               
                .FirstOrDefault();

            if(element != null)
            {
                element.Element("Förnamn").Value = contact.FirstName;
                element.Element("Efternamn").Value = contact.LastName;
                element.Element("Email").Value = contact.Email;
            }
        }

        public void Delete(Contact contact)
        {
            var elementToDelete = Document.Descendants("Contact")
                .Where(element => Guid.Parse(element.Attribute("Id").Value) == contact.ContactId)
                .FirstOrDefault();

            if(elementToDelete != null)
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