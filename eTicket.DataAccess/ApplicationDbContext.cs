using eTicket.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace eTicket.DataAccess
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<MovieActor>().HasKey(k => new {k.MovieID, k.ActorID});

            builder.Entity<MovieActor>()
                .HasOne(m => m.Movie)
                .WithMany(m => m.MovieActors)
                .HasForeignKey(m => m.MovieID);

            builder.Entity<MovieActor>()
                .HasOne(m => m.Actor)
                .WithMany(m => m.MovieActors)
                .HasForeignKey(m => m.ActorID);
        }

        public virtual DbSet<Movie> Movies { get; set; }
        public virtual DbSet<Actor> Actors { get; set; }
        public virtual DbSet<MovieActor> MovieActors { get; set; }
        public virtual DbSet<Producer> Producers  { get; set; }
        public virtual DbSet<Cinema> Cinemas { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<OrderItem> OrderItems { get; set; }
        public virtual DbSet<ShoppingCartItem> ShoppingCartItems { get; set; }
    }
}