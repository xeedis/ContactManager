using API.DTOs;
using API.Entities;

namespace API.Interfaces
{
    public interface IContactsRepository
    {
        Task<List<Contact>> GetConactsAsync();
        Task<Contact> GetContactByName(string name);
        void AddContact(Contact contact);
        void DeleteContact(Contact contact);
        void Update(Contact contact);
        Task<bool> SaveAllAsync();

    }
}
