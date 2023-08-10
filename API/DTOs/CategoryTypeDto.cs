namespace API.DTOs
{
    public class CategoryTypeDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public SubcategoryDto Subcategory { get; set; }
    }
}
