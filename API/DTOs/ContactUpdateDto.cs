using API.Entities;

namespace API.DTOs
{
    public class ContactUpdateDto
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public CategoryType Category { get; set; }
        public string Phone { get; set; }
        public string DateOfBirth { get; set; }
    }
}
