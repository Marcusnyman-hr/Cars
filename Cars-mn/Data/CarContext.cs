using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cars_mn.Models;
using Microsoft.EntityFrameworkCore;


namespace Cars1._0.Data
{
  public class CarContext : DbContext
  {
    public CarContext(DbContextOptions<CarContext> options) : base(options)
    {
    }
    public DbSet<City> Cities { get; set; }
    public DbSet<Car> Cars { get; set; }
    public DbSet<Dealer> Dealers { get; set; }
    public DbSet<EngineType> EngineTypes { get; set; }
    public DbSet<Manufacturer> Manufacturers { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      base.OnModelCreating(modelBuilder);
      modelBuilder.Entity<City>(entity =>
      {
        entity.HasIndex(c => c.Name).IsUnique();
      });
      modelBuilder.Entity<Manufacturer>(entity =>
      {
        entity.HasIndex(m => m.ManufacturerName).IsUnique();
      });
      modelBuilder.Entity<EngineType>()
        .HasData(
        new EngineType()
        {
          Id = 1,
          Fuel = "Gasoline"
        },
        new EngineType()
        {
          Id = 2,
          Fuel = "Diesel"
        },
        new EngineType()
        {
          Id = 3,
          Fuel = "Electric"
        }
        );
      modelBuilder.Entity<City>()
        .HasData(
         new City()
         {
           Id = 1,
           Name = "Skeppshult"
         },
       new City()
       {
         Id = 2,
         Name = "Lidhem"
       },
       new City()
       {
         Id = 3,
         Name = "Trosa"
       }
        );
      modelBuilder.Entity<Dealer>()
       .HasData(
       new Dealer()
       {
         Id = 1,
         Name = "Skeppshults bilaffär",
         CityId = 1
       },
       new Dealer()
       {
         Id = 2,
         Name = "Lidhems bilaffär",
         CityId = 2
       },
        new Dealer()
        {
          Id = 3,
          Name = "Trosa bilaffär",
          CityId = 3
        }
       );
      modelBuilder.Entity<Manufacturer>()
       .HasData(
        new Manufacturer()
        {
          Id = 1,
          ManufacturerName = "Bmw"
        },
        new Manufacturer()
        {
          Id = 2,
          ManufacturerName = "Volvo"
        },
        new Manufacturer()
        {
          Id = 3,
          ManufacturerName = "Skoda"
        },
        new Manufacturer()
        {
          Id = 4,
          ManufacturerName = "Mazda"
        }
       );
      //modelBuilder.Entity<Car>()
      // .HasData(
      //  new Car()
      //  {
      //    Id = 1,
      //    ManufacturerId = 1,
      //    Model = "GLS230",
      //    EngineTypeId = 2,
      //    Year = 2010,
      //    Price = 9999,
      //    DealerId = 1
      //  },
      //  new Car()
      //  {
      //    Id = 2,
      //    ManufacturerId = 2,
      //    Model = "740",
      //    EngineTypeId = 1,
      //    Year = 2009,
      //    Price = 9999,
      //    DealerId = 2
      //  },
      //  new Car()
      //  {
      //    Id = 3,
      //    ManufacturerId = 3,
      //    Model = "Supra",
      //    EngineTypeId = 3,
      //    Year = 2000,
      //    Price = 9999,
      //    DealerId = 3
      //  }
      // );
    }
  }

}
