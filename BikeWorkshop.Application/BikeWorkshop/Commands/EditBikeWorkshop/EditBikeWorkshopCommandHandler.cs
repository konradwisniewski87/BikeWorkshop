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
        private readonly IMapper _mapper;
        private readonly IUserContext _userContext;

        public EditBikeWorkshopCommandHandler(IBikeWorkshopRepository bikeWorkshopRepository, IMapper mapper, IUserContext userContext)
        {
            _bikeWorkshopRepository = bikeWorkshopRepository;
            _mapper = mapper;
            _userContext = userContext;
        }

        public async Task<Unit> Handle(EditBikeWorkshopCommand request, CancellationToken cancellationToken)
        {
            var bikeWorkshop = await _bikeWorkshopRepository.GetByEncodedName(request.EncodedName!);

            bikeWorkshop.Description = request.Description;
            bikeWorkshop.About = request.About;

            bikeWorkshop.ContactDetails.PhoneNumber = request.PhoneNumber;
            bikeWorkshop.ContactDetails.Street      = request.Street;
            bikeWorkshop.ContactDetails.City        = request.City;
            bikeWorkshop.ContactDetails.PostalCode  = request.PostalCode;

            await _bikeWorkshopRepository.Commit();

            //var bikeWorkshop = _mapper.Map<Domain.Entities.BikeWorkshop>(request);
            //bikeWorkshop.EncodName();
            //bikeWorkshop.CreatedById = _userContext.GetCurrentUser().Id;
            //await _bikeWorkshopRepository.Create(bikeWorkshop);
            return Unit.Value;
        }
    }
}
