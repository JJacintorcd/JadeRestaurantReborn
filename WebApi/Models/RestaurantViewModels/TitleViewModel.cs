using Recodme.Rd.JadeRest.DataLayer.RestaurantData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Recodme.Rd.JadeRest.WebApi.Models.RestaurantViewModels
{
    public class TitleViewModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Position { get; set; }
        public string Description { get; set; }

        public Title ToTitle()
        {
            return new Title(Name, Position, Description);
        }

        public static TitleViewModel Parse(Title Title)
        {
            return new TitleViewModel()
            {
                Id = Title.Id,
                Name = Title.Name,
                Position = Title.Position,
                Description = Title.Description
            };

        }
    }
}
