﻿using System;
using System.Collections.Generic;
using System.Configuration;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.Configuration;

namespace WpfApp.Models
{
    public partial class PRN221_Spr22Context : DbContext
    {
        public PRN221_Spr22Context()
        {
        }

        public PRN221_Spr22Context(DbContextOptions<PRN221_Spr22Context> options)
            : base(options)
        {
        }

        public virtual DbSet<Employee> Employees { get; set; } = null!;
        public virtual DbSet<Room> Rooms { get; set; } = null!;
        public virtual DbSet<Service> Services { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                var ConnectionString = new ConfigurationBuilder()
                    .AddJsonFile("appsettings.json").Build().GetConnectionString("DefaultConnection");
                optionsBuilder.UseSqlServer(ConnectionString);
                //optionsBuilder.UseSqlServer("server =(local); database = PRN221_Spr22;uid=sa;pwd=123;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>(entity =>
            {
                entity.Property(e => e.Dob).HasColumnType("date");

                entity.Property(e => e.Gender).HasMaxLength(10);

                entity.Property(e => e.Idnumber)
                    .HasMaxLength(12)
                    .IsUnicode(false)
                    .HasColumnName("IDNumber");

                entity.Property(e => e.Name).HasMaxLength(100);

                entity.Property(e => e.Phone)
                    .HasMaxLength(15)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Room>(entity =>
            {
                entity.HasKey(e => e.Title);

                entity.Property(e => e.Title)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Comment).HasColumnType("ntext");

                entity.Property(e => e.Description).HasColumnType("ntext");
            });

            modelBuilder.Entity<Service>(entity =>
            {
                entity.Property(e => e.Amount).HasColumnType("money");

                entity.Property(e => e.FeeType).HasMaxLength(50);

                entity.Property(e => e.PaymentDate).HasColumnType("date");

                entity.Property(e => e.RoomTitle)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.HasOne(d => d.EmployeeNavigation)
                    .WithMany(p => p.Services)
                    .HasForeignKey(d => d.Employee)
                    .HasConstraintName("FK_Services_Employees");

                entity.HasOne(d => d.RoomTitleNavigation)
                    .WithMany(p => p.Services)
                    .HasForeignKey(d => d.RoomTitle)
                    .HasConstraintName("FK_Services_Rooms");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
