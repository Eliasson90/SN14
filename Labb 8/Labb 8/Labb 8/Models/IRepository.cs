using System;
using System.Collections.Generic;
namespace Labb_8.Models
{
    public interface IRepository
    {
        void Add(Contact contact);
        void Delete(Contact contact);
        List<Contact> GetAllContacts();
        Contact GetContactById(Guid id);
        void Update(Contact contact);
        void Save();
    }
}
