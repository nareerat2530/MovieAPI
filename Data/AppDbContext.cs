using Microsoft.EntityFrameworkCore;
using MovieProject.Models;

namespace MovieProject.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ActorMovie>()
                .HasKey(am => new { am.ActorId, am.MovieId });
            modelBuilder.Entity<ActorMovie>()
                .HasOne(am => am.Actor)
                .WithMany(a => a.ActorMovies)
                .HasForeignKey(am => am.ActorId);
            modelBuilder.Entity<ActorMovie>()
                .HasOne(am => am.Movie)
                .WithMany(a => a.ActorMovies)
                .HasForeignKey(am => am.MovieId);
        }
        public DbSet<Actor> Actors { get; set; }
        public DbSet<Cinema> Cinemas { get; set; }
        public DbSet<Producer> Producers { get; set; }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<ActorMovie> ActorMovies { get; set; }
    }
}
