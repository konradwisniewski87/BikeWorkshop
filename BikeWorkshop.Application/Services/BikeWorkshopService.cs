using AutoMapper;
using BikeWorkshop.Application.BikeWorkshop;
using BikeWorkshop.Domain.Interfaces;

namespace BikeWorkshop.Application.Services
{
    public class BikeWorkshopService : IBikeWorkshopService
    {
        private readonly IBikeWorkshopRepository _bikeWorkshop;
        private readonly IMapper _mapper;

        public BikeWorkshopService(IBikeWorkshopRepository bikeWorkshop, IMapper mapper)
        {
            _bikeWorkshop = bikeWorkshop;
            _mapper = mapper;
        }
        public async Task Create(BikeWorkshopDto bikeWorkshopDto)
        {
            var bikeWorkshop = _mapper.Map<Domain.Entities.BikeWorkshop>(bikeWorkshopDto);
            bikeWorkshop.EncodName();
            await _bikeWorkshop.Create(bikeWorkshop);
        }
    }
}
