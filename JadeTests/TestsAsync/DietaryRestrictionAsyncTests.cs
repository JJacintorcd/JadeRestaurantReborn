using Microsoft.VisualStudio.TestTools.UnitTesting;
using Recodme.Rd.JadeRest.BusinessLayer.BObjects.MenuBO;
using Recodme.Rd.JadeRest.DataAccessLayer.DAObjects.MenuDAO.Seeders;
using Recodme.Rd.JadeRest.DataLayer.MenuData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JadeTests.TestsAsync
{
    [TestClass]
    public class DietaryRestrictionTests
    {
        [TestMethod]
        public void TestCreateAndListDietaryRestrictionAsync()
        {
            RestaurantSeeder.SeedCountries();
            var bo = new DietaryRestrictionBusinessObject();
            var dr = new DietaryRestriction("Vegetarian");
            var resCreate = bo.CreateAsync(dr).Result;
            var resGet = bo.ReadAsync(dr.Id).Result;
            Assert.IsTrue(resCreate.Success && resGet.Success && resGet.Result != null);
        }
        
        [TestMethod]
        public void TestListDietaryRestrictionAsync()
        {
            RestaurantSeeder.SeedCountries();
            var bo = new DietaryRestrictionBusinessObject();
            var resList = bo.ListAsync().Result;
            Assert.IsTrue(resList.Success && resList.Result.Count == 1);
        }
        
        [TestMethod]
        public void TestUpdateDietaryRestrictionAsync()
        {
            RestaurantSeeder.SeedCountries();
            var bo = new DietaryRestrictionBusinessObject();
            var resList = bo.ListAsync().Result;
            var item = resList.Result.FirstOrDefault();
            item.Name = "another";
            var resUpdate = bo.UpdateAsync(item).Result;
            resList = bo.ListUnDeletedAsync().Result;
            Assert.IsTrue(resList.Success && resUpdate.Success && resList.Result.First().Name == "another");
        }
        
        [TestMethod]
        public void TestDeleteDietaryRestrictionAsync()
        {
            RestaurantSeeder.SeedCountries();
            var bo = new DietaryRestrictionBusinessObject();
            var resList = bo.ListAsync().Result;
            var resDelete = bo.DeleteAsync(resList.Result.First().Id).Result;
            resList = bo.ListUnDeletedAsync().Result;
            Assert.IsTrue(resDelete.Success && resList.Success && resList.Result.Count == 0);
        }
    }
}
