using BikeWorkshop.Application.ApplicationUser;
using BikeWorkshop.Application.BikeWorkshop.Commands.CreateBikeWorkshop;
using BikeWorkshop.Application.Mappings;
using FluentValidation;
using FluentValidation.AspNetCore;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace BikeWorkshop.Application.Extensions
{
	public static class ServiceCollectionExtension
    {
        public static void AddApplication(this IServiceCollection services)
        {
            services.AddScoped<IUserContext, UserContext>();
			services.AddMediatR(typeof(CreateBikeWorkshopCommand));

            services.AddAutoMapper(typeof(BikeWorkshopMappingProfile));

            services.AddValidatorsFromAssemblyContaining<CreateBikeWorkshopCommandValidator>()
                .AddFluentValidationAutoValidation()
                .AddFluentValidationClientsideAdapters();
        }
    }
}
