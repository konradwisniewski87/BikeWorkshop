using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BikeWorkshop.Infrastructure.Persistence
{
    public class BikeWorkshopDbContext : IdentityDbContext
    {
        public BikeWorkshopDbContext(DbContextOptions<BikeWorkshopDbContext> options) : base(options)
        {
            
        }
        public DbSet<Domain.Entities.BikeWorkshop> BikeWorkshops { get; set; }
        public DbSet<Domain.Entities.BikeWorkshopService> Services { get; set; }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer("Server=(localDB)\\mssqllocaldb;Database=BikeWorkshopDb;Trusted_Connection=True;");
        //}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Domain.Entities.BikeWorkshop>()
                .OwnsOne(e => e.ContactDetails);

            modelBuilder.Entity<Domain.Entities.BikeWorkshop>()
                .HasMany(e => e.Services)
                .WithOne(b => b.BikeWorkshop)
                .HasForeignKey(k => k.BikeWorkshopId);
        }
    }
}
