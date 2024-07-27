using AutoMapper;
using BikeWorkshop.Application.BikeWorkshop;
using BikeWorkshop.Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BikeWorkshop.Application.BikeWorkshop.Queries.GetAllBikeWorkshop
{
	public class GetAllBikeWorkshopQueryHandler : IRequestHandler<GetAllBikeWorkshopQuery, IEnumerable<BikeWorkshopDto>>
	{
		private readonly IBikeWorkshopRepository _bikeWorkshopRepository;
		private readonly IMapper _mapper;

		public GetAllBikeWorkshopQueryHandler(IBikeWorkshopRepository bikeWorkshopRepository, IMapper mapper)
        {
			_bikeWorkshopRepository = bikeWorkshopRepository;
			_mapper = mapper;
		}
		public IBikeWorkshopRepository CarWorkshopRepository { get; }

		public async Task<IEnumerable<BikeWorkshopDto>> Handle(GetAllBikeWorkshopQuery request, CancellationToken cancellationToken)
		{
			var bikeWorkshop = await _bikeWorkshopRepository.GetAll();
			var bikeWorkshopDto = _mapper.Map<IEnumerable<BikeWorkshopDto>>(bikeWorkshop);
			return bikeWorkshopDto;
		}
	}
}