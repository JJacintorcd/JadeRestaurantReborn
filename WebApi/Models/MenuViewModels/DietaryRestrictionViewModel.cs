using Recodme.Rd.JadeRest.DataLayer;
using Recodme.Rd.JadeRest.DataLayer.MenuData;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Recodme.Rd.JadeRest.WebApi.Models.MenuViewModels
{
    public class DietaryRestrictionViewModel
    {
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Input your name")]
        [MaxLength(10, ErrorMessage = "No more than 10 char")]
        public string Name { get; set; }

        public DietaryRestriction ToDietaryRestriction()
        {
            return new DietaryRestriction(Name);
        }

        public static DietaryRestrictionViewModel Parse(DietaryRestriction dietaryRestriction)
        {
            return new DietaryRestrictionViewModel()
            {
                Id = dietaryRestriction.Id,
                Name = dietaryRestriction.Name
            };
        }
    }
}
