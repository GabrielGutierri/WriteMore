using Microsoft.AspNetCore.Identity;
using WriteMore.Application.Interfaces.Services;
using WriteMore.Data.Context;
using WriteMore.Data.Repository;
using WriteMore.Domain.Interfaces.Repository;
using WriteMore.Domain.Interfaces.Services;
using WriteMore.Domain.Models;
using WriteMore.Domain.Services;
using WriteMore.Identity.Data;
using WriteMore.Identity.Services;

namespace WriteMore.API.Extensions
{
    public static class APIServicesSetup
    {
        public static void AddAPIServices(this IServiceCollection services)
        {
            services.AddScoped<IIdentityService, IdentityService>();
            services.AddScoped<IService<Book>, BookService>();
            services.AddScoped<IService<Movie>, MovieService>();
            services.AddScoped<IRepository<Book>, BookRepository>();
            services.AddScoped<IRepository<Movie>, MovieRepository>();
        }

        public static void AddContext(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddSqlServer<WriteMoreContext>(configuration.GetConnectionString("DefaultConnection"));
            services.AddSqlServer<IdentityDataContext>(configuration.GetConnectionString("DefaultConnection"));

            services.AddDefaultIdentity<IdentityUser>()
                .AddRoles<IdentityRole>()
                .AddEntityFrameworkStores<IdentityDataContext>()
                .AddDefaultTokenProviders();

        }
    }
}
