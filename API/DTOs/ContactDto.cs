using API.Entities;

namespace API.DTOs
{
    public class ContactDto
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public int CategoryId { get; set; }
        public CategoryTypeDto Category { get; set; }
        public string Phone { get; set; }
        public DateTime BirthDate { get; set; }
    }
}
