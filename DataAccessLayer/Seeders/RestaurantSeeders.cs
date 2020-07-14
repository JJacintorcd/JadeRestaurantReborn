using Recodme.Rd.JadeRest.DataAccessLayer.Contexts;
using Recodme.Rd.JadeRest.DataLayer.MenuData;
using Recodme.Rd.JadeRest.DataLayer.RestaurantData;
using Recodme.Rd.JadeRest.DataLayer.UserData;
using System;

namespace Recodme.Rd.JadeRest.DataAccessLayer.Seeders
{
    public static class RestaurantSeeder
    {
        public static void SeedCountries()
        {
            using var _ctx = new RestaurantContext();
            _ctx.Database.EnsureDeleted();
            _ctx.Database.EnsureCreated();

            var dr1 = new DietaryRestriction("Vegan");
            var pe1 = new Person(123456789, "Zé", "Pedro", 987654321, DateTime.Parse("1990/01/01"));
            var rs1 = new Restaurant("Jade", "Avenida da Liberdade antes da rotunda", "13h00", "23h00", "monday", 24);
            var cr1 = new ClientRecord(DateTime.Parse("2020/05/05"), pe1.Id, rs1.Id);
            var tl1 = new Title("Chef", "Sous Chef", "responsible for saucing all plates, i think...");
            var sr1 = new StaffRecord(DateTime.Parse("2020/05/05"), DateTime.Parse("2020/06/06"), pe1.Id, rs1.Id);
            var st1 = new StaffTitle(DateTime.Parse("2015/05/05"), DateTime.Parse("2020/05/05"), tl1.Id, sr1.Id);
            var ds1 = new Dish("Couscous", dr1.Id);
            var ml1 = new Meal("Lunch", "13h00", "16h00");
            var bk1 = new Booking(DateTime.Parse("2015/05/05"), cr1.Id);
            
            _ctx.DietaryRestrictions.AddRange(dr1);
            _ctx.People.AddRange(pe1);
            _ctx.ClientRecords.AddRange(cr1);
            _ctx.StaffRecords.AddRange(sr1);
            _ctx.Titles.AddRange(tl1);
            _ctx.Restaurants.AddRange(rs1);
            _ctx.StaffTitles.AddRange(st1);
            _ctx.Dishes.AddRange(ds1);
            _ctx.Meals.AddRange(ml1);
            _ctx.Bookings.AddRange(bk1);
            _ctx.SaveChanges();
        }
    }
}
