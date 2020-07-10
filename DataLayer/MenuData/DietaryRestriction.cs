using Recodme.Rd.JadeRest.DataLayer.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Recodme.Rd.JadeRest.DataLayer.MenuData
{
    public class DietaryRestriction : NamedEntity
    {
        public DietaryRestriction(string name) : base(name)
        {
        }

        public DietaryRestriction(Guid id, DateTime createdAt, DateTime updatedAt, bool isDeleted, string name) : base(id, createdAt, updatedAt, isDeleted, name)
        {
        }
    }
}
