using Microsoft.VisualStudio.TestTools.UnitTesting;
using Recodme.Rd.JadeRest.BusinessLayer.BObjects.RestaurantBO;
using Recodme.Rd.JadeRest.BusinessLayer.BObjects.UserBO;
using Recodme.Rd.JadeRest.DataAccessLayer.Seeders;
using Recodme.Rd.JadeRest.DataLayer.UserData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JadeTests
{
    [TestClass]
    public class StaffRecordTests
    {
        [TestMethod]
        public void TestCreateAndReadClientRecord()
        {
            RestaurantSeeder.SeedCountries();
            var bo = new StaffRecordBusinessObject();
            var bop = new PersonBusinessObject();
            var personId = bop.List().Result.First();
            var bor = new RestaurantBusinessObject();
            var restaurantId = bor.List().Result.First();
            var dr = new StaffRecord(DateTime.Parse("2020/05/05"), DateTime.Parse("2020/06/06"), personId.Id, restaurantId.Id);
            var resCreate = bo.Create(dr);
            var resGet = bo.Read(dr.Id);
            Assert.IsTrue(resCreate.Success && resGet.Success && resGet.Result != null);
        }

        [TestMethod]
        public void TestListClientRecord()
        {
            RestaurantSeeder.SeedCountries();
            var bo = new StaffRecordBusinessObject();
            var resList = bo.List();
            Assert.IsTrue(resList.Success && resList.Result.Count == 1);
        }

        [TestMethod]
        public void TestUpdateClientRecord()
        {
            RestaurantSeeder.SeedCountries();
            var bo = new StaffRecordBusinessObject();
            var resList = bo.List();
            var item = resList.Result.FirstOrDefault();
            item.BeginDate = DateTime.Parse("2020/05/05");
            var resUpdate = bo.Update(item);
            var resNotList = bo.List().Result.Where(x => !x.IsDeleted);
            Assert.IsTrue(resUpdate.Success && resNotList.First().BeginDate == DateTime.Parse("2020/05/05"));
        }

        [TestMethod]
        public void TestDeleteClientRecord()
        {
            RestaurantSeeder.SeedCountries();
            var bo = new StaffRecordBusinessObject();
            var resList = bo.List();
            var resDelete = bo.Delete(resList.Result.First().Id);
            var resNotList = bo.List().Result.Where(x => !x.IsDeleted).ToList();
            Assert.IsTrue(resDelete.Success && resNotList.Count == 0);
        }
    }
}
