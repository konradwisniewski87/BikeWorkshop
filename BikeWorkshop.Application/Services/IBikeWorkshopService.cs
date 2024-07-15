
namespace BikeWorkshop.Application.Services
{
    public interface IBikeWorkshopService
    {
        Task Create(Domain.Entities.BikeWorkshop bikeWorkshop);
    }
}