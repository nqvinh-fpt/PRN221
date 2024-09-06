using System;
using System.Collections.Generic;
using HotelManagement.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace AutomobileLibrary.Model;

public partial class MyStockContext : DbContext
{
    public MyStockContext()
    {
    }

    public MyStockContext(DbContextOptions<MyStockContext> options)
        : base(options)
    {
    }



    public virtual DbSet<Bookings> Bookings { get; set; } = null!;
    public virtual DbSet<Rooms> Rooms { get; set; } = null!;
    public virtual DbSet<Customers> Customers { get; set; } = null!;

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            var ConnectionString = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json").Build().GetConnectionString("DefaultConnection");
            optionsBuilder.UseSqlServer(ConnectionString);
            //optionsBuilder.UseSqlServer("server =(local); database = HotelManager;uid=sa;pwd=123;");
        }
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Customers>(entity =>
        {
            entity.Property(e => e.name)
                .HasMaxLength(100)
                .IsUnicode(false);

            entity.Property(e => e.phone_number)
            .HasMaxLength(20)
            .IsUnicode(false)
            ;

            entity.Property(e => e.email)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.address)
                .HasMaxLength(200)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Rooms>(entity =>
        {
            entity.Property(e => e.room_type)
            .HasMaxLength(50)
                .IsUnicode(false);

            entity.Property(e => e.status)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.Property(e => e.price).HasColumnType("money");
        });

        modelBuilder.Entity<Bookings>(entity =>
        {

            entity.Property(e => e.total_price).HasColumnType("money");

            entity.Property(e => e.checkin_date).HasColumnType("date");

            entity.Property(e => e.checkout_date).HasColumnType("date");

            entity.HasOne(d => d.RoomIdNavigation)
                .WithMany(p => p.Bookings)
                .HasForeignKey(d => d.room_id)
                .HasConstraintName("FK_Services_Rooms");

            entity.HasOne(d => d.CustomerNavigation)
                .WithMany(p => p.Bookings)
                .HasForeignKey(d => d.customer_id)
                .HasConstraintName("FK_Services_Customers");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
