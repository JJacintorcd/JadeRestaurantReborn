using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Recodme.Rd.JadeRest.DataLayer.MenuData;
using Recodme.Rd.JadeRest.DataLayer.UserData;
using Recodme.Rd.JadeRest.DataAccessLayer.Properties;
using Recodme.Rd.JadeRest.DataLayer.RestaurantData;

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

        //protected override void OnModelCreating(ModelBuilder builder)
        //{
        //    builder.Entity<Person>().HasOne(x => x.JadeUser).WithOne(x => x.Person);
        //    base.OnModelCreating(builder);

        //}

        public DbSet<DietaryRestriction> DietaryRestrictions { get; set; }
        public DbSet<Person> People { get; set; }
        public DbSet<ClientRecord> ClientRecords { get; set; }
        public DbSet<StaffRecord> StaffRecords { get; set; }
        public DbSet<Restaurant> Restaurants { get; set; }
        public DbSet<Title> Titles { get; set; }
        public DbSet<StaffTitle> StaffTitles { get; set; }

    }
}
