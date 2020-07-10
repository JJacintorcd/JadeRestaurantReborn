using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Recodme.Rd.JadeRest.DataAccessLayer.Properties;
using Recodme.Rd.JadeRest.DataLayer;
using System;
using System.Collections.Generic;
using System.Text;

namespace Recodme.Rd.JadeRest.DataAccessLayer.Contexts
{
    public class RestaurantContext : IdentityDbContext
    {
        public RestaurantContext() : base()
        {

        }

        public RestaurantContext(DbContextOptions<RestaurantContext> options) : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(Resources.ConnectionString);

            }

        }

        public DbSet<DietaryRestriction> DietaryRestrictions { get; set; }
    }
}
