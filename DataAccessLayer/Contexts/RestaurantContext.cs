using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using vRecodme.Rd.JadeRest.DataAccessLayer.DAObjects.MenuDAO.Properties;
using Recodme.Rd.JadeRest.DataLayer.MenuData;
using System;
using System.Collections.Generic;
using System.Text;
using Recodme.Rd.JadeRest.DataLayer.UserData;

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

        //protected override void OnModelCreating(ModelBuilder builder)
        //{
        //    builder.Entity<Person>().HasOne(x => x.JadeUser).WithOne(x => x.Person);
        //    base.OnModelCreating(builder);

        //}

        public DbSet<DietaryRestriction> DietaryRestrictions { get; set; }
        public DbSet<Person> People { get; set; }
        public DbSet<ClientRecord> ClientRecords { get; set; }
        public DbSet<StaffRecord> StaffRecords { get; set; }

    }
}
