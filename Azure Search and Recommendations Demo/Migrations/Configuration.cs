using Azure_Search_and_Recommendations_Demo.Models;
using System.Data.Entity.Migrations;

namespace Azure_Search_and_Recommendations_Demo.Migrations
{

    internal sealed class Configuration : DbMigrationsConfiguration<DAL.SearchContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(DAL.SearchContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //

            context.Cars.AddOrUpdate(p => p.Make,                
                  new Car
                  {
                      Id = 1,
                      Make = "Toyota",
                      Model = "Yaris",
                      Year = 2011,
                      Rating = 4
                  },
                  new Car
                  {
                      Id = 2,
                      Make = "Toyota",
                      Model = "Yaris",
                      Year = 2012,
                      Rating = 5
                  },
                  new Car
                  {
                      Id = 3,
                      Make = "Toyota",
                      Model = "Yaris",
                      Year = 2013,
                      Rating = 4
                  },
                  new Car
                  {
                      Id = 4,
                      Make = "Toyota",
                      Model = "Yaris",
                      Year = 2014,
                      Rating = 5
                  },
                  new Car
                  {
                      Id = 5,
                      Make = "Toyota",
                      Model = "Yaris",
                      Year = 2015,
                      Rating = 5
                  },
                  new Car
                  {
                      Id = 6,
                      Make = "Toyota",
                      Model = "Tundra",
                      Year = 2011,
                      Rating = 4
                  },
                  new Car
                  {
                      Id = 7,
                      Make = "Toyota",
                      Model = "Tundra",
                      Year = 2012,
                      Rating = 4
                  },
                  new Car
                  {
                      Id = 8,
                      Make = "Toyota",
                      Model = "Tundra",
                      Year = 2013,
                      Rating = 5
                  },
                  new Car
                  {
                      Id = 9,
                      Make = "Toyota",
                      Model = "Tundra",
                      Year = 2014,
                      Rating = 5
                  },
                  new Car
                  {
                      Id = 10,
                      Make = "Toyota",
                      Model = "Tundra",
                      Year = 2015,
                      Rating = 5
                  },
                  new Car
                  {
                      Id = 11,
                      Make = "GM",
                      Model = "Buick",
                      Year = 2011,
                      Rating = 2
                  },
                  new Car
                  {
                      Id = 12,
                      Make = "GM",
                      Model = "Buick",
                      Year = 2012,
                      Rating = 5
                  },
                  new Car
                  {
                      Id = 13,
                      Make = "GM",
                      Model = "Buick",
                      Year = 2013,
                      Rating = 5
                  },
                  new Car
                  {
                      Id = 14,
                      Make = "GM",
                      Model = "Buick",
                      Year = 2014,
                      Rating = 4
                  },
                  new Car
                  {
                      Id = 15,
                      Make = "GM",
                      Model = "Buick",
                      Year = 2015,
                      Rating = 4
                  },
                  new Car
                  {
                      Id = 16,
                      Make = "GM",
                      Model = "Camaro",
                      Year = 2011,
                      Rating = 3
                  },
                  new Car
                  {
                      Id = 17,
                      Make = "GM",
                      Model = "Camaro",
                      Year = 2012,
                      Rating = 3
                  },
                  new Car
                  {
                      Id = 18,
                      Make = "GM",
                      Model = "Camaro",
                      Year = 2013,
                      Rating = 4
                  },
                  new Car
                  {
                      Id = 19,
                      Make = "GM",
                      Model = "Camaro",
                      Year = 2014,
                      Rating = 4
                  },
                  new Car
                  {
                      Id = 20,
                      Make = "GM",
                      Model = "Camaro",
                      Year = 2015,
                      Rating = 5
                  },
                  new Car
                  {
                      Id = 21,
                      Make = "Volkswagen ",
                      Model = "Golf",
                      Year = 2011,
                      Rating = 3
                  },
                  new Car
                  {
                      Id = 22,
                      Make = "Volkswagen ",
                      Model = "Golf",
                      Year = 2012,
                      Rating = 3
                  },
                  new Car
                  {
                      Id = 23,
                      Make = "Volkswagen ",
                      Model = "Golf",
                      Year = 2013,
                      Rating = 5
                  },
                  new Car
                  {
                      Id = 24,
                      Make = "Volkswagen ",
                      Model = "Golf",
                      Year = 2014,
                      Rating = 5
                  },
                  new Car
                  {
                      Id = 25,
                      Make = "Volkswagen ",
                      Model = "Golf",
                      Year = 2015,
                      Rating = 5
                  },
                  new Car
                  {
                      Id = 26,
                      Make = "Volkswagen ",
                      Model = "Passat",
                      Year = 2011,
                      Rating = 4
                  },
                  new Car
                  {
                      Id = 27,
                      Make = "Volkswagen ",
                      Model = "Passat",
                      Year = 2012,
                      Rating = 5
                  },
                  new Car
                  {
                      Id = 28,
                      Make = "Volkswagen ",
                      Model = "Passat",
                      Year = 2013,
                      Rating = 5
                  },
                  new Car
                  {
                      Id = 29,
                      Make = "Volkswagen ",
                      Model = "Passat",
                      Year = 2014,
                      Rating = 4
                  },
                  new Car
                  {
                      Id = 30,
                      Make = "Volkswagen ",
                      Model = "Passat",
                      Year = 2015,
                      Rating = 4
                  },
                  new Car
                  {
                      Id = 31,
                      Make = "Nissan",
                      Model = "Altima",
                      Year = 2011,
                      Rating = 3
                  },
                  new Car
                  {
                      Id = 32,
                      Make = "Nissan",
                      Model = "Altima",
                      Year = 2012,
                      Rating = 3
                  },
                  new Car
                  {
                      Id = 33,
                      Make = "Nissan",
                      Model = "Altima",
                      Year = 2013,
                      Rating = 4
                  },
                  new Car
                  {
                      Id = 34,
                      Make = "Nissan",
                      Model = "Altima",
                      Year = 2014,
                      Rating = 3
                  },
                  new Car
                  {
                      Id = 35,
                      Make = "Nissan",
                      Model = "Altima",
                      Year = 2015,
                      Rating = 4
                  },
                  new Car
                  {
                      Id = 36,
                      Make = "Nissan",
                      Model = "Titan",
                      Year = 2011,
                      Rating = 3
                  },
                  new Car
                  {
                      Id = 37,
                      Make = "Nissan",
                      Model = "Titan",
                      Year = 2012,
                      Rating = 4
                  },
                  new Car
                  {
                      Id = 38,
                      Make = "Nissan",
                      Model = "Titan",
                      Year = 2013,
                      Rating = 3
                  },
                  new Car
                  {
                      Id = 39,
                      Make = "Nissan",
                      Model = "Titan",
                      Year = 2014,
                      Rating = 3
                  },
                  new Car
                  {
                      Id = 40,
                      Make = "Nissan",
                      Model = "Titan",
                      Year = 2015,
                      Rating = 2
                  }
                );
        }
    }
}


