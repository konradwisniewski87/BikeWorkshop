using BikeWorkshop.Application.Mappings;
using BikeWorkshop.Application.Services;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.Extensions.DependencyInjection;

namespace BikeWorkshop.Application.Extensions
{
    public static class ServiceCollectionExtension
    {
        public static void AddApplication(this IServiceCollection services)
        {
            services.AddScoped<IBikeWorkshopService, BikeWorkshopService>();

            services.AddAutoMapper(typeof(BikeWorkshopMappingProfile));

            services.AddValidatorsFromAssemblyContaining<BikeWorkshopDtoValidator>()
                .AddFluentValidationAutoValidation()
                .AddFluentValidationClientsideAdapters();
        }
    }
}
