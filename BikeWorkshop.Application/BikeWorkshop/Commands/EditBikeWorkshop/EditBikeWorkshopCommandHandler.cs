using AutoMapper;
using BikeWorkshop.Application.ApplicationUser;
using BikeWorkshop.Application.BikeWorkshop.Commands.CreateBikeWorkshop;
using BikeWorkshop.Domain.Interfaces;
using MediatR;

namespace BikeWorkshop.Application.BikeWorkshop.Commands.EditBikeWorkshop
{
    public class EditBikeWorkshopCommandHandler : IRequest<EditBikeWorkshopCommand>
    {
        private readonly IBikeWorkshopRepository _bikeWorkshopRepository;
        private readonly IUserContext _userContext;

        public EditBikeWorkshopCommandHandler(IBikeWorkshopRepository bikeWorkshopRepository, IUserContext userContext)
        {
            _bikeWorkshopRepository = bikeWorkshopRepository;
            _userContext = userContext;
        }

        public async Task<Unit> Handle(EditBikeWorkshopCommand request, CancellationToken cancellationToken)
        {
            var bikeWorkshop = await _bikeWorkshopRepository.GetByEncodedName(request.EncodedName!);

            var user = _userContext.GetCurrentUser();
            var isEditable = user != null && bikeWorkshop != null && bikeWorkshop.CreatedById == user.Id;
            if(!isEditable)
            {
                return Unit.Value;
            }

            bikeWorkshop.Description = request.Description;
            bikeWorkshop.About = request.About;

            bikeWorkshop.ContactDetails.PhoneNumber = request.PhoneNumber;
            bikeWorkshop.ContactDetails.Street      = request.Street;
            bikeWorkshop.ContactDetails.City        = request.City;
            bikeWorkshop.ContactDetails.PostalCode  = request.PostalCode;

            await _bikeWorkshopRepository.Commit();

            return Unit.Value;
        }
    }
}
