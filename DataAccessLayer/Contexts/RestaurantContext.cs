using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using vRecodme.Rd.JadeRest.DataAccessLayer.DAObjects.MenuDAO.Properties;
using Recodme.Rd.JadeRest.DataLayer.MenuData;
using System;
using System.Collections.Generic;
using System.Text;

namespace vRecodme.Rd.JadeRest.DataAccessLayer.DAObjects.MenuDAO.Contexts
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
