using API.DTOs;
using API.Entities;
using API.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace API.Data
{
    public class ContactsRepository:IContactsRepository
    {
        private readonly DataContext _context;
        public ContactsRepository(DataContext context)
        {

            _context = context;

        }

        public void AddContact(Contact contact)
        {
            _context.Contacts.Add(contact);
        }

        public void DeleteContact(Contact contact)
        {
            _context.Contacts.Remove(contact);
        }

        public async Task<List<Contact>> GetConactsAsync()
        {
            return await _context.Contacts.ToListAsync();
        }

        public async Task<Contact> GetContactByName(string name)
        {
            var response = await _context.Contacts.Include(c => c.Category)
                .SingleOrDefaultAsync(c => c.FirstName == name);

            return response;
        }

        public async Task<bool> SaveAllAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }

        public void Update(Contact contact)
        {
            _context.Entry(contact).State = EntityState.Modified;
        }
    }
}
