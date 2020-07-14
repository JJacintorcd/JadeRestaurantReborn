using Microsoft.VisualStudio.TestTools.UnitTesting;
using Recodme.Rd.JadeRest.BusinessLayer.BObjects.RestaurantBO;
using Recodme.Rd.JadeRest.BusinessLayer.BObjects.UserBO;
using Recodme.Rd.JadeRest.DataAccessLayer.Seeders;
using Recodme.Rd.JadeRest.DataLayer.RestaurantData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JadeTests.TestsAsync
{
    [TestClass]
    public class BookingAsyncTests
    {
        [TestMethod]
        public void TestCreateAndReadBookingAsync()
        {
            RestaurantSeeder.SeedCountries();
            var bo = new BookingBusinessObject();
            var boForeign = new ClientRecordBusinessObject();

            var booking = new Booking(DateTime.Parse("2015/04/04"), boForeign.List().Result.First().Id);

            var resCreate = bo.CreateAsync(booking).Result;
            var resGet = bo.ReadAsync(booking.Id).Result;
            Assert.IsTrue(resCreate.Success && resGet.Success && resGet.Result != null);
        }

        [TestMethod]
        public void TestListBookingAsync()
        {
            RestaurantSeeder.SeedCountries();
            var bo = new BookingBusinessObject();
            var resList = bo.ListAsync().Result;
            Assert.IsTrue(resList.Success && resList.Result.Count == 1);
        }

        [TestMethod]
        public void TestUpdateBookingAsync()
        {
            RestaurantSeeder.SeedCountries();
            var bo = new BookingBusinessObject();
            var resList = bo.ListAsync().Result;
            var item = resList.Result.FirstOrDefault();
            item.Date = DateTime.Parse("2015/04/06");
            var resUpdate = bo.UpdateAsync(item).Result;
            var resNotList = bo.ListUnDeletedAsync().Result;
            Assert.IsTrue(resUpdate.Success && resNotList.Result.First().Date == DateTime.Parse("2015/04/06"));
        }

        [TestMethod]
        public void TestDeleteBookingAsync()
        {
            RestaurantSeeder.SeedCountries();
            var bo = new BookingBusinessObject();
            var resList = bo.ListAsync().Result;
            var resDelete = bo.DeleteAsync(resList.Result.First().Id).Result;
            var resNotList = bo.ListUnDeletedAsync().Result;
            Assert.IsTrue(resDelete.Success && resNotList.Result.Count == 0);
        }
    }
}
