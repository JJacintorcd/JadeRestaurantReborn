using Recodme.Rd.JadeRest.DataLayer.RestaurantData;
using System;

namespace Recodme.Rd.JadeRest.WebApi.Models.RestaurantViewModels
{
    public class StaffTitleViewModel
    {
        public Guid Id { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public Guid TitleId { get; set; }
        public Guid StaffRecordId { get; set; }

        public StaffTitle ToStaffTitle()
        {
            return new StaffTitle(StartDate, EndDate, TitleId, StaffRecordId);
        }

        public static StaffTitleViewModel Parse(StaffTitle StaffTitle)
        {
            return new StaffTitleViewModel()
            {
                Id = StaffTitle.Id,
                StartDate = StaffTitle.StartDate,
                EndDate = StaffTitle.EndDate,
                TitleId = StaffTitle.TitleId,
                StaffRecordId = StaffTitle.StaffRecordId
            };

        }
    }
}
