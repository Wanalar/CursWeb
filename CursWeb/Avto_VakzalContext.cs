using System;
using System.Collections.Generic;
using CursLib.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace CursWeb
{
    public partial class Avto_VakzalContext : DbContext
    {
        public Avto_VakzalContext()
        {
        }

        static Avto_VakzalContext instance;
        public static Avto_VakzalContext GetInstance()
        {
            if (instance == null)
                instance = new Avto_VakzalContext();
            return instance;
        }

        public Avto_VakzalContext(DbContextOptions<Avto_VakzalContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Information> Informations { get; set; } = null!;
        public virtual DbSet<Role> Roles { get; set; } = null!;
        public virtual DbSet<Ticket> Tickets { get; set; } = null!;
        public virtual DbSet<Trip> Trips { get; set; } = null!;
        public virtual DbSet<User> Users { get; set; } = null!;
        public virtual DbSet<Bus> Buses { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("server=192.168.200.35;user=user18;password=38024;database=user18");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Information>(entity =>
            {
                entity.Property(e => e.InformationId).HasColumnName("InformationID");
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.Property(e => e.RoleId).HasColumnName("RoleID");
            });

            modelBuilder.Entity<Ticket>(entity =>
            {
                entity.Property(e => e.TicketId).HasColumnName("TicketID");

                entity.Property(e => e.Iduser).HasColumnName("IDUser");

                entity.HasOne(d => d.IduserNavigation)
                    .WithMany(p => p.Tickets)
                    .HasForeignKey(d => d.Iduser)
                    .HasConstraintName("FK_Ticket_User");

                entity.HasOne(d => d.TripNavigation)
                    .WithMany(p => p.Tickets)
                    .HasForeignKey(d => d.Trip)
                    .HasConstraintName("FK_Ticket_Trip");
            });

            modelBuilder.Entity<Trip>(entity =>
            {
                entity.Property(e => e.TripId).HasColumnName("TripID");
                entity.Property(e => e.Cost).HasColumnType("money");

                entity.HasOne(d => d.BusNavigation)
                    .WithMany(p => p.Trips)
                    .HasForeignKey(d => d.Bus)
                    .HasConstraintName("FK_Trip_Bus");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.HasOne(d => d.RoleNavigation)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.Role)
                    .HasConstraintName("FK_User_Role");
            });

            modelBuilder.Entity<Bus>(entity =>
            {
                entity.Property(e => e.BusId).HasColumnName("BusID");

                entity.Property(e => e.Number).HasMaxLength(50);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
