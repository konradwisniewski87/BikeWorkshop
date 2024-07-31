using BikeWorkshop.Domain.Interfaces;
using BikeWorkshop.Infrastructure.Persistence;
using BikeWorkshop.Infrastructure.Repositorys;
using BikeWorkshop.Infrastructure.Seeders;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BikeWorkshop.Infrastructure.Extensions
{
    public static class ServiceCollectionExtension
    {
        public static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            var _ConnectionStrings = configuration.GetConnectionString("BikeWorkshop");
            
            services.AddDbContext<BikeWorkshopDbContext>(
                options => options.UseSqlServer(_ConnectionStrings)
                );

            services.AddDefaultIdentity<IdentityUser>()
                .AddRoles<IdentityRole>()
                .AddEntityFrameworkStores<BikeWorkshopDbContext>();

            services.AddScoped<BikeWorkshopSeeder>();

            services.AddScoped<IBikeWorkshopRepository, BikeWorkshopRepository>();
        }
    }
}
