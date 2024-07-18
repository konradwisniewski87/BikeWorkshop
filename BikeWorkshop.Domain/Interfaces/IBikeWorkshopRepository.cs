namespace BikeWorkshop.Domain.Interfaces
{
    public interface IBikeWorkshopRepository
    {
        Task Create(Domain.Entities.BikeWorkshop bikeWorkshop);
        Task<Domain.Entities.BikeWorkshop?> GetByName(string name);
    }
}
