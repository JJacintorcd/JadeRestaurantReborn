using Microsoft.VisualStudio.TestTools.UnitTesting;
using Recodme.Rd.JadeRest.BusinessLayer.BObjects.TitleBO;
using Recodme.Rd.JadeRest.DataAccessLayer.Seeders;
using Recodme.Rd.JadeRest.DataLayer.RestaurantData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JadeTests.TestsAsync
{
    [TestClass]
    public class TitleAsyncTests
    {
        [TestMethod]
        public void TestCreateAndReadTitleAsync()
        {
            RestaurantSeeder.SeedCountries();
            var bo = new TitleBusinessObject();
            var tl = new Title("Chef", "Sous Chef", "responsible for saucing all plates, i think...");
            var resCreate = bo.CreateAsync(tl).Result;
            var resGet = bo.ReadAsync(tl.Id).Result;
            Assert.IsTrue(resCreate.Success && resGet.Success && resGet.Result != null);
        }

        [TestMethod]
        public void TestListTitleAsync()
        {
            RestaurantSeeder.SeedCountries();
            var bo = new TitleBusinessObject();
            var resList = bo.ListAsync().Result;
            Assert.IsTrue(resList.Success && resList.Result.Count == 1);
        }

        [TestMethod]
        public void TestUpdateTitleAsync()
        {
            RestaurantSeeder.SeedCountries();
            var bo = new TitleBusinessObject();
            var resList = bo.ListAsync().Result;
            var item = resList.Result.FirstOrDefault();
            item.Name = "Master Chef";
            var resUpdate = bo.UpdateAsync(item).Result;
            resList = bo.ListUnDeletedAsync().Result;
            Assert.IsTrue(resList.Success && resUpdate.Success && resList.Result.First().Name == "Master Chef");
        }

        [TestMethod]
        public void TestDeleteTitleAsync()
        {
            RestaurantSeeder.SeedCountries();
            var bo = new TitleBusinessObject();
            var resList = bo.ListAsync().Result;
            var resDelete = bo.DeleteAsync(resList.Result.First().Id).Result;
            resList = bo.ListUnDeletedAsync().Result;
            Assert.IsTrue(resDelete.Success && resList.Success && resList.Result.Count == 0);
        }
    }
}
