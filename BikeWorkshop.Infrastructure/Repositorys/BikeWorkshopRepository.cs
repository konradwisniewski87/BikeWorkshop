using BikeWorkshop.Application.BikeWorkshop;
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

        public async Task<IEnumerable<Domain.Entities.BikeWorkshop>> GetAll()
            => await _dbContext.BikeWorkshops.ToListAsync();

        public async Task<Domain.Entities.BikeWorkshop?> GetByEncodedName(string encodedName)
            => await _dbContext.BikeWorkshops.FirstOrDefaultAsync(c => c.EncodedName == encodedName);

        public Task Commit()
            => _dbContext.SaveChangesAsync();
    }
}
