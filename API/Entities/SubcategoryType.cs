namespace API.Entities
{
    public class SubcategoryType
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public CategoryType Category { get; set; }
    }
}
