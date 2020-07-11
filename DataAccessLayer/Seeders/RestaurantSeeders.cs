using Recodme.Rd.JadeRest.DataAccessLayer.DAObjects.MenuDAO.Contexts;
using Recodme.Rd.JadeRest.DataLayer;
using Recodme.Rd.JadeRest.DataLayer.MenuData;
using System;
using System.Collections.Generic;
using System.Text;
using Recodme.Rd.JadeRest.DataLayer.UserData;

namespace Recodme.Rd.JadeRest.DataAccessLayer.DAObjects.MenuDAO.Seeders
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
            var cr1 = new ClientRecord(DateTime.Parse("2020/05/05"), pe1.Id);
            //var sr1 = new StaffRecord(DateTime.Parse("2020/05/05"), DateTime.Parse("2020/06/06"), pe1.Id);
            
            _ctx.DietaryRestrictions.AddRange(dr1);
            _ctx.People.AddRange(pe1);
            _ctx.ClientRecords.AddRange(cr1);
            //_ctx.StaffRecords.AddRange(sr1);
            _ctx.SaveChanges();
        }
    }
}
