using API.Entities;

namespace API.Interfaces
{
    public interface ICategoryReporistory
    {
        Task<List<CategoryType>> GetCategories();
        void Add(CategoryType categoryType);
        Task<bool> SaveAllAsync();
    }
}
