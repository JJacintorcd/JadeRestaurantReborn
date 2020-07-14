using Microsoft.VisualStudio.TestTools.UnitTesting;
using Recodme.Rd.JadeRest.BusinessLayer.BObjects.MenuBO;
using Recodme.Rd.JadeRest.DataAccessLayer.Seeders;
using Recodme.Rd.JadeRest.DataLayer.MenuData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JadeTests.TestsAsync
{
    [TestClass]
    public class MealAsyncTests
    {
        [TestMethod]
        public void TestCreateAndReadMealAsync()
        {
            RestaurantSeeder.SeedCountries();
            var bo = new MealBusinessObject();

            var meal = new Meal("Dinner", "19h00", "23h00");

            var resCreate = bo.CreateAsync(meal).Result;
            var resGet = bo.ReadAsync(meal.Id).Result;
            Assert.IsTrue(resCreate.Success && resGet.Success && resGet.Result != null);
        }

        [TestMethod]
        public void TestListMealAsync()
        {
            RestaurantSeeder.SeedCountries();
            var bo = new MealBusinessObject();
            var resList = bo.ListAsync().Result;
            Assert.IsTrue(resList.Success && resList.Result.Count == 1);
        }

        [TestMethod]
        public void TestUpdateMealAsync()
        {
            RestaurantSeeder.SeedCountries();
            var bo = new MealBusinessObject();
            var resList = bo.ListAsync().Result;
            var item = resList.Result.FirstOrDefault();
            item.StartingHours = "20h00";
            var resUpdate = bo.UpdateAsync(item).Result;
            var resNotList = bo.ListUnDeletedAsync().Result;
            Assert.IsTrue(resUpdate.Success && resNotList.Result.First().StartingHours == "20h00");
        }

        [TestMethod]
        public void TestDeleteMealAsync()
        {
            RestaurantSeeder.SeedCountries();
            var bo = new MealBusinessObject();
            var resList = bo.ListAsync().Result;
            var resDelete = bo.DeleteAsync(resList.Result.First().Id).Result;
            var resNotList = bo.ListUnDeletedAsync().Result;
            Assert.IsTrue(resDelete.Success && resNotList.Result.Count == 0);
        }
    }
}
