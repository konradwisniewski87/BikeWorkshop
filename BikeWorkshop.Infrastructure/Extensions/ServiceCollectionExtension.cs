using BikeWorkshop.Infrastructure.Persistence;
using BikeWorkshop.Infrastructure.Seeders;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

            services.AddScoped<BikeWorkshopSeeder>();
        }
    }
}
