using System;
using System.Collections.Generic;
using Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace EFDAL;

public partial class FullCartContext : DbContext
{
    public FullCartContext(IConfiguration configuration)
    {
    }

    public FullCartContext(DbContextOptions<FullCartContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Brand> Brands { get; set; }

    public virtual DbSet<Category> Categories { get; set; }

    public virtual DbSet<Order> Orders { get; set; }

    public virtual DbSet<OrderProduct> OrderProducts { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<UserRole> UserRoles { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=DESKTOP-Q1OMHJE;Database=FullCart;Trusted_Connection=True;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Brand>(entity =>
        {
            entity.ToTable("Brand");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Category>(entity =>
        {
            entity.ToTable("Category");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(50);
        });

        modelBuilder.Entity<Order>(entity =>
        {
            entity.ToTable("Order");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.CustomerId).HasColumnName("CustomerID");
            entity.Property(e => e.Status)
                .IsRequired()
                .HasMaxLength(50);

            entity.HasOne(d => d.Customer).WithMany(p => p.Orders)
                .HasForeignKey(d => d.CustomerId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Order_User");
        });

        modelBuilder.Entity<OrderProduct>(entity =>
        {
            entity.ToTable("OrderProduct");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.OrderId).HasColumnName("OrderID");
            entity.Property(e => e.ProductId).HasColumnName("ProductID");

            entity.HasOne(d => d.Order).WithMany(p => p.OrderProducts)
                .HasForeignKey(d => d.OrderId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_OrderProduct_Order");

            entity.HasOne(d => d.Product).WithMany(p => p.OrderProducts)
                .HasForeignKey(d => d.ProductId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_OrderProduct_Product");
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.ToTable("Product");

            entity.Property(e => e.Id)
                .ValueGeneratedOnAdd()
                .HasColumnName("ID");
            entity.Property(e => e.BrandId).HasColumnName("BrandID");
            entity.Property(e => e.CategoryId).HasColumnName("CategoryID");
            entity.Property(e => e.Image).HasColumnType("image");
            entity.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(50);

            entity.HasOne(d => d.Category).WithMany(p => p.Products)
                .HasForeignKey(d => d.CategoryId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Product_Category");

            entity.HasOne(d => d.IdNavigation).WithOne(p => p.Product)
                .HasForeignKey<Product>(d => d.Id)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Product_Brand");
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.ToTable("Role");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(50);
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.ToTable("User");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.EmailId)
                .IsRequired()
                .HasMaxLength(50)
                .HasColumnName("EmailID");
            entity.Property(e => e.FirstName)
                .IsRequired()
                .HasMaxLength(50)
                .HasColumnName("First Name");
            entity.Property(e => e.LastName)
                .IsRequired()
                .HasMaxLength(50);
            entity.Property(e => e.Password).IsRequired();
        });

        modelBuilder.Entity<UserRole>(entity =>
        {
            entity.ToTable("UserRole");

            entity.Property(e => e.UserRoleId)
                .ValueGeneratedOnAdd()
                .HasColumnName("UserRoleID");
            entity.Property(e => e.RoleId).HasColumnName("RoleID");
            entity.Property(e => e.UserId).HasColumnName("UserID");

            entity.HasOne(d => d.User).WithMany(p => p.UserRoles)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_UserRole_User");

            entity.HasOne(d => d.UserRoleNavigation).WithOne(p => p.UserRole)
                .HasForeignKey<UserRole>(d => d.UserRoleId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_UserRole_Role");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
