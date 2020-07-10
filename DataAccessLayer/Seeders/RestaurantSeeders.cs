using Recodme.Rd.JadeRest.DataAccessLayer.Contexts;
using Recodme.Rd.JadeRest.DataLayer;
using System;
using System.Collections.Generic;
using System.Text;

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
            
            _ctx.DietaryRestrictions.AddRange(dr1);
            _ctx.SaveChanges();
        }
    }
}
