using Microsoft.EntityFrameworkCore;
using TicketsForMovies.Models;

namespace TicketsForMovies.Data
{
    /*
     * Responsibilities of DbContext:
     * 1. Database Connection: Manages the connection to the database.
     * 2. Querying: Provides methods to query the database using LINQ.
     * 3. CRUD Operations: Facilitates Create, Read, Update, and Delete operations on the database.
     * 4. Change Tracking: Keeps track of changes made to objects so that they can be persisted to the database.
     * 5. Transaction Management: Provides a way to manage transactions.
     * 6. Model Configuration: Configures the model (database schema) using Fluent API or data annotations.
     */

    // Define your DbContext
    public class AppDbContext : DbContext
    {
        // Define DbSet properties for each entity set
        public DbSet<Actor> Actors { get; set; }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Actor_Movie> Actors_Movies { get; set; }
        public DbSet<Cinema> Cinemas { get; set; }
        public DbSet<Producer> Producers { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        // Configure the connection string or other options
        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer("YourConnectionStringHere");
        //}

        // Customize the model with Fluent API if needed
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Use Fluent API to configure the model
            modelBuilder.Entity<Actor_Movie>().HasKey(am => new { am.ActorId, am.MovieId });

            modelBuilder.Entity<Actor_Movie>().HasOne(m => m.Movie).WithMany(am => am.Actors_Movies)
                .HasForeignKey(am => am.MovieId);
            modelBuilder.Entity<Actor_Movie>().HasOne(m => m.Actor).WithMany(am => am.Actors_Movies)
                .HasForeignKey(m => m.ActorId);

            base.OnModelCreating(modelBuilder);
        }
    }
}
