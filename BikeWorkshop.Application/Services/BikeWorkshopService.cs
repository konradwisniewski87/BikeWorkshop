using BikeWorkshop.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BikeWorkshop.Application.Services
{
    public class BikeWorkshopService : IBikeWorkshopService
    {
        private readonly IBikeWorkshopRepository _bikeWorkshop;

        public BikeWorkshopService(IBikeWorkshopRepository bikeWorkshop)
        {
            _bikeWorkshop = bikeWorkshop;
        }
        public async Task Create(Domain.Entities.BikeWorkshop bikeWorkshop)
        {
            bikeWorkshop.EncodName();
            await _bikeWorkshop.Create(bikeWorkshop);
        }
    }
}
