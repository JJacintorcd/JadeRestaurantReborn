using Recodme.Rd.JadeRest.DataLayer.MenuData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Recodme.Rd.JadeRest.WebApi.Models.MenuViewModels
{
    public class DishViewModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public Guid DietaryRestrictionId { get; set; }

        public Dish ToDish()
        {
            return new Dish(Name, DietaryRestrictionId);
        }

        public static DishViewModel Parse(Dish dish)
        {
            return new DishViewModel()
            {
                Id = dish.Id,
                Name = dish.Name,
                DietaryRestrictionId = dish.DietaryRestrictionId
            };
        }
    }
}