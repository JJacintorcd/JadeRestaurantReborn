using Recodme.Rd.JadeRest.DataLayer.Base;
using Recodme.Rd.JadeRest.DataLayer.UserData;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Recodme.Rd.JadeRest.DataLayer.RestaurantData
{
    public class StaffTitle : Entity
    {
        private DateTime _startDate;

        [Required]
        [Display(Name = "Start Date")]
        public DateTime StartDate
        {
            get => _startDate;

            set
            {
                _startDate = value;
                RegisterChange();
            }
        }

        private DateTime _endDate;

        [Required]
        [Display(Name = "End Date")]
        public DateTime EndDate
        {
            get => _endDate;

            set
            {
                _endDate = value;
                RegisterChange();
            }
        }

        [ForeignKey("Title")]
        public Guid TitleId { get; set; }
        public virtual Title Title { get; set; }

        [ForeignKey("StaffRecord")]
        public Guid StaffRecordId { get; set; }
        public virtual StaffRecord StaffRecord { get; set; }

        public StaffTitle(DateTime startDate, DateTime endDate, Guid titleId, Guid staffRecordId)
        {
            _startDate = startDate;
            _endDate = endDate;
            TitleId = titleId;
            StaffRecordId = staffRecordId;

        }
        public StaffTitle(Guid id, DateTime createdAt, DateTime updatedAt, bool isDeleted, DateTime startDate, DateTime endDate, Guid titleId, Guid staffRecordId) : base(id, createdAt, updatedAt, isDeleted)
        {
            _startDate = startDate;
            _endDate = endDate;
            TitleId = titleId;
            StaffRecordId = staffRecordId;
        }

    }

}
