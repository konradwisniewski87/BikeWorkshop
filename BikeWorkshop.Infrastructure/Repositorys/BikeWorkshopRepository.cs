using BikeWorkshop.Domain.Interfaces;
using BikeWorkshop.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using System.Threading.Channels;

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
            bikeWorkshop.EncodName();
            _dbContext.Add(bikeWorkshop);
            await _dbContext.SaveChangesAsync();
        }

        public Task<Domain.Entities.BikeWorkshop?> GetByName(string name)
        => _dbContext.BikeWorkshops.FirstOrDefaultAsync( cn => cn.Name.ToLower() == name.ToLower());   
    }
}
