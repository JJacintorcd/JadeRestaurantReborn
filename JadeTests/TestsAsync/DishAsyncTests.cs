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
    public class DishAsyncTests
    {
        [TestMethod]
        public void TestCreateAndReadDishAsync()
        {
            RestaurantSeeder.SeedCountries();
            var bo = new DishBusinessObject();
            var boForeign = new DietaryRestrictionBusinessObject();

            var dish = new Dish("Lasagne", boForeign.List().Result.First().Id);

            var resCreate = bo.CreateAsync(dish).Result;
            var resGet = bo.ReadAsync(dish.Id).Result;
            Assert.IsTrue(resCreate.Success && resGet.Success && resGet.Result != null);
        }

        [TestMethod]
        public void TestListDishAsync()
        {
            RestaurantSeeder.SeedCountries();
            var bo = new DishBusinessObject();
            var resList = bo.ListAsync().Result;
            Assert.IsTrue(resList.Success && resList.Result.Count == 1);
        }

        [TestMethod]
        public void TestUpdateDishAsync()
        {
            RestaurantSeeder.SeedCountries();
            var bo = new DishBusinessObject();
            var resList = bo.ListAsync().Result;
            var item = resList.Result.FirstOrDefault();
            item.Name = "Pizza";
            var resUpdate = bo.UpdateAsync(item).Result;
            var resNotList = bo.ListUnDeletedAsync().Result;
            Assert.IsTrue(resUpdate.Success && resNotList.Result.First().Name == "Pizza");
        }

        [TestMethod]
        public void TestDeleteDishAsync()
        {
            RestaurantSeeder.SeedCountries();
            var bo = new DishBusinessObject();
            var resList = bo.ListAsync().Result;
            var resDelete = bo.DeleteAsync(resList.Result.First().Id).Result;
            var resNotList = bo.ListUnDeletedAsync().Result;
            Assert.IsTrue(resDelete.Success && resNotList.Result.Count == 0);
        }
    }
}
