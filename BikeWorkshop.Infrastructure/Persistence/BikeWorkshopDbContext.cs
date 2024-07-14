﻿using BikeWorkshop.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BikeWorkshop.Infrastructure.Persistence
{
    public class BikeWorkshopDbContext : DbContext
    {
        public BikeWorkshopDbContext(DbContextOptions<BikeWorkshopDbContext> options) : base(options)
        {
            
        }
        public DbSet<Domain.Entities.BikeWorkshop> BikeWorkshops { get; set; }
        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer("Server=(localDB)\\mssqllocaldb;Database=BikeWorkshopDb;Trusted_Connection=True;");
        //}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Domain.Entities.BikeWorkshop>()
                .OwnsOne(e => e.ContactDetails);
        }
    }
}
