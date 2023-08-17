using System;
using System.Collections.Generic;
using Booking.Infrastruture.Repositories.Shared;
using Booking.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace Booking.Infrastruture;

public partial class BookingDBContext : DbContext
{
    public BookingDBContext()
    {
    }

    public BookingDBContext(DbContextOptions<BookingDBContext> options)
        : base(options)
    {
    }

    public virtual DbSet<User> Users { get; set; }
    public virtual DbSet<BookedSeat> BookedSeats { get; set; }
    public virtual DbSet<Genre> Genres { get; set; }
    public virtual DbSet<Movie> Movies { get; set; }
    public virtual DbSet<ShowTime> ShowTimes { get; set; }
    public virtual DbSet<Theater> Theaters { get; set; }
    public virtual DbSet<BookingPending> BookingPendings { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) => optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=Booking;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<User>(entity =>
        {
            entity.ToTable($"{nameof(User)}s");
            entity.Property(e => e.Id).ValueGeneratedOnAdd();

            entity.HasMany(e => e.BookedSeats).WithOne(e => e.Booker);
        });

        modelBuilder.Entity<BookedSeat>(entity =>
        {
            entity.ToTable($"{nameof(BookedSeat)}s");
            entity.Property(e => e.Id).ValueGeneratedOnAdd();

            entity.HasOne(e => e.Booker).WithMany(e => e.BookedSeats);
            entity.HasOne(e => e.ShowTime).WithMany(e => e.BookedSeats);
        });

        modelBuilder.Entity<Genre>(entity =>
        {
            entity.ToTable($"{nameof(Genre)}s");
            entity.HasKey(e => e.Name);
            entity.Property(e => e.Name).IsRequired();

            entity.HasMany(e => e.Movies).WithOne(e => e.Genre);
        });

        modelBuilder.Entity<Movie>(entity =>
        {
            entity.ToTable($"{nameof(Movie)}s");
            entity.Property(e => e.Id).ValueGeneratedOnAdd();

            entity.HasOne(e => e.Genre).WithMany(e => e.Movies);
            entity.HasMany(e => e.ShowTimes).WithOne(e => e.Movie);
        });

        modelBuilder.Entity<ShowTime>(entity =>
        {
            entity.ToTable($"{nameof(ShowTime)}s");
            entity.Property(e => e.Id).ValueGeneratedOnAdd();

            entity.HasOne(e => e.Movie).WithMany(e => e.ShowTimes);
            entity.HasMany(e => e.BookedSeats).WithOne(e => e.ShowTime);
            entity.HasOne(e => e.Theater).WithMany(e => e.ShowTimes);
        });

        modelBuilder.Entity<Theater>(entity =>
        {
            entity.ToTable($"{nameof(Theater)}s");
            entity.Property(e => e.Id).ValueGeneratedOnAdd();

            entity.HasMany(e => e.ShowTimes).WithOne(e => e.Theater);
        });
        
        modelBuilder.Entity<BookingPending>(entity => {
            entity.ToTable($"{nameof(BookingPending)}s");
            entity.Property(e => e.Id).ValueGeneratedOnAdd();

            entity.HasOne(e => e.Seat);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
