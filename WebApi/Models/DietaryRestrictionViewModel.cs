using Recodme.Rd.JadeRest.DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Recodme.Rd.JadeRest.WebApi.Models
{
    public class DietaryRestrictionViewModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        public DietaryRestriction ToDietaryRestriction()
        {
            return new DietaryRestriction(Id, DateTime.UtcNow, DateTime.UtcNow, false, Name);
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
