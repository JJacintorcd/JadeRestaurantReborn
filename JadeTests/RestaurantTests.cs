using Microsoft.VisualStudio.TestTools.UnitTesting;
using Recodme.Rd.JadeRest.BusinessLayer.BObjects.RestaurantBO;
using Recodme.Rd.JadeRest.DataAccessLayer.Seeders;
using Recodme.Rd.JadeRest.DataLayer.RestaurantData;
using System.Linq;

namespace JadeTests
{
    [TestClass]
    public class RestaurantTests
    {
        [TestMethod]
        public void TestCreateAndReadRestaurant()
        {
            RestaurantSeeder.SeedCountries();
            var bo = new RestaurantBusinessObject();
            var dr = new Restaurant("Jade", "Avenida da Liberdade antes da rotunda", "13h00", "23h00", "monday", 24);
            var resCreate = bo.Create(dr);
            var resGet = bo.Read(dr.Id);
            Assert.IsTrue(resCreate.Success && resGet.Success && resGet.Result != null);
        }

        [TestMethod]
        public void TestListRestaurant()
        {
            RestaurantSeeder.SeedCountries();
            var bo = new RestaurantBusinessObject();
            var resList = bo.List();
            Assert.IsTrue(resList.Success && resList.Result.Count == 1);
        }

        [TestMethod]
        public void TestUpdateRestaurant()
        {
            RestaurantSeeder.SeedCountries();
            var bo = new RestaurantBusinessObject();
            var resList = bo.List();
            var item = resList.Result.FirstOrDefault();
            item.OpeningHours = "9h00";
            var resUpdate = bo.Update(item);
            var resNotList = bo.List().Result.Where(x => !x.IsDeleted);
            Assert.IsTrue(resUpdate.Success && resNotList.First().OpeningHours == "9h00");
        }

        [TestMethod]
        public void TestDeleteRestaurant()
        {
            RestaurantSeeder.SeedCountries();
            var bo = new RestaurantBusinessObject();
            var resList = bo.List();
            var resDelete = bo.Delete(resList.Result.First().Id);
            var resNotList = bo.List().Result.Where(x => !x.IsDeleted).ToList();
            Assert.IsTrue(resDelete.Success && resNotList.Count == 0);
        }
    }
}
