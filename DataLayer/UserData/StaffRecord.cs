using Recodme.Rd.JadeRest.DataLayer.Base;
using Recodme.Rd.JadeRest.DataLayer.RestaurantData;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Recodme.Rd.JadeRest.DataLayer.UserData
{
    public class StaffRecord : Entity
    {
        private DateTime _beginDate;

        [Required]
        [Display(Name = "Begin Date")]
        public DateTime BeginDate
        {
            get => _beginDate;

            set
            {
                _beginDate = value;
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

        [ForeignKey("Person")]
        public Guid PersonId { get; set; }
        public virtual Person Person { get; set; }

        [ForeignKey("Restaurant")]
        public Guid RestaurantId { get; set; }
        public virtual Restaurant Restaurant { get; set; }

        public virtual ICollection<StaffTitle> StaffTitles { get; set; }



        public StaffRecord(DateTime beginDate, DateTime endDate, Guid personId, Guid restaurantId)
        {
            _beginDate = beginDate;
            _endDate = endDate;
            PersonId = personId;
            RestaurantId = restaurantId;
        }

        public StaffRecord(Guid id, DateTime createdAt, DateTime updatedAt, bool isDeleted, DateTime beginDate, DateTime endDate, Guid personId, Guid restaurantId) : base(id, createdAt, updatedAt, isDeleted)
        {
            _beginDate = beginDate;
            _endDate = endDate;
            PersonId = personId;
            RestaurantId = restaurantId;
        }
    }
}
