using BikeWorkshop.Application.ApplicationUser;
using BikeWorkshop.Domain.Interfaces;
using MediatR;

namespace BikeWorkshop.Application.BikeWorkshopService.Commands
{
    public class CreateBikeWorkshopServiceCommandHandler : IRequestHandler<CreateBikeWorkshopServiceCommand>
    {
        private readonly IUserContext _userContext;
        private readonly IBikeWorkshopRepository _bikeWorkshopRepository;
        private readonly IBikeWorkshopServiceRepository _bikeWorkshopServiceRepository;

        public CreateBikeWorkshopServiceCommandHandler(IUserContext userContext, IBikeWorkshopRepository bikeWorkshopRepository, IBikeWorkshopServiceRepository bikeWorkshopServiceRepository)
        {
            _userContext = userContext;
            _bikeWorkshopRepository = bikeWorkshopRepository;
            _bikeWorkshopServiceRepository = bikeWorkshopServiceRepository;
        }

        public async Task<Unit> Handle(CreateBikeWorkshopServiceCommand request, CancellationToken cancellationToken)
        {
            var bikeWorkshop = await _bikeWorkshopRepository.GetByEncodedName(request.BikeWorkshopEncodedName!);
            var user = _userContext.GetCurrentUser();
            var isEditable = user != null && (bikeWorkshop.CreatedById == user.Id || user.IsInRole("Admin"));

            if (isEditable)
            {
                return Unit.Value;
            }

            var bikeWorkshopService = new Domain.Entities.BikeWorkshopService()
            {
                Cost = request.Cost,
                Description = request.Description,
                BikeWorkshopId = bikeWorkshop.Id,
            };

            await _bikeWorkshopServiceRepository.Create(bikeWorkshopService);
            return Unit.Value;
        }
    }
}
