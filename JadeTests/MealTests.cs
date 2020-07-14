using Microsoft.VisualStudio.TestTools.UnitTesting;
using Recodme.Rd.JadeRest.BusinessLayer.BObjects.MenuBO;
using Recodme.Rd.JadeRest.DataAccessLayer.Seeders;
using Recodme.Rd.JadeRest.DataLayer.MenuData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JadeTests
{
    [TestClass]
    public class MealTests
    {
        [TestMethod]
        public void TestCreateAndReadMeal()
        {
            RestaurantSeeder.SeedCountries();
            var bo = new MealBusinessObject();

            var meal = new Meal("Dinner", "19h00", "23h00");

            var resCreate = bo.Create(meal);
            var resGet = bo.Read(meal.Id);
            Assert.IsTrue(resCreate.Success && resGet.Success && resGet.Result != null);
        }

        [TestMethod]
        public void TestListMeal()
        {
            RestaurantSeeder.SeedCountries();
            var bo = new MealBusinessObject();
            var resList = bo.List();
            Assert.IsTrue(resList.Success && resList.Result.Count == 1);
        }

        [TestMethod]
        public void TestUpdateMeal()
        {
            RestaurantSeeder.SeedCountries();
            var bo = new MealBusinessObject();
            var resList = bo.List();
            var item = resList.Result.FirstOrDefault();
            item.StartingHours = "20h00";
            var resUpdate = bo.Update(item);
            var resNotList = bo.List().Result.Where(x => !x.IsDeleted);
            Assert.IsTrue(resUpdate.Success && resNotList.First().StartingHours == "20h00");
        }

        [TestMethod]
        public void TestDeleteMeal()
        {
            RestaurantSeeder.SeedCountries();
            var bo = new MealBusinessObject();
            var resList = bo.List();
            var resDelete = bo.Delete(resList.Result.First().Id);
            var resNotList = bo.List().Result.Where(x => !x.IsDeleted).ToList();
            Assert.IsTrue(resDelete.Success && resNotList.Count == 0);
        }
    }
}
