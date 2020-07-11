using Microsoft.VisualStudio.TestTools.UnitTesting;
using Recodme.Rd.JadeRest.BusinessLayer.BObjects.UserBO;
using Recodme.Rd.JadeRest.DataAccessLayer.Seeders;
using Recodme.Rd.JadeRest.DataLayer.UserData;
using System;
using System.Linq;

namespace JadeTests.TestsAsync
{
    [TestClass]
    public class ClientRecordAsyncTests
    {
        [TestMethod]
        public void TestCreateAndReadClientRecordAsync()
        {
            RestaurantSeeder.SeedCountries();
            var bo = new ClientRecordBusinessObject();
            var bop = new PersonBusinessObject();
            var personId = bop.List().Result.First();
            var dr = new ClientRecord(DateTime.Parse("2020/05/05"), personId.Id);
            var resCreate = bo.CreateAsync(dr).Result;
            var resGet = bo.ReadAsync(dr.Id).Result;
            Assert.IsTrue(resCreate.Success && resGet.Success && resGet.Result != null);
        }

        [TestMethod]
        public void TestListClientRecordAsync()
        {
            RestaurantSeeder.SeedCountries();
            var bo = new ClientRecordBusinessObject();
            var resList = bo.ListAsync().Result;
            Assert.IsTrue(resList.Success && resList.Result.Count == 1);
        }

        [TestMethod]
        public void TestUpdateClientRecordAsync()
        {
            RestaurantSeeder.SeedCountries();
            var bo = new ClientRecordBusinessObject();
            var resList = bo.ListAsync().Result;
            var item = resList.Result.FirstOrDefault();
            item.RegisterDate = DateTime.Parse("2020/06/05");
            var resUpdate = bo.UpdateAsync(item).Result;
            resList = bo.ListUnDeletedAsync().Result;
            Assert.IsTrue(resList.Success && resUpdate.Success && resList.Result.First().RegisterDate == DateTime.Parse("2020/06/05"));
        }

        [TestMethod]
        public void TestDeleteClientRecordAsync()
        {
            RestaurantSeeder.SeedCountries();
            var bo = new ClientRecordBusinessObject();
            var resList = bo.ListAsync().Result;
            var resDelete = bo.DeleteAsync(resList.Result.First().Id).Result;
            resList = bo.ListUnDeletedAsync().Result;
            Assert.IsTrue(resDelete.Success && resList.Success && resList.Result.Count == 0);
        }
    }
}