using Microsoft.JSInterop.Infrastructure;
using System;

namespace API.Entities
{
    public class Contact
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public int CategoryId { get; set; }
        public CategoryType Category { get; set; }
        public string Phone { get; set; }
        public DateTime BirthDate { get; set; }
    }
}