using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Nagarro.BookTheShow.DAL.EFModels;

#nullable disable

namespace Nagarro.BookTheShow.DAL.Data.DbContexts
{
    public partial class BookTheShowContext : DbContext
    {
        public BookTheShowContext()
        {
        }

        public BookTheShowContext(DbContextOptions<BookTheShowContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Movie> Movies { get; set; }
        public virtual DbSet<MovieListing> MovieListings { get; set; }
        public virtual DbSet<MovieSlot> MovieSlots { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<UserMovieBook> UserMovieBooks { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("name=DefaultConnection");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Movie>(entity =>
            {
                entity.ToTable("Movie");

                entity.Property(e => e.MovieName)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<MovieListing>(entity =>
            {
                entity.ToTable("MovieListing");

                entity.Property(e => e.Fare).HasColumnType("money");

                entity.Property(e => e.MovieDate).HasColumnType("date");

                entity.Property(e => e.MovieName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.MovieTime).HasColumnType("datetime");
            });

            modelBuilder.Entity<MovieSlot>(entity =>
            {
                entity.ToTable("MovieSlot");

                entity.Property(e => e.Fare).HasColumnType("money");

                entity.Property(e => e.MovieTime).HasColumnType("datetime");

                entity.HasOne(d => d.Movie)
                    .WithMany(p => p.MovieSlots)
                    .HasForeignKey(d => d.MovieId)
                    .HasConstraintName("FK__MovieSlot__Movie__6FE99F9F");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("User");

                entity.Property(e => e.Contact).HasColumnType("numeric(10, 0)");

                entity.Property(e => e.Email).IsRequired();

                entity.Property(e => e.FirstName).IsRequired();

                entity.Property(e => e.Gender)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsFixedLength(true);

                entity.Property(e => e.LastName).IsRequired();

                entity.Property(e => e.Password).IsRequired();
            });

            modelBuilder.Entity<UserMovieBook>(entity =>
            {
                entity.ToTable("UserMovieBook");

                entity.Property(e => e.SeatNos).IsRequired();

                entity.HasOne(d => d.User)
                    .WithMany(p => p.UserMovieBooks)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__UserMovie__UserI__49C3F6B7");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
