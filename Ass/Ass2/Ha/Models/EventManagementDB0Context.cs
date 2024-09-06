using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Ha.Models
{
    public partial class EventManagementDB0Context : DbContext
    {
        public EventManagementDB0Context()
        {
        }

        public EventManagementDB0Context(DbContextOptions<EventManagementDB0Context> options)
            : base(options)
        {
        }

        public virtual DbSet<Attendee> Attendees { get; set; } = null!;
        public virtual DbSet<Event> Events { get; set; } = null!;
        public virtual DbSet<EventCategory> EventCategories { get; set; } = null!;
        public virtual DbSet<User> Users { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("server=LAPTOP-H8LUNFAT\\MAYAO;database=EventManagementDB0;uid=sa;pwd=123;TrustServerCertificate=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Attendee>(entity =>
            {
                entity.Property(e => e.AttendeeId).HasColumnName("AttendeeID");

                entity.Property(e => e.Email).HasMaxLength(100);

                entity.Property(e => e.EventId).HasColumnName("EventID");

                entity.Property(e => e.Name).HasMaxLength(100);

                entity.Property(e => e.RegistrationTime).HasColumnType("datetime");

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.HasOne(d => d.Event)
                    .WithMany(p => p.Attendees)
                    .HasForeignKey(d => d.EventId)
                    .HasConstraintName("FK__Attendees__Event__3D5E1FD2");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Attendees)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK__Attendees__UserI__3E52440B");
            });

            modelBuilder.Entity<Event>(entity =>
            {
                entity.Property(e => e.EventId).HasColumnName("EventID");

                entity.Property(e => e.CategoryId).HasColumnName("CategoryID");

                entity.Property(e => e.Description).HasColumnType("text");

                entity.Property(e => e.EndTime).HasColumnType("datetime");

                entity.Property(e => e.Location).HasMaxLength(100);

                entity.Property(e => e.StartTime).HasColumnType("datetime");

                entity.Property(e => e.Title).HasMaxLength(100);

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.Events)
                    .HasForeignKey(d => d.CategoryId)
                    .HasConstraintName("FK__Events__Category__38996AB5");
            });

            modelBuilder.Entity<EventCategory>(entity =>
            {
                entity.HasKey(e => e.CategoryId)
                    .HasName("PK__EventCat__19093A2BBEC96315");

                entity.Property(e => e.CategoryId).HasColumnName("CategoryID");

                entity.Property(e => e.CategoryName).HasMaxLength(50);
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.Property(e => e.Email).HasMaxLength(100);

                entity.Property(e => e.FullName).HasMaxLength(100);

                entity.Property(e => e.Password).HasMaxLength(50);

                entity.Property(e => e.Role).HasMaxLength(50);

                entity.Property(e => e.Username).HasMaxLength(50);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
