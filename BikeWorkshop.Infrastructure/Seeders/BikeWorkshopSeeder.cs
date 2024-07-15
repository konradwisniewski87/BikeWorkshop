using BikeWorkshop.Infrastructure.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BikeWorkshop.Infrastructure.Seeders
{
    public class BikeWorkshopSeeder
    {
        private readonly BikeWorkshopDbContext _dbContext;

        public BikeWorkshopSeeder(BikeWorkshopDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task Seed()
        {
            if (await _dbContext.Database.CanConnectAsync())
            {
                if (!_dbContext.BikeWorkshops.Any())
                {
                    var krossWorkshop = new Domain.Entities.BikeWorkshop()
                    {
                        Name = "Kross",
                        Description = "Authorized service of Kross",
                        About = "Very noce service",
                        ContactDetails = new()
                        {
                            PhoneNumber = "+48297521100",
                            Street = "Leszno 46",
                            City = "Przasnyszu",
                            PostalCode = "06-300",
                        }
                    };
                    krossWorkshop.EncodName();
                    _dbContext.BikeWorkshops.Add(krossWorkshop);
                    await _dbContext.SaveChangesAsync();
                }
            }
        }

    }
}
