using AutoMapper;
using BikeWorkshop.Application.BikeWorkshop;
using BikeWorkshop.Domain.Interfaces;

namespace BikeWorkshop.Application.Services
{
    public class BikeWorkshopService : IBikeWorkshopService
    {
        private readonly IBikeWorkshopRepository _bikeWorkshopRepository;
        private readonly IMapper _mapper;

        public BikeWorkshopService(IBikeWorkshopRepository bikeWorkshopRepository, IMapper mapper)
        {
            _bikeWorkshopRepository = bikeWorkshopRepository;
            _mapper = mapper;
        }
        public async Task Create(BikeWorkshopDto bikeWorkshopDto)
        {
            var bikeWorkshop = _mapper.Map<Domain.Entities.BikeWorkshop>(bikeWorkshopDto);
            bikeWorkshop.EncodName();
            await _bikeWorkshopRepository.Create(bikeWorkshop);
        }

        public async Task<IEnumerable<BikeWorkshopDto>> GetAll()
        {
            var bikeWorkshop = await _bikeWorkshopRepository.GetAll();
            var bikeWorkshopDto = _mapper.Map<IEnumerable<BikeWorkshopDto>>(bikeWorkshop);
            return bikeWorkshopDto;
        }
    }
}
