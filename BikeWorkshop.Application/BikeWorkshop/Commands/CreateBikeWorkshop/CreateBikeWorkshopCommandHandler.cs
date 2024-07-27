using AutoMapper;
using BikeWorkshop.Application.ApplicationUser;
using BikeWorkshop.Domain.Interfaces;
using MediatR;

namespace BikeWorkshop.Application.BikeWorkshop.Commands.CreateBikeWorkshop
{
	public class CreateBikeWorkshopCommandHandler : IRequestHandler<CreateBikeWorkshopCommand>
	{
		private readonly IBikeWorkshopRepository _bikeWorkshopRepository;
		private readonly IMapper _mapper;
		private readonly IUserContext _userContext;

		public CreateBikeWorkshopCommandHandler(IBikeWorkshopRepository bikeWorkshopRepository, IMapper mapper, IUserContext userContext)
        {
			_bikeWorkshopRepository = bikeWorkshopRepository;
			_mapper = mapper;
			_userContext = userContext;
		}
        public async Task<Unit> Handle(CreateBikeWorkshopCommand request, CancellationToken cancellationToken)
		{
			var bikeWorkshop = _mapper.Map<Domain.Entities.BikeWorkshop>(request);
			bikeWorkshop.EncodName();
			bikeWorkshop.CreatedById = _userContext.GetCurrentUser().Id;
			await _bikeWorkshopRepository.Create(bikeWorkshop);
			return Unit.Value;
		}
	}
}
