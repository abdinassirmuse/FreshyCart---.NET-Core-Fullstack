using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.Configuration;

namespace FreshyCartDAL.Models
{
    public partial class FreshyCartDBContext : DbContext
    {
        public FreshyCartDBContext()
        {
        }

        public FreshyCartDBContext(DbContextOptions<FreshyCartDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Cart> Cart { get; set; }
        public virtual DbSet<FeaturedProducts> FeaturedProducts { get; set; }
        public virtual DbSet<Products> Products { get; set; }
        public virtual DbSet<SlideShow> SlideShow { get; set; }
        public virtual DbSet<Users> Users { get; set; }
        public virtual DbSet<CartProducts> CartProducts { get; set; }

        ////Function - Creating your own function
        //[DbFunction("fn_FetchCartProductByEmailId", "dbo")]
        //public List<CartProducts> FetchCartProductByEmailId(string emailId)
        //{
        //    return null;
        //}




        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var builder = new ConfigurationBuilder()
                              .SetBasePath(Directory.GetCurrentDirectory())
                              .AddJsonFile("appsettings.json");
            var config = builder.Build();
            var connectionString = config.GetConnectionString("FreshyCartDBConnectionString");
            if (!optionsBuilder.IsConfigured)
            {
                // #warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer(connectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.HasDbFunction(() => FreshyCartDBContext.FetchCartProductByEmailId());

            modelBuilder.Entity<Cart>(entity =>
            {
                entity.HasKey(e => new { e.ProductId, e.EmailId });

                entity.Property(e => e.EmailId)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ProductImage)
                    .IsRequired()
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.ProductName)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.HasOne(d => d.Email)
                    .WithMany(p => p.Cart)
                    .HasForeignKey(d => d.EmailId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_Cart_EmailId");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.CartProduct)
                    .HasForeignKey(d => d.ProductId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_Cart_ProductId");

                entity.HasOne(d => d.ProductImageNavigation)
                    .WithMany(p => p.CartProductImageNavigation)
                    .HasPrincipalKey(p => p.ProductImage)
                    .HasForeignKey(d => d.ProductImage)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_Cart_ProductImage");

                entity.HasOne(d => d.ProductNameNavigation)
                    .WithMany(p => p.CartProductNameNavigation)
                    .HasPrincipalKey(p => p.ProductName)
                    .HasForeignKey(d => d.ProductName)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_Cart_ProductName");
            });

            modelBuilder.Entity<FeaturedProducts>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Fpimage)
                    .HasColumnName("FPImage")
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Products>(entity =>
            {
                entity.HasKey(e => e.ProductId);

                entity.HasIndex(e => e.ProductImage)
                    .HasName("UQ__Products__465B783CEB07C27C")
                    .IsUnique();

                entity.HasIndex(e => e.ProductName)
                    .HasName("UQ__Products__DD5A978A7844EE20")
                    .IsUnique();

                entity.Property(e => e.Price).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.ProductImage)
                    .IsRequired()
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.ProductName)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<SlideShow>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.SlideImage)
                    .HasMaxLength(500)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Users>(entity =>
            {
                entity.HasKey(e => e.EmailId);

                entity.Property(e => e.EmailId)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.FullName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });
        }
    }
}
