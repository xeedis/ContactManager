namespace API.Entities
{
    public class CategoryType
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Contact> AlignedContact { get; set; }
        public int? SubcategoryId { get; set; }
        public SubcategoryType Subcategory { get; set; }
    }
}
