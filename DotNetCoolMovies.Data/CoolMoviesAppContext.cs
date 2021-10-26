using DotNetCoolMovies.Core.Domain;
using Microsoft.EntityFrameworkCore;

namespace DotNetCoolMovies.Data
{
    public partial class CoolMoviesAppContext : DbContext
    {
        public CoolMoviesAppContext(DbContextOptions<CoolMoviesAppContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Actor> Actors { get; set; }
        public virtual DbSet<Genre> Genres { get; set; }
        public virtual DbSet<Movie> Movies { get; set; }
        public virtual DbSet<MovieActors> MovieActors { get; set; }
        public virtual DbSet<MovieGenres> MovieGenres { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Modern_Spanish_CI_AS");

            modelBuilder.Entity<Actor>(entity =>
            {
                entity.ToTable("Actors");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<Genre>(entity =>
            {
                entity.ToTable("Genres");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Movie>(entity =>
            {
                entity.ToTable("Movies");

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<MovieActors>(entity =>
            {
                entity.ToTable("MovieActors");

                // -----------------------------------------------
                // Auto-include entity relation because it will be
                // always used in queries
                // -----------------------------------------------
                entity.Navigation(n => n.Actor).AutoInclude();

                entity.HasOne(d => d.Actor)
                    .WithMany(p => p.MovieActors)
                    .HasForeignKey(d => d.ActorId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_MoviesActors_Actors");

                entity.HasOne(d => d.Movie)
                    .WithMany(p => p.Actors)
                    .HasForeignKey(d => d.MovieId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_MoviesActors_Movies");
            });

            modelBuilder.Entity<MovieGenres>(entity =>
            {
                entity.ToTable("MovieGenres");

                // -----------------------------------------------
                // Auto-include entity relation because it will be
                // always used in queries
                // -----------------------------------------------
                entity.Navigation(n => n.Genre).AutoInclude();

                entity.HasOne(d => d.Genre)
                    .WithMany(p => p.MovieGenres)
                    .HasForeignKey(d => d.GenreId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_MoviesGenres_Genres");

                entity.HasOne(d => d.Movie)
                    .WithMany(p => p.Genres)
                    .HasForeignKey(d => d.MovieId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_MoviesGenres_Movies");
            });


            base.OnModelCreating(modelBuilder);
        }
    }
}
