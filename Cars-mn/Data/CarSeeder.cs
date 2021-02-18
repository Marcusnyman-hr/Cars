using Cars_mn.Models;
using Cars1._0.Data;
using static Cars_mn.StringShortener;
using Microsoft.AspNetCore.Hosting;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Cars_mn.Data
{
  public static class CarSeeder
  {

    public static void Seed(CarContext context)
    {
      if(!context.Cars.Any())
      {
      var json = File.ReadAllText(@"Data/data.json");
      var cars = JsonConvert.DeserializeObject<IEnumerable<JObject>>(json);
      foreach(var car in cars)
        {
          var engineType = car.Value<int>("EngineType");
          engineType += 1;
          Manufacturer manufacturer = context.Manufacturers.FirstOrDefault(m => m.ManufacturerName == (string)car.SelectToken("ManufacturerName"));
          Dealer dealer = context.Dealers.FirstOrDefault(d => d.Name == (string)car.SelectToken("Dealer.Name"));
          City city = context.Cities.FirstOrDefault(c => c.Name == (string)car.SelectToken("Dealer.City"));
          if(manufacturer == null)
          {
            var newManufacturer = new Manufacturer()
            {
              ManufacturerName = StringShortener.Truncate((string)car.SelectToken("ManufacturerName"), 10)
            };
          context.Manufacturers.Add(newManufacturer);
            manufacturer = newManufacturer;
          }
          if(dealer == null && city == null)
          {
            City newCity = new City()
            {
              Name = StringShortener.Truncate((string)car.SelectToken("Dealer.City"), 20)
            };
            context.Cities.Add(newCity);
            city = newCity;
            Dealer newDealer = new Dealer()
            {
              Name = StringShortener.Truncate((string)car.SelectToken("Dealer.Name"),50),
              City = city
            };
            context.Dealers.Add(newDealer);
            dealer = newDealer;
          }
          if (dealer == null && city != null)
          {
            Dealer newDealer = new Dealer()
            {
              Name = StringShortener.Truncate((string)car.SelectToken("Dealer.Name"),50),
              City = city
            };
            context.Dealers.Add(newDealer);
            dealer = newDealer;
          }
          if (dealer != null && city == null)
          {
            City newCity = new City()
            {
              Name = StringShortener.Truncate((string)car.SelectToken("Dealer.City"),20)
            };
            context.Cities.Add(newCity);
            city = newCity;
            Dealer newDealer = new Dealer()
            {
              Name = StringShortener.Truncate((string)car.SelectToken("Dealer.Name"),50),
              City = city
            };
            context.Dealers.Add(newDealer);
            dealer = newDealer;
          }
          Car newCar = new Car()
          {
            Manufacturer = manufacturer,
            Model = StringShortener.Truncate((string)car.SelectToken("Model"),10),
            EngineTypeId = engineType,
            Year = (int)car.SelectToken("Year"),
            Price = (decimal)car.SelectToken("Price"),
            Dealer = dealer
          };
          context.Cars.Add(newCar);
          context.SaveChanges();
        }

      }
    }

   
  }
}
