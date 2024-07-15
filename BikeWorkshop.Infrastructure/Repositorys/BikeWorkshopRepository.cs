using BikeWorkshop.Domain.Interfaces;
using BikeWorkshop.Infrastructure.Persistence;

namespace BikeWorkshop.Infrastructure.Repositorys
{
    public class BikeWorkshopRepository : IBikeWorkshopRepository
    {
        private readonly BikeWorkshopDbContext _dbContext;

        public BikeWorkshopRepository(BikeWorkshopDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task Create(Domain.Entities.BikeWorkshop bikeWorkshop)
        {
            _dbContext.Add(bikeWorkshop);
            await _dbContext.SaveChangesAsync();
        }
    }
}
