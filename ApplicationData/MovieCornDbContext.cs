using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Backend_MovieCorn.ApplicationData;

public partial class MovieCornDbContext : DbContext
{
    public MovieCornDbContext()
    {
    }

    public MovieCornDbContext(DbContextOptions<MovieCornDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Country> Countries { get; set; }

    public virtual DbSet<Cover> Covers { get; set; }

    public virtual DbSet<Favorite> Favorites { get; set; }

    public virtual DbSet<FavoritesView> FavoritesViews { get; set; }

    public virtual DbSet<Genre> Genres { get; set; }

    public virtual DbSet<Movie> Movies { get; set; }

    public virtual DbSet<MoviesCover> MoviesCovers { get; set; }

    public virtual DbSet<MoviesGenre> MoviesGenres { get; set; }

    public virtual DbSet<MoviesTag> MoviesTags { get; set; }

    public virtual DbSet<MoviesView> MoviesViews { get; set; }

    public virtual DbSet<Tag> Tags { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=IgorPc\\SQLEXPRESS; Database=MovieCornDb; Trusted_Connection=True; TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Country>(entity =>
        {
            entity.Property(e => e.CountryId).HasColumnName("country_id");
            entity.Property(e => e.Name)
                .HasMaxLength(80)
                .HasColumnName("name");
        });

        modelBuilder.Entity<Cover>(entity =>
        {
            entity.Property(e => e.CoverId).HasColumnName("cover_id");
            entity.Property(e => e.CoverPath).HasColumnName("cover_path");
        });

        modelBuilder.Entity<Favorite>(entity =>
        {
            entity.Property(e => e.FavoriteId).HasColumnName("favorite_id");
            entity.Property(e => e.MovieId).HasColumnName("movie_id");
            entity.Property(e => e.UserId).HasColumnName("user_id");

            entity.HasOne(d => d.Movie).WithMany(p => p.Favorites)
                .HasForeignKey(d => d.MovieId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Favorites_Movies");

            entity.HasOne(d => d.User).WithMany(p => p.Favorites)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Favorites_Users");
        });

        modelBuilder.Entity<FavoritesView>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("FavoritesView");

            entity.Property(e => e.Age).HasColumnName("age");
            entity.Property(e => e.CountryId).HasColumnName("country_id");
            entity.Property(e => e.CoverPath).HasColumnName("cover_path");
            entity.Property(e => e.Director)
                .HasMaxLength(100)
                .HasColumnName("director");
            entity.Property(e => e.FavoriteId).HasColumnName("favorite_id");
            entity.Property(e => e.LengthMin).HasColumnName("length_min");
            entity.Property(e => e.MovieId).HasColumnName("movie_id");
            entity.Property(e => e.Name)
                .HasMaxLength(150)
                .HasColumnName("name");
            entity.Property(e => e.ProduceYear).HasColumnName("produce_year");
            entity.Property(e => e.Producer)
                .HasMaxLength(100)
                .HasColumnName("producer");
            entity.Property(e => e.UserId).HasColumnName("user_id");
        });

        modelBuilder.Entity<Genre>(entity =>
        {
            entity.Property(e => e.GenreId).HasColumnName("genre_id");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .HasColumnName("name");
        });

        modelBuilder.Entity<Movie>(entity =>
        {
            entity.Property(e => e.MovieId).HasColumnName("movie_id");
            entity.Property(e => e.Age).HasColumnName("age");
            entity.Property(e => e.CountryId).HasColumnName("country_id");
            entity.Property(e => e.Director)
                .HasMaxLength(100)
                .HasColumnName("director");
            entity.Property(e => e.LengthMin).HasColumnName("length_min");
            entity.Property(e => e.Name)
                .HasMaxLength(150)
                .HasColumnName("name");
            entity.Property(e => e.ProduceYear).HasColumnName("produce_year");
            entity.Property(e => e.Producer)
                .HasMaxLength(100)
                .HasColumnName("producer");

            entity.HasOne(d => d.Country).WithMany(p => p.Movies)
                .HasForeignKey(d => d.CountryId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Movies_Countries");
        });

        modelBuilder.Entity<MoviesCover>(entity =>
        {
            entity.HasKey(e => e.MovieCoverId);

            entity.Property(e => e.MovieCoverId).HasColumnName("movie_cover_id");
            entity.Property(e => e.CoverId).HasColumnName("cover_id");
            entity.Property(e => e.MovieId).HasColumnName("movie_id");

            entity.HasOne(d => d.Cover).WithMany(p => p.MoviesCovers)
                .HasForeignKey(d => d.CoverId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_MoviesCovers_Covers");

            entity.HasOne(d => d.Movie).WithMany(p => p.MoviesCovers)
                .HasForeignKey(d => d.MovieId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_MoviesCovers_Movies");
        });

        modelBuilder.Entity<MoviesGenre>(entity =>
        {
            entity.HasKey(e => e.MovieGenreId);

            entity.Property(e => e.MovieGenreId).HasColumnName("movie_genre_id");
            entity.Property(e => e.GenreId).HasColumnName("genre_id");
            entity.Property(e => e.MovieId).HasColumnName("movie_id");

            entity.HasOne(d => d.Genre).WithMany(p => p.MoviesGenres)
                .HasForeignKey(d => d.GenreId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_MoviesGenres_Genres");

            entity.HasOne(d => d.Movie).WithMany(p => p.MoviesGenres)
                .HasForeignKey(d => d.MovieId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_MoviesGenres_Movies");
        });

        modelBuilder.Entity<MoviesTag>(entity =>
        {
            entity.HasKey(e => e.MovieTagId);

            entity.Property(e => e.MovieTagId).HasColumnName("movie_tag_id");
            entity.Property(e => e.MovieId).HasColumnName("movie_id");
            entity.Property(e => e.TagId).HasColumnName("tag_id");

            entity.HasOne(d => d.Movie).WithMany(p => p.MoviesTags)
                .HasForeignKey(d => d.MovieId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_MoviesTags_Movies");

            entity.HasOne(d => d.Tag).WithMany(p => p.MoviesTags)
                .HasForeignKey(d => d.TagId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_MoviesTags_Tags");
        });

        modelBuilder.Entity<MoviesView>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("MoviesView");

            entity.Property(e => e.Age).HasColumnName("age");
            entity.Property(e => e.Country)
                .HasMaxLength(80)
                .HasColumnName("country");
            entity.Property(e => e.CoverPath).HasColumnName("cover_path");
            entity.Property(e => e.Director)
                .HasMaxLength(100)
                .HasColumnName("director");
            entity.Property(e => e.LengthMin).HasColumnName("length_min");
            entity.Property(e => e.MovieCoverId).HasColumnName("movie_cover_id");
            entity.Property(e => e.MovieId).HasColumnName("movie_id");
            entity.Property(e => e.MovieTagId).HasColumnName("movie_tag_id");
            entity.Property(e => e.Name)
                .HasMaxLength(150)
                .HasColumnName("name");
            entity.Property(e => e.ProduceYear).HasColumnName("produce_year");
            entity.Property(e => e.Producer)
                .HasMaxLength(100)
                .HasColumnName("producer");
            entity.Property(e => e.Tag)
                .HasMaxLength(100)
                .HasColumnName("tag");
            entity.Property(e => e.TagId).HasColumnName("tag_id");
        });

        modelBuilder.Entity<Tag>(entity =>
        {
            entity.Property(e => e.TagId).HasColumnName("tag_id");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .HasColumnName("name");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.Property(e => e.UserId).HasColumnName("user_id");
            entity.Property(e => e.CoverImage).HasColumnName("cover_image");
            entity.Property(e => e.Name)
                .HasMaxLength(30)
                .HasColumnName("name");
            entity.Property(e => e.Password)
                .HasMaxLength(20)
                .HasColumnName("password");
            entity.Property(e => e.Phone)
                .HasMaxLength(20)
                .HasColumnName("phone");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
