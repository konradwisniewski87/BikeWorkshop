using BikeWorkshop.Application.BikeWorkshop;
using BikeWorkshop.Domain.Interfaces;
using FluentValidation;

namespace BikeWorkshop.Application
{
    public class BikeWorkshopDtoValidator : AbstractValidator<BikeWorkshopDto>
    {
        private readonly int MinimumLengthOfName = 2;
        private readonly int MaximumLengthOfName = 20;


        public BikeWorkshopDtoValidator(IBikeWorkshopRepository repository)
        {
            RuleFor( w => w.Name )
                .NotEmpty()
                .MinimumLength(MinimumLengthOfName).WithMessage($"Name should have atleast {MinimumLengthOfName} characters")
                .MaximumLength(MaximumLengthOfName).WithMessage($"Name should have maximum {MaximumLengthOfName} characters")
                .Custom((value, context) =>
                {
                    var existingBikeWorkshop = repository.GetByName(value).Result;
                    if (existingBikeWorkshop != null)
                    {
                        context.AddFailure($"{value} exist in database");
                    }
                });

            RuleFor(w => w.Description)
                .NotEmpty().WithMessage("Bike Workshop should have description");

            RuleFor(w => w.PhoneNumber)
                .MinimumLength(7)
                .MaximumLength(12);
        }
    }
}
