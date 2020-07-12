using Microsoft.VisualStudio.TestTools.UnitTesting;
using Recodme.Rd.JadeRest.BusinessLayer.BObjects.RestaurantBO;
using Recodme.Rd.JadeRest.DataAccessLayer.Seeders;
using Recodme.Rd.JadeRest.DataLayer.RestaurantData;
using System.Linq;

namespace JadeTests.TestsAsync
{
    [TestClass]
    public class RestaurantAsyncTests
    {
        [TestMethod]
        public void TestCreateAndReadRestaurantAsync()
        {
            RestaurantSeeder.SeedCountries();
            var bo = new RestaurantBusinessObject();
            var rt = new Restaurant("Jade", "Avenida da Liberdade antes da rotunda", "13h00", "23h00", "monday", 24);
            var resCreate = bo.CreateAsync(rt).Result;
            var resGet = bo.ReadAsync(rt.Id).Result;
            Assert.IsTrue(resCreate.Success && resGet.Success && resGet.Result != null);
        }

        [TestMethod]
        public void TestListRestaurantAsync()
        {
            RestaurantSeeder.SeedCountries();
            var bo = new RestaurantBusinessObject();
            var resList = bo.ListAsync().Result;
            Assert.IsTrue(resList.Success && resList.Result.Count == 1);
        }

        [TestMethod]
        public void TestUpdateRestaurantAsync()
        {
            RestaurantSeeder.SeedCountries();
            var bo = new RestaurantBusinessObject();
            var resList = bo.ListAsync().Result;
            var item = resList.Result.FirstOrDefault();
            item.OpeningHours = "9h00";
            var resUpdate = bo.UpdateAsync(item).Result;
            resList = bo.ListUnDeletedAsync().Result;
            Assert.IsTrue(resList.Success && resUpdate.Success && resList.Result.First().OpeningHours == "9h00");
        }

        [TestMethod]
        public void TestDeleteRestaurantAsync()
        {
            RestaurantSeeder.SeedCountries();
            var bo = new RestaurantBusinessObject();
            var resList = bo.ListAsync().Result;
            var resDelete = bo.DeleteAsync(resList.Result.First().Id).Result;
            resList = bo.ListUnDeletedAsync().Result;
            Assert.IsTrue(resDelete.Success && resList.Success && resList.Result.Count == 0);
        }
    }
}
