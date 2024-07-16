
using BikeWorkshop.Application.BikeWorkshop;

namespace BikeWorkshop.Application.Services
{
    public interface IBikeWorkshopService
    {
        Task Create(BikeWorkshopDto bikeWorkshop);
    }
}