using Microsoft.VisualStudio.TestTools.UnitTesting;
using Recodme.Rd.JadeRest.BusinessLayer.BObjects.MenuBO;
using vRecodme.Rd.JadeRest.DataAccessLayer.DAObjects.MenuDAO.Seeders;
using Recodme.Rd.JadeRest.DataLayer;
using Recodme.Rd.JadeRest.DataLayer.MenuData;
using System.Linq;

namespace JadeTests
{
    [TestClass]
    public class DietaryRestrictionTests
    {
        [TestMethod]
        public void TestCreateAndReadDietaryRestriction()
        {
            RestaurantSeeder.SeedCountries();
            var bo = new DietaryRestrictionBusinessObject();
            var dr = new DietaryRestriction("Vegetarian");
            var resCreate = bo.Create(dr);
            var resGet = bo.Read(dr.Id);
            Assert.IsTrue(resCreate.Success && resGet.Success && resGet.Result != null);
        }
        
        [TestMethod]
        public void TestListDietaryRestriction()
        {
            RestaurantSeeder.SeedCountries();
            var bo = new DietaryRestrictionBusinessObject();
            var resList = bo.List();
            Assert.IsTrue(resList.Success && resList.Result.Count == 1);
        }
        
        [TestMethod]
        public void TestUpdateDietaryRestriction()
        {
            RestaurantSeeder.SeedCountries();
            var bo = new DietaryRestrictionBusinessObject();
            var resList = bo.List();
            var item = resList.Result.FirstOrDefault();
            item.Name = "another";
            var resUpdate = bo.Update(item);
            var resNotList = bo.List().Result.Where(x => !x.IsDeleted);
            Assert.IsTrue(resUpdate.Success && resNotList.First().Name == "another");
        }
        
        [TestMethod]
        public void TestDeleteDietaryRestriction()
        {
            RestaurantSeeder.SeedCountries();
            var bo = new DietaryRestrictionBusinessObject();
            var resList = bo.List();
            var resDelete = bo.Delete(resList.Result.First().Id);
            var resNotList = bo.List().Result.Where(x => !x.IsDeleted).ToList();
            Assert.IsTrue(resDelete.Success && resNotList.Count == 0);
        }
    }
}
