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
    public class DishTests
    {
        [TestMethod]
        public void TestCreateAndReadDish()
        {
            RestaurantSeeder.SeedCountries();
            var bo = new DishBusinessObject();
            var boForeign = new DietaryRestrictionBusinessObject();

            var dish = new Dish("Lasagne", boForeign.List().Result.First().Id);

            var resCreate = bo.Create(dish);
            var resGet = bo.Read(dish.Id);
            Assert.IsTrue(resCreate.Success && resGet.Success && resGet.Result != null);
        }

        [TestMethod]
        public void TestListDish()
        {
            RestaurantSeeder.SeedCountries();
            var bo = new DishBusinessObject();
            var resList = bo.List();
            Assert.IsTrue(resList.Success && resList.Result.Count == 1);
        }

        [TestMethod]
        public void TestUpdateDish()
        {
            RestaurantSeeder.SeedCountries();
            var bo = new DishBusinessObject();
            var resList = bo.List();
            var item = resList.Result.FirstOrDefault();
            item.Name = "Pizza";
            var resUpdate = bo.Update(item);
            var resNotList = bo.List().Result.Where(x => !x.IsDeleted);
            Assert.IsTrue(resUpdate.Success && resNotList.First().Name == "Pizza");
        }

        [TestMethod]
        public void TestDeleteDish()
        {
            RestaurantSeeder.SeedCountries();
            var bo = new DishBusinessObject();
            var resList = bo.List();
            var resDelete = bo.Delete(resList.Result.First().Id);
            var resNotList = bo.List().Result.Where(x => !x.IsDeleted).ToList();
            Assert.IsTrue(resDelete.Success && resNotList.Count == 0);
        }
    }
}
