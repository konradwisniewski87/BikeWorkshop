using AutoMapper;
using BikeWorkshop.Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BikeWorkshop.Application.BikeWorkshop.Commands.CreateBikeWorkshop
{
	public class CreateBikeWorkshopCommandHandler : IRequestHandler<CreateBikeWorkshopCommand>
	{
		private readonly IBikeWorkshopRepository _bikeWorkshopRepository;
		private readonly IMapper _mapper;

		public CreateBikeWorkshopCommandHandler(IBikeWorkshopRepository bikeWorkshopRepository, IMapper mapper)
        {
			_bikeWorkshopRepository = bikeWorkshopRepository;
			_mapper = mapper;
		}
        public async Task<Unit> Handle(CreateBikeWorkshopCommand request, CancellationToken cancellationToken)
		{
			var bikeWorkshop = _mapper.Map<Domain.Entities.BikeWorkshop>(request);
			bikeWorkshop.EncodName();
			await _bikeWorkshopRepository.Create(bikeWorkshop);
			return Unit.Value;
		}
	}
}
