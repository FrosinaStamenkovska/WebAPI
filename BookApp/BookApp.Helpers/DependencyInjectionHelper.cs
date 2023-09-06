using BookApp.DataAccess;
using BookApp.DataAccess.Implementation;
using BookApp.Domain;
using BookApp.Services.Implementation;
using BookApp.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BookApp.Helpers
{
    public static class DependencyInjectionHelper
    {
        public static void InjectDbContext(IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<BookAppDbContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("Default"));
            });
        }

        public static void InjectRepositories(IServiceCollection services)
        {
            services.AddTransient<IRepository<Book>, BookRepository>();
            // services.AddTransient<IRepository<Book>, BookAdoRepository>();
        }

        public static void InjectServices(IServiceCollection services)
        {
            services.AddTransient<IBookService, BookService>();
        }
    }
}