using API.Data;
using API.Interfaces;
using API.Services;
using Microsoft.EntityFrameworkCore;
using API.Helpers;

namespace API.Extensions
{
    public static class ApplicationServiceExtension
    {
        public static IServiceCollection AddAplicationServices(this IServiceCollection services, IConfiguration config) 
        {
            services.AddControllers();
            services.AddDbContext<DataContext>(opt =>
            {
                opt.UseSqlServer(config.GetConnectionString("DefaultConnection"));
            });
            services.AddCors();
            services.AddAutoMapper(typeof(AutoMapperProfiles).Assembly);
            services.AddScoped<ITokenService, TokenService>();
            services.AddScoped<IContactsRepository, ContactsRepository>();
            services.AddScoped<ICategoryReporistory, CategoryRepository>();

            return services;
        } 
    }
}
