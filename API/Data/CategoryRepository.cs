using API.Entities;
using API.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace API.Data
{
    public class CategoryRepository:ICategoryReporistory
    {
        private readonly DataContext _context;
        public CategoryRepository(DataContext context)
        {
            _context = context;
        }

        public void Add(CategoryType categoryType)
        {
            _context.Category.Add(categoryType);
        }

        public async Task<List<CategoryType>> GetCategories()
        {
            return await _context.Category.ToListAsync();
        }

        public async Task<bool> SaveAllAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }
    }
}
