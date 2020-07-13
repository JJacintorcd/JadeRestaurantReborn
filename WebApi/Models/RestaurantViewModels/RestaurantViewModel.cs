using Recodme.Rd.JadeRest.DataLayer.RestaurantData;
using System;

namespace Recodme.Rd.JadeRest.WebApi.Models.RestaurantViewModels
{
    public class RestaurantViewModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string OpeningHours { get; set; }
        public string ClosingHours { get; set; }
        public string ClosingDays { get; set; }
        public int TableCount { get; set; }

        public Restaurant ToRestaurant()
        {
            return new Restaurant(Name, Address, OpeningHours, ClosingHours, ClosingDays, TableCount);
        }

        public static RestaurantViewModel Parse(Restaurant Restaurant)
        {
            return new RestaurantViewModel()
            {
                Id = Restaurant.Id,
                Name = Restaurant.Name,
                Address = Restaurant.Address,
                OpeningHours = Restaurant.OpeningHours,
                ClosingHours = Restaurant.ClosingHours,
                ClosingDays = Restaurant.ClosingDays,
                TableCount = Restaurant.TableCount
            };

        }
    }
}
