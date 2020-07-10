using vRecodme.Rd.JadeRest.DataAccessLayer.DAObjects.MenuDAO.Contexts;
using Recodme.Rd.JadeRest.DataLayer;
using Recodme.Rd.JadeRest.DataLayer.MenuData;
using System;
using System.Collections.Generic;
using System.Text;

namespace vRecodme.Rd.JadeRest.DataAccessLayer.DAObjects.MenuDAO.Seeders
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
