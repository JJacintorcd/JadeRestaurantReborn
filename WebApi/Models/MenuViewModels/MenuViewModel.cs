using Recodme.Rd.JadeRest.DataLayer.MenuData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Recodme.Rd.JadeRest.WebApi.Models.MenuViewModels
{
    public class MenuViewModel
    {
        public Guid Id { get; set; }
        public DateTime Date { get; set; }
        public Guid MealId { get; set; }
        public Guid RestaurantId { get; set; }


        public Menu ToMenu()
        {
            return new Menu(DateTime.UtcNow, MealId, RestaurantId);
        }

        public static MenuViewModel Parse(Menu menu)
        {
            return new MenuViewModel()
            {
                Id = menu.Id,
                Date = menu.Date,
                MealId = menu.MealId,
                RestaurantId = menu.RestaurantId
            };
        }
    }
}
