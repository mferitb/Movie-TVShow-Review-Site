using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;

namespace WebApplication1.Data
{
    public class AppDbContext : DbContext
    {

        public DbSet<Movie> Movies { get; set; }

        public DbSet<TVShow> TVShows { get; set; }

        public DbSet<User> Users { get; set; }

        public DbSet<Comment> Comments { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasKey(u => u.UserId); 

            modelBuilder.Entity<User>()
                .Property(u => u.Username)
                .IsRequired() 
                .HasMaxLength(100);

            modelBuilder.Entity<User>()
                .Property(u => u.Email)
                .IsRequired() 
                .HasMaxLength(255); 

            modelBuilder.Entity<User>()
                .Property(u => u.PasswordHash)
                .IsRequired();

            modelBuilder.Entity<Movie>()
                .HasKey(m => m.Id); 

            modelBuilder.Entity<Movie>()
                .Property(m => m.Title)
                .IsRequired() 
                .HasMaxLength(200); 

            modelBuilder.Entity<Movie>()
                .Property(m => m.Description)
                .HasMaxLength(1000);

            modelBuilder.Entity<Movie>()
                .Property(m => m.PosterUrl)
                .HasMaxLength(500);

            modelBuilder.Entity<Movie>()
                .Property(m => m.Rating)
                .IsRequired(); 

            modelBuilder.Entity<TVShow>()
                .HasKey(tv => tv.Id);

            modelBuilder.Entity<TVShow>()
                .Property(tv => tv.Title)
                .IsRequired() 
                .HasMaxLength(200); 

            modelBuilder.Entity<TVShow>()
                .Property(tv => tv.Description)
                .HasMaxLength(1000); 

            modelBuilder.Entity<TVShow>()
                .Property(tv => tv.PosterUrl)
                .HasMaxLength(500); 

            modelBuilder.Entity<TVShow>()
                .Property(tv => tv.Rating)
                .IsRequired();

            modelBuilder.Entity<Comment>()
           .HasOne(c => c.Movie)
           .WithMany(m => m.Comments)
           .HasForeignKey(c => c.MovieId);

            modelBuilder.Entity<Comment>()
                .HasOne(c => c.TVShow)
                .WithMany(ts => ts.Comments)
                .HasForeignKey(c => c.TVShowId);
        }
    }
}
