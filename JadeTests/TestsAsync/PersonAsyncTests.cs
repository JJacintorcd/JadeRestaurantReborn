using Microsoft.VisualStudio.TestTools.UnitTesting;
using Recodme.Rd.JadeRest.BusinessLayer.BObjects.UserBO;
using Recodme.Rd.JadeRest.DataAccessLayer.Seeders;
using Recodme.Rd.JadeRest.DataLayer.UserData;
using System;
using System.Linq;

namespace JadeTests.TestsAsync
{
    [TestClass]
    public class PersonAsyncTests
    {
        [TestMethod]
        public void TestCreateAndReadPersonAsync()
        {
            RestaurantSeeder.SeedCountries();
            var bo = new PersonBusinessObject();
            var dr = new Person(123456789, "Zé", "Pedro", 987654321, DateTime.Parse("1990/01/01"));
            var resCreate = bo.CreateAsync(dr).Result;
            var resGet = bo.ReadAsync(dr.Id).Result;
            Assert.IsTrue(resCreate.Success && resGet.Success && resGet.Result != null);
        }

        [TestMethod]
        public void TestListPersonAsync()
        {
            RestaurantSeeder.SeedCountries();
            var bo = new PersonBusinessObject();
            var resList = bo.ListAsync().Result;
            Assert.IsTrue(resList.Success && resList.Result.Count == 1);
        }

        [TestMethod]
        public void TestUpdatePersonAsync()
        {
            RestaurantSeeder.SeedCountries();
            var bo = new PersonBusinessObject();
            var resList = bo.ListAsync().Result;
            var item = resList.Result.FirstOrDefault();
            item.FirstName = "another";
            var resUpdate = bo.UpdateAsync(item).Result;
            resList = bo.ListUnDeletedAsync().Result;
            Assert.IsTrue(resList.Success && resUpdate.Success && resList.Result.First().FirstName == "another");
        }

        [TestMethod]
        public void TestDeletePersonAsync()
        {
            RestaurantSeeder.SeedCountries();
            var bo = new PersonBusinessObject();
            var resList = bo.ListAsync().Result;
            var resDelete = bo.DeleteAsync(resList.Result.First().Id).Result;
            resList = bo.ListUnDeletedAsync().Result;
            Assert.IsTrue(resDelete.Success && resList.Success && resList.Result.Count == 0);
        }
    }
}
