using BikeWorkshop.Application.Mappings;
using BikeWorkshop.Application.Services;
using Microsoft.Extensions.DependencyInjection;

namespace BikeWorkshop.Application.Extensions
{
    public static class ServiceCollectionExtension
    {
        public static void AddApplication(this IServiceCollection services)
        {
            services.AddScoped<IBikeWorkshopService, BikeWorkshopService>();

            services.AddAutoMapper(typeof(BikeWorkshopMappingProfile));
        }
    }
}
