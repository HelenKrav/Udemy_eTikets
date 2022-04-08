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

           
            
            
            //modelBuilder.Entity<Movie>().HasKey(m => new
            //{
            //    m.CinemaId,
            //    m.ProducerId
            //});

            //modelBuilder.Entity<Movie>().HasOne(p=>p.Producer)
            //                            .WithMany(m=>m.Movies)
            //                            .HasForeignKey(m=>m.ProducerId);

            //modelBuilder.Entity<Movie>().HasOne(c=>c.Cinema)
            //                            .WithMany(m=>m.Movies)
            //                            .HasForeignKey(m=>m.CinemaId);

            
            
            base.OnModelCreating(modelBuilder);
        }

        
        public DbSet<Actor> Actors { get; set; }
        public DbSet<Producer> Producers { get; set; }
        public DbSet<Cinema> Cinemas { get; set; }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Actor_Movie> Actors_Movies { get; set; }
    }
}
