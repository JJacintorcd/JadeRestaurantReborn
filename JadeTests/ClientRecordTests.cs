using Microsoft.VisualStudio.TestTools.UnitTesting;
using Recodme.Rd.JadeRest.BusinessLayer.BObjects.MenuBO.BObjects.UserBO;
using Recodme.Rd.JadeRest.DataLayer.UserData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Recodme.Rd.JadeRest.DataAccessLayer.DAObjects.MenuDAO.Seeders;

namespace JadeTests
{
    [TestClass]
    public class ClientRecordTests
    {
        [TestMethod]
        public void TestCreateAndReadClientRecord()
        {
            RestaurantSeeder.SeedCountries();
            var bo = new ClientRecordBusinessObject();
            var bop = new PersonBusinessObject();
            var personId = bop.List().Result.First();
            var dr = new ClientRecord(DateTime.Parse("2020/05/05"), personId.Id);
            var resCreate = bo.Create(dr);
            var resGet = bo.Read(dr.Id);
            Assert.IsTrue(resCreate.Success && resGet.Success && resGet.Result != null);
        }

        [TestMethod]
        public void TestListClientRecord()
        {
            RestaurantSeeder.SeedCountries();
            var bo = new ClientRecordBusinessObject();
            var resList = bo.List();
            Assert.IsTrue(resList.Success && resList.Result.Count == 1);
        }

        [TestMethod]
        public void TestUpdateClientRecord()
        {
            RestaurantSeeder.SeedCountries();
            var bo = new ClientRecordBusinessObject();
            var resList = bo.List();
            var item = resList.Result.FirstOrDefault();
            item.RegisterDate = DateTime.Parse("2020/05/05");
            var resUpdate = bo.Update(item);
            var resNotList = bo.List().Result.Where(x => !x.IsDeleted);
            Assert.IsTrue(resUpdate.Success && resNotList.First().RegisterDate == DateTime.Parse("2020/05/05"));
        }

        [TestMethod]
        public void TestDeleteClientRecord()
        {
            RestaurantSeeder.SeedCountries();
            var bo = new ClientRecordBusinessObject();
            var resList = bo.List();
            var resDelete = bo.Delete(resList.Result.First().Id);
            var resNotList = bo.List().Result.Where(x => !x.IsDeleted).ToList();
            Assert.IsTrue(resDelete.Success && resNotList.Count == 0);
        }
    }
}
