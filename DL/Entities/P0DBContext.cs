using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace DL.Entities
{
    public partial class P0DBContext : DbContext
    {
        public P0DBContext()
        {
        }

        public P0DBContext(DbContextOptions<P0DBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Brew> Brews { get; set; }
        public virtual DbSet<Brewery> Breweries { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<OrderItem> OrderItems { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Brew>(entity =>
            {
                entity.Property(e => e.BrewId).HasColumnName("brew_id");

                entity.Property(e => e.BrewQuantity).HasColumnName("brew_quantity");

                entity.Property(e => e.BreweryId).HasColumnName("brewery_id");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.HasOne(d => d.Brewery)
                    .WithMany(p => p.Brews)
                    .HasForeignKey(d => d.BreweryId)
                    .HasConstraintName("FK__Brews__brewery_i__74AE54BC");
            });

            modelBuilder.Entity<Brewery>(entity =>
            {
                entity.Property(e => e.BreweryId).HasColumnName("brewery_id");

                entity.Property(e => e.City)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.State)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Customer>(entity =>
            {
                entity.Property(e => e.CustomerId).HasColumnName("customer_id");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Order>(entity =>
            {
                entity.Property(e => e.OrderId).HasColumnName("order_id");

                entity.Property(e => e.CustomerId).HasColumnName("customer_id");

                entity.Property(e => e.OrderPlaced).HasColumnName("order_placed");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.CustomerId)
                    .HasConstraintName("FK__Orders__customer__797309D9");
            });

            modelBuilder.Entity<OrderItem>(entity =>
            {
                entity.ToTable("Order_Item");

                entity.Property(e => e.OrderItemId).HasColumnName("order_item_id");

                entity.Property(e => e.BrewId).HasColumnName("brew_id");

                entity.Property(e => e.OrderId).HasColumnName("order_id");

                entity.Property(e => e.OrderQuantity).HasColumnName("order_quantity");

                entity.HasOne(d => d.Brew)
                    .WithMany(p => p.OrderItems)
                    .HasForeignKey(d => d.BrewId)
                    .HasConstraintName("FK__Order_Ite__brew___7D439ABD");

                entity.HasOne(d => d.Order)
                    .WithMany(p => p.OrderItems)
                    .HasForeignKey(d => d.OrderId)
                    .HasConstraintName("FK__Order_Ite__order__7C4F7684");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
