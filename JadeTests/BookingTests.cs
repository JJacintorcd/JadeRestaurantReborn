using Microsoft.VisualStudio.TestTools.UnitTesting;
using Recodme.Rd.JadeRest.BusinessLayer.BObjects.RestaurantBO;
using Recodme.Rd.JadeRest.BusinessLayer.BObjects.UserBO;
using Recodme.Rd.JadeRest.DataAccessLayer.Seeders;
using Recodme.Rd.JadeRest.DataLayer.RestaurantData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JadeTests
{
    [TestClass]
    public class BookingTests
    {
        [TestMethod]
        public void TestCreateAndReadBooking()
        {
            RestaurantSeeder.SeedCountries();
            var bo = new BookingBusinessObject();
            var boForeign = new ClientRecordBusinessObject();

            var booking = new Booking(DateTime.Parse("2015/04/04"), boForeign.List().Result.First().Id);

            var resCreate = bo.Create(booking);
            var resGet = bo.Read(booking.Id);
            Assert.IsTrue(resCreate.Success && resGet.Success && resGet.Result != null);
        }

        [TestMethod]
        public void TestListBooking()
        {
            RestaurantSeeder.SeedCountries();
            var bo = new BookingBusinessObject();
            var resList = bo.List();
            Assert.IsTrue(resList.Success && resList.Result.Count == 1);
        }

        [TestMethod]
        public void TestUpdateBooking()
        {
            RestaurantSeeder.SeedCountries();
            var bo = new BookingBusinessObject();
            var resList = bo.List();
            var item = resList.Result.FirstOrDefault();
            item.Date = DateTime.Parse("2015/04/06");
            var resUpdate = bo.Update(item);
            var resNotList = bo.List().Result.Where(x => !x.IsDeleted);
            Assert.IsTrue(resUpdate.Success && resNotList.First().Date == DateTime.Parse("2015/04/06"));
        }

        [TestMethod]
        public void TestDeleteBooking()
        {
            RestaurantSeeder.SeedCountries();
            var bo = new BookingBusinessObject();
            var resList = bo.List();
            var resDelete = bo.Delete(resList.Result.First().Id);
            var resNotList = bo.List().Result.Where(x => !x.IsDeleted).ToList();
            Assert.IsTrue(resDelete.Success && resNotList.Count == 0);
        }
    }
}
