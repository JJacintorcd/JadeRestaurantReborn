using Microsoft.VisualStudio.TestTools.UnitTesting;
using Recodme.Rd.JadeRest.BusinessLayer.BObjects.RestaurantBO;
using Recodme.Rd.JadeRest.BusinessLayer.BObjects.TitleBO;
using Recodme.Rd.JadeRest.BusinessLayer.BObjects.UserBO;
using Recodme.Rd.JadeRest.DataAccessLayer.Seeders;
using Recodme.Rd.JadeRest.DataLayer.RestaurantData;
using System;
using System.Linq;

namespace JadeTests.TestsAsync
{
    [TestClass]
    public class StaffTitleAsyncTests
    {
        [TestMethod]
        public void TestCreateAndReadStaffTitleRecordAsync()
        {
            RestaurantSeeder.SeedCountries();
            var bo = new StaffTitleBusinessObject();
            var tbo = new TitleBusinessObject();
            var tl = tbo.List().Result.First();
            var sbo = new StaffRecordBusinessObject();
            var sr = sbo.List().Result.First();
            var st = new StaffTitle(DateTime.Parse("2015/05/05"), DateTime.Parse("2020/05/05"), tl.Id, sr.Id);
            var resCreate = bo.CreateAsync(st).Result;
            var resGet = bo.ReadAsync(st.Id).Result;
            Assert.IsTrue(resCreate.Success && resGet.Success && resGet.Result != null);
        }

        [TestMethod]
        public void TestListStaffTitleRecordAsync()
        {
            RestaurantSeeder.SeedCountries();
            var bo = new StaffTitleBusinessObject();
            var resList = bo.ListAsync().Result;
            Assert.IsTrue(resList.Success && resList.Result.Count == 1);
        }

        [TestMethod]
        public void TestUpdateStaffTitleRecordAsync()
        {
            RestaurantSeeder.SeedCountries();
            var bo = new StaffTitleBusinessObject();
            var resList = bo.ListAsync().Result;
            var item = resList.Result.FirstOrDefault();
            item.StartDate = DateTime.Parse("2014 / 05 / 05");
            var resUpdate = bo.UpdateAsync(item).Result;
            resList = bo.ListUnDeletedAsync().Result;
            Assert.IsTrue(resList.Success && resUpdate.Success && resList.Result.First().StartDate == DateTime.Parse("2014 / 05 / 05"));
        }

        [TestMethod]
        public void TestDeleteStaffTitleRecordAsync()
        {
            RestaurantSeeder.SeedCountries();
            var bo = new StaffTitleBusinessObject();
            var resList = bo.ListAsync().Result;
            var resDelete = bo.DeleteAsync(resList.Result.First().Id).Result;
            resList = bo.ListUnDeletedAsync().Result;
            Assert.IsTrue(resDelete.Success && resList.Success && resList.Result.Count == 0);
        }
    }
}
