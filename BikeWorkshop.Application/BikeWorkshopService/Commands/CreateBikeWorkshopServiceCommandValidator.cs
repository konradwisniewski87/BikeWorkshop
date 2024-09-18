using FluentValidation;

namespace BikeWorkshop.Application.BikeWorkshopService.Commands
{
    public class CreateBikeWorkshopServiceCommandValidator : AbstractValidator<CreateBikeWorkshopServiceCommand>
    {
        public CreateBikeWorkshopServiceCommandValidator()
        {
            RuleFor(r => r.Cost).NotEmpty().NotNull();
            RuleFor(r => r.Description).NotEmpty().NotNull();
            RuleFor(r => r.BikeWorkshopEncodedName).NotEmpty().NotNull();
        }
    }
}
