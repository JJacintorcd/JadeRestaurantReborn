using Recodme.Rd.JadeRest.BusinessLayer.BObjects.MenuBO;
using Recodme.Rd.JadeRest.DataAccessLayer.DAObjects.MenuDAO;
using Recodme.Rd.JadeRest.DataAccessLayer.Contexts;
using Recodme.Rd.JadeRest.DataLayer;
using System;

namespace App
{
    class Program
    {
        static void Main(string[] args)
        {
            //var database = new RestaurantContext();
            //database.Database.EnsureCreated();

            var dao = new DietaryRestrictionDataAccessObject();
            var omni = dao.Read(Guid.Parse("4047AFDC-FD05-4CCB-95F9-F862505EF31D"));
            dao.Update(omni);
        }
    }
}
