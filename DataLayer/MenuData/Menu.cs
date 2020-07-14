using Recodme.Rd.JadeRest.DataLayer.Base;
using Recodme.Rd.JadeRest.DataLayer.RestaurantData;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Recodme.Rd.JadeRest.DataLayer.MenuData
{
    public class Menu : Entity
    {
        private DateTime _date;

        [Required(ErrorMessage = "Required Attribute")]
        public DateTime Date
        {
            get => _date;
            set
            {
                _date = value;
                RegisterChange();
            }
        }

        [ForeignKey("Meal")]
        public Guid MealId { get; set; }
        public virtual Meal Meal { get; set; }

        [ForeignKey("Restaurant")]
        public Guid RestaurantId { get; set; }
        public virtual Restaurant Restaurant { get; set; }

        public virtual ICollection<Serving> Servings { get; set; }

        public Menu(DateTime date, Guid mealId, Guid restaurantId)
        {
            _date = date;
            MealId = mealId;
            RestaurantId = restaurantId;
        }

        public Menu(Guid id, DateTime createdAt, DateTime updatedAt, bool isDeleted, DateTime date, Guid mealId, Guid restaurantId) : base(id, createdAt, updatedAt, isDeleted)
        {
            _date = date;
            MealId = mealId;
            RestaurantId = restaurantId;
        }

    }
}
