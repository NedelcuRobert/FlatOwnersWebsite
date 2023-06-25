using FOA.BACKEND.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.ViewEngines;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace FOA.BACKEND.DataAccess.EFCore
{
    public class FOAContext : IdentityDbContext<User>
    {
        public FOAContext(DbContextOptions<FOAContext> options) : base(options)
        {
        }

        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Request> Requests { get; set; }
        public virtual DbSet<Announcement> Announcements { get; set; }
        public virtual DbSet<Address> Addresses { get; set; }
        public virtual DbSet<Apartment> Apartments { get; set; }
        public virtual DbSet<Contract> Contracts { get; set; }
        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<Invoice> Invoices { get; set; }
        public virtual DbSet<WaterConsumption> WaterConsumptions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.SeedAddress();
            modelBuilder.SeedAccounts();

            modelBuilder.Entity<Apartment>(entity =>
            {
                entity
                    .HasOne(b => b.User)
                    .WithMany(u => u.Apartments)
                    .HasForeignKey(b => b.UserId)
                    .OnDelete(DeleteBehavior.ClientNoAction);
            });

            modelBuilder.Entity<WaterConsumption>(entity =>
            {
                entity
                    .HasOne(b => b.Apartment)
                    .WithMany(u => u.WaterConsumptions)
                    .HasForeignKey(b => b.ApartmentId)
                    .OnDelete(DeleteBehavior.ClientNoAction);

            });

            modelBuilder.Entity<Invoice>(entity =>
            {
                entity
                    .HasOne(b => b.Apartment)
                    .WithMany(u => u.Invoices)
                    .HasForeignKey(b => b.ApartmentId)
                    .OnDelete(DeleteBehavior.ClientNoAction);

            });

            modelBuilder.Entity<Request>(entity =>
            {
                entity
                    .HasOne(b => b.User)
                    .WithMany(u => u.Requests)
                    .HasForeignKey(b => b.UserId)
                    .OnDelete(DeleteBehavior.ClientNoAction);

            });

            modelBuilder.Entity<Announcement>(entity =>
            {
                entity
                    .HasOne(b => b.User)
                    .WithMany(u => u.Announcements)
                    .HasForeignKey(b => b.UserId)
                    .OnDelete(DeleteBehavior.ClientNoAction);

            });

            modelBuilder.Entity<User>(entity =>
            {
                entity
                    .HasOne(b => b.Address)
                    .WithOne(u => u.User)
                    .HasForeignKey<User>(b => b.AddressId)
                    .OnDelete(DeleteBehavior.ClientNoAction);

            });
        }
    }
}
