using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace I4DAB_LAB2
{


    public class AppDbContext : DbContext
    {    
        // Initialize models
        private DbSet<Dish> Dishes {get; set;}
        private DbSet<Guest> Guests {get; set;}
        private DbSet<Person> People {get; set;}
        private DbSet<Restaurant> Restaurants { get; set;}
        private DbSet<Review> Reviews {get; set;}
        private DbSet<Table> Tables {get; set;}

        // Connection strings
        string MikkelsCString = "Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=I4DAB_LAB2;Data Source=DESKTOP-9NFPK3F";
        string MortensCString = "Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=I4DAB_LAB2;DataSource=DESKTOP-CKBOQBP";

        // Configur SQL server
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            optionsBuilder.UseSqlServer(MikkelsCString);    // Husk at ændre din ConnectionString
        }

        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Set Primary Key(s)
            modelBuilder.Entity<Restaurant>()
                .HasKey(c => c.Address);

            // Set Relationship(s)
            modelBuilder.Entity<Restaurant>()
                .HasMany(rev => rev.Reviews)
                .WithOne(res => res.Restaurant);
        }
    }
}
