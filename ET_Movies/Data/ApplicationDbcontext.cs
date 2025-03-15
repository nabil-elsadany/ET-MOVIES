using ET_Movies.Models;
using Microsoft.EntityFrameworkCore;

namespace ET_Movies.Data
{
    public class ApplicationDbcontext : DbContext
    {
        public ApplicationDbcontext(DbContextOptions<ApplicationDbcontext> options) : base(options)
        {

        }

        public ApplicationDbcontext()
        {
        }
        public DbSet<Movies> Movies { get; set; }
        public DbSet<Cinemas> Cinemas { get; set; }
        public DbSet<Categories> Categories { get; set; }
        public DbSet<Actors> Actors { get; set; }
        public DbSet<OrderItems> OrderItems { get; set; }
        public DbSet<ActorMovies> ActorMovies { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            optionsBuilder.UseSqlServer("Data Source=.;Initial Catalog=ET_Movies;Integrated Security=True;TrustServerCertificate=True");


        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<ActorMovies>()
                  .HasKey(e => new { e.ActorsId, e.MoviesId });

            modelBuilder.Entity<ActorMovies>()
                .HasOne(e => e.Actor)
                .WithMany(e => e.ActorMovies)  
                .HasForeignKey(e => e.ActorsId);

            modelBuilder.Entity<ActorMovies>()
                .HasOne(e => e.Movie)
                .WithMany(e => e.ActorMovies)  
                .HasForeignKey(e => e.MoviesId);

           
            modelBuilder.Entity<Movies>()
                .Property(m => m.MovieStatus)
                .HasConversion<int>();
        }
    }
}
