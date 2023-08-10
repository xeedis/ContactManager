using API.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.JSInterop.Infrastructure;

namespace API.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options): base(options) 
        {
            
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<CategoryType> Category { get; set; }
        public DbSet<SubcategoryType> Subcategory { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

        }
    }
}
