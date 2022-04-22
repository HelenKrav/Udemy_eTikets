using Microsoft.EntityFrameworkCore;
using Udemy_eTikets.Models;

namespace Udemy_eTikets.Data
{
    public class AppDbContext: DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options): base(options)  //предполагает передачу в конструктор базового класса объекта DbContextOptions, который инкапсулирует параметры конфигурации.
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
           
            modelBuilder.Entity<Actor_Movie>().HasKey(am=>  new 
            { 
                am.MovieId, 
                am.ActorId 
            });

            modelBuilder.Entity<Actor_Movie>().HasOne(m=> m.Movie)
                                              .WithMany(am => am.Actors_Movies)
                                              .HasForeignKey(am=>am.MovieId);

            modelBuilder.Entity<Actor_Movie>().HasOne(a => a.Actor)
                .WithMany(a => a.Actors_Movies)
                .HasForeignKey(am => am.ActorId);
          
            
            base.OnModelCreating(modelBuilder);
        }

        
        public DbSet<Actor> Actors { get; set; }
        public DbSet<Producer> Producers { get; set; }
        public DbSet<Cinema> Cinemas { get; set; }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Actor_Movie> Actors_Movies { get; set; }



        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
    }
}
