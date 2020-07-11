using Microsoft.VisualStudio.TestTools.UnitTesting;
using Recodme.Rd.JadeRest.BusinessLayer.BObjects.RestaurantBO;
using Recodme.Rd.JadeRest.BusinessLayer.BObjects.TitleBO;
using Recodme.Rd.JadeRest.BusinessLayer.BObjects.UserBO;
using Recodme.Rd.JadeRest.DataAccessLayer.Seeders;
using Recodme.Rd.JadeRest.DataLayer.RestaurantData;
using System;
using System.Linq;

namespace JadeTests
{
    [TestClass]
    public class StaffTitleTests
    {
        [TestMethod]
        public void TestCreateAndReadStaffTitle()
        {
            RestaurantSeeder.SeedCountries();
            var stbo = new StaffTitleBusinessObject();
            var tbo = new TitleBusinessObject();
            var tl = tbo.List().Result.First();
            var sbo = new StaffRecordBusinessObject();
            var sr = sbo.List().Result.First();
            var st = new StaffTitle(DateTime.Parse("2015/05/05"), DateTime.Parse("2020/05/05"), tl.Id, sr.Id);
            var resCreate = stbo.Create(st);
            var resGet = stbo.Read(st.Id);
            Assert.IsTrue(resCreate.Success && resGet.Success && resGet.Result != null);
        }

        [TestMethod]
        public void TestListStaffTitle()
        {
            RestaurantSeeder.SeedCountries();
            var bo = new StaffTitleBusinessObject();
            var resList = bo.List();
            Assert.IsTrue(resList.Success && resList.Result.Count == 1);
        }

        [TestMethod]
        public void TestUpdateStaffTitle()
        {
            RestaurantSeeder.SeedCountries();
            var bo = new StaffTitleBusinessObject();
            var resList = bo.List();
            var item = resList.Result.FirstOrDefault();
            item.StartDate = DateTime.Parse("2014 / 05 / 05");
            var resUpdate = bo.Update(item);
            var resNotList = bo.List().Result.Where(x => !x.IsDeleted);
            Assert.IsTrue(resUpdate.Success && resNotList.First().StartDate == DateTime.Parse("2014 / 05 / 05"));
        }

        [TestMethod]
        public void TestDeleteStaffTitle()
        {
            RestaurantSeeder.SeedCountries();
            var bo = new StaffTitleBusinessObject();
            var resList = bo.List();
            var resDelete = bo.Delete(resList.Result.First().Id);
            var resNotList = bo.List().Result.Where(x => !x.IsDeleted).ToList();
            Assert.IsTrue(resDelete.Success && resNotList.Count == 0);
        }
    }
}

