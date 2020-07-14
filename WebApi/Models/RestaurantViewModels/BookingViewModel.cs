using Recodme.Rd.JadeRest.DataLayer.RestaurantData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Recodme.Rd.JadeRest.WebApi.Models.RestaurantViewModels
{
    public class BookingViewModel
    {
        public Guid Id { get; set; }
        public DateTime Date { get; set; }
        public Guid ClientRecordId { get; set; }

        public Booking ToBooking()
        {
            return new Booking(Date, ClientRecordId);
        }

        public static BookingViewModel Parse(Booking booking)
        {
            return new BookingViewModel()
            {
                Id = booking.Id,
                Date = booking.Date,
                ClientRecordId = booking.ClientRecordId
            };
        }
    }
}