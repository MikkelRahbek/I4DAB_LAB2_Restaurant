using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Threading.Tasks;
using I4DAB_LAB2.Models;
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
        private DbSet<Waiter> Waiters { get; set; }
        private DbSet<RestaurantDish> RestaurantDishes { get; set; }
        private DbSet<GuestDish> GuestDishes { get; set; }
        private DbSet<WaiterTable> WaiterTables { get; set; }

        // Connection strings
        string MikkelsCString = "Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=I4DAB_LAB2;Data Source=DESKTOP-9NFPK3F";
        string MortensCString = "Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=I4DAB_LAB2;DataSource=DESKTOP-CKBOQBP";

        // Configure SQL server
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            optionsBuilder.UseSqlServer(MikkelsCString);    // Husk at ændre din ConnectionString
        }

        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            /* Set Primary Key(s) */
            modelBuilder.Entity<Restaurant>()
                .HasKey(res => res.Address);
            modelBuilder.Entity<Dish>()
                .HasKey(d => d.Id);
            modelBuilder.Entity<Guest>()
                .HasKey(g => g.Id);
            modelBuilder.Entity<Person>()
                .HasKey(p => p.Name);
            modelBuilder.Entity<Review>()
                .HasKey(r =>  r.Text);
            modelBuilder.Entity<Table>()
                .HasKey(t => t.Number);
            modelBuilder.Entity<Waiter>()
                .HasKey(w => w.Id); 
            modelBuilder.Entity<RestaurantDish>()
                .HasKey(rd => new {rd.RestaurantId, rd.DishId});
            modelBuilder.Entity<GuestDish>()
                .HasKey(gd => new {gd.DishId, gd.GuestId});
            modelBuilder.Entity<WaiterTable>()
                .HasKey(wt => new {wt.TableId, wt.WaiterId});

            /* Set Relationship(s) */
            // Restaurant One-Many Review
            modelBuilder.Entity<Review>()
                .HasOne(rev => rev.Restaurant)
                .WithMany(res => res.Reviews)
                .HasForeignKey(rev => rev.RestaurantId);

            // Restaurant Many-Many Dish
            modelBuilder.Entity<RestaurantDish>()
                .HasOne(rd => rd.Dish)
                .WithMany(d => d.RestaurantDishes)
                .HasForeignKey(rd => rd.DishId);
            modelBuilder.Entity<RestaurantDish>()
                .HasOne(rd => rd.Restaurant)
                .WithMany(res => res.RestaurantDishes)
                .HasForeignKey(rd => rd.RestaurantId);

            // Restaurant One-Many Table
            modelBuilder.Entity<Table>()
                .HasOne(t => t.Restaurant)
                .WithMany(res => res.Tables)
                .HasForeignKey(t => t.RestaurantId);

            // Review One-Many Dish
            modelBuilder.Entity<Dish>()
                .HasOne(d => d.Review)
                .WithMany(rev => rev.Dishes)
                .HasForeignKey(d => d.ReviewId);

            // Review One-Many Guest
            modelBuilder.Entity<Guest>()
                .HasOne(g => g.Review)
                .WithMany(rev => rev.Guests)
                .HasForeignKey(g => g.ReviewId);

            // Guest Many-Many Dish
            modelBuilder.Entity<GuestDish>()
                .HasOne(gd => gd.Dish)
                .WithMany(d => d.GuestDishes)
                .HasForeignKey(gd => gd.DishId);
            modelBuilder.Entity<GuestDish>()
                .HasOne(gd => gd.Guest)
                .WithMany(g => g.GuestDishes)
                .HasForeignKey(gd => gd.GuestId);

            // Guest One-One Person
            modelBuilder.Entity<Person>()
                .HasOne(p => p.Guest)
                .WithOne(g => g.Person)
                .HasForeignKey<Guest>();
            
            // Table One-Many Guest
            modelBuilder.Entity<Guest>()
                .HasOne(g => g.Table)
                .WithMany(t => t.Guests)
                .HasForeignKey(g => g.TableId);

            // Table Many-Many Waiter 
            modelBuilder.Entity<WaiterTable>()
                .HasOne(wt => wt.Table)
                .WithMany(t => t.WaiterTables)
                .HasForeignKey(wt => wt.TableId);
            modelBuilder.Entity<WaiterTable>()
                .HasOne(wt => wt.Waiter)
                .WithMany(w => w.WaiterTables)
                .HasForeignKey(wt => wt.WaiterId);

            // Waiter One-One Person
            modelBuilder.Entity<Person>()
                .HasOne(p => p.Waiter)
                .WithOne(w => w.Person)
                .HasForeignKey<Waiter>();
        }
    }
}
