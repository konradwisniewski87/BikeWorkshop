using AutoMapper;
using BikeWorkshop.Application.BikeWorkshop.Queries.GetAllBikeWorkshop;
using BikeWorkshop.Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BikeWorkshop.Application.BikeWorkshop.Queries.GetBikeWorkshopByEncodedName
{
	public class GetBikeWorkshopByEncodedNameQueryHandler : IRequestHandler<GetBikeWorkshopByEncodedNameQuery, BikeWorkshopDto>
	{
		private readonly IBikeWorkshopRepository _bikeWorkshopRepository;
		private readonly IMapper _mapper;

		public GetBikeWorkshopByEncodedNameQueryHandler(IBikeWorkshopRepository bikeWorkshopRepository, IMapper mapper)
        {
			_bikeWorkshopRepository = bikeWorkshopRepository;
			_mapper = mapper;
		}

		public async Task<BikeWorkshopDto> Handle(GetBikeWorkshopByEncodedNameQuery request, CancellationToken cancellationToken)
		{
			var bikeWorkshop = await _bikeWorkshopRepository.GetByEncodedName(request.EncodedName);
			if (bikeWorkshop == null)
			{
				throw new InvalidOperationException("Context Workshop is not present");
			}
			var dto = _mapper.Map<BikeWorkshopDto>(bikeWorkshop);
			return dto;
		}
	}
}
