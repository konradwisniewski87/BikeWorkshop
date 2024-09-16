using BikeWorkshop.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BikeWorkshop.Domain.Interfaces
{
    public interface IBikeWorkshopServiceRepository
    {
        Task Create(BikeWorkshopService bikeWorkshopService);
    }
}
