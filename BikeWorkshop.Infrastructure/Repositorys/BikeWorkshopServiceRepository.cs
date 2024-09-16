using BikeWorkshop.Domain.Entities;
using BikeWorkshop.Domain.Interfaces;
using BikeWorkshop.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BikeWorkshop.Infrastructure.Repositorys
{
    public class BikeWorkshopServiceRepository : IBikeWorkshopServiceRepository
    {
        private readonly BikeWorkshopDbContext _dbContext;

        public BikeWorkshopServiceRepository(BikeWorkshopDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task Create(BikeWorkshopService bikeWorkshopService)
        {
            _dbContext.Services.Add(bikeWorkshopService);
            await _dbContext.SaveChangesAsync();
        }
    }
}
