using Microsoft.VisualStudio.TestTools.UnitTesting;
using Recodme.Rd.JadeRest.BusinessLayer.BObjects.TitleBO;
using Recodme.Rd.JadeRest.DataAccessLayer.Seeders;
using Recodme.Rd.JadeRest.DataLayer.RestaurantData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JadeTests
{
    [TestClass]
    public class TitleTests
    {
        [TestMethod]
        public void TestCreateAndReadTitle()
        {
            RestaurantSeeder.SeedCountries();
            var bo = new TitleBusinessObject();
            var tl = new Title("Chef", "Sous Chef", "responsible for saucing all plates, i think...");
            var resCreate = bo.Create(tl);
            var resGet = bo.Read(tl.Id);
            Assert.IsTrue(resCreate.Success && resGet.Success && resGet.Result != null);
        }

        [TestMethod]
        public void TestListTitle()
        {
            RestaurantSeeder.SeedCountries();
            var bo = new TitleBusinessObject();
            var resList = bo.List();
            Assert.IsTrue(resList.Success && resList.Result.Count == 1);
        }

        [TestMethod]
        public void TestUpdateTitle()
        {
            RestaurantSeeder.SeedCountries();
            var bo = new TitleBusinessObject();
            var resList = bo.List();
            var item = resList.Result.FirstOrDefault();
            item.Name = "Master Chef";
            var resUpdate = bo.Update(item);
            var resNotList = bo.List().Result.Where(x => !x.IsDeleted);
            Assert.IsTrue(resUpdate.Success && resNotList.First().Name == "Master Chef");
        }

        [TestMethod]
        public void TestDeleteTitle()
        {
            RestaurantSeeder.SeedCountries();
            var bo = new TitleBusinessObject();
            var resList = bo.List();
            var resDelete = bo.Delete(resList.Result.First().Id);
            var resNotList = bo.List().Result.Where(x => !x.IsDeleted).ToList();
            Assert.IsTrue(resDelete.Success && resNotList.Count == 0);
        }
    }
}
