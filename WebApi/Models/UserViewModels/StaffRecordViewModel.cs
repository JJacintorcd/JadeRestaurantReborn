using Recodme.Rd.JadeRest.DataLayer.UserData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Recodme.Rd.JadeRest.WebApi.Models.UserViewModels
{
    public class StaffRecordViewModel
    {
        public Guid Id { get; set; }
        public Guid PersonId { get; set; }
        public Guid RestaurantId { get; set; }
        public DateTime BeginDate { get; set; }
        public DateTime EndDate { get; set; }

        public StaffRecord ToStaff()
        {
            return new StaffRecord(BeginDate, EndDate, PersonId, RestaurantId);

        }

        public static StaffRecordViewModel Parse(StaffRecord Staff)
        {
            return new StaffRecordViewModel()
            {
                Id = Staff.Id,
                PersonId = Staff.PersonId,
                RestaurantId = Staff.RestaurantId,
                BeginDate = Staff.BeginDate,
                EndDate = Staff.EndDate

            };

        }
    }
}
