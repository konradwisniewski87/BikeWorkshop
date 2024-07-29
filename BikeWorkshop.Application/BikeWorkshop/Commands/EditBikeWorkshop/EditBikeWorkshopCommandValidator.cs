using FluentValidation;

namespace BikeWorkshop.Application.BikeWorkshop.Commands.EditBikeWorkshop
{
    public class EditBikeWorkshopCommandValidator : AbstractValidator<EditBikeWorkshopCommand>
    {
        public EditBikeWorkshopCommandValidator()
        {
            RuleFor(w => w.Description)
                .NotEmpty().WithMessage("Bike Workshop should have description");

            RuleFor(w => w.PhoneNumber)
                .MinimumLength(7)
                .MaximumLength(12);
        }
    }
}
