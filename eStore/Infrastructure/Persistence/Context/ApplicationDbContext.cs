using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using eStore.Infrastructure.Persistence.Entities;

namespace eStore.Infrastructure.Persistence.Context
{
    public partial class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext()
        {
        }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Brand> Brands { get; set; } = null!;
        public virtual DbSet<CartItem> CartItems { get; set; } = null!;
        public virtual DbSet<Category> Categories { get; set; } = null!;
        public virtual DbSet<ERole> ERoles { get; set; } = null!;
        public virtual DbSet<EUser> EUsers { get; set; } = null!;
        public virtual DbSet<Headphone> Headphones { get; set; } = null!;
        public virtual DbSet<Keyboard> Keyboards { get; set; } = null!;
        public virtual DbSet<Laptop> Laptops { get; set; } = null!;
        public virtual DbSet<Order> Orders { get; set; } = null!;
        public virtual DbSet<OrderItem> OrderItems { get; set; } = null!;
        public virtual DbSet<Product> Products { get; set; } = null!;
        public virtual DbSet<Review> Reviews { get; set; } = null!;
        public virtual DbSet<ShoppingCart> ShoppingCarts { get; set; } = null!;
        public virtual DbSet<TypeStatusOrder> TypeStatusOrders { get; set; } = null!;
        public virtual DbSet<Wishlist> Wishlists { get; set; } = null!;
        public virtual DbSet<WishlistItem> WishlistItems { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=.;Database=eStore;Trusted_Connection=True;MultipleActiveResultSets=true");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Brand>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("Id");

                entity.Property(e => e.BrandName)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Country)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Description).HasColumnType("text");
            });

            modelBuilder.Entity<CartItem>(entity =>
            {
                entity.Property(e => e.CartItemId).HasColumnName("CartItemID");

                entity.Property(e => e.CartId).HasColumnName("CartID");

                entity.Property(e => e.ProductId).HasColumnName("ProductID");

                entity.HasOne(d => d.Cart)
                    .WithMany(p => p.CartItems)
                    .HasForeignKey(d => d.CartId)
                    .HasConstraintName("FK__CartItems__CartI__5AEE82B9");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.CartItems)
                    .HasForeignKey(d => d.ProductId)
                    .HasConstraintName("FK__CartItems__Produ__5BE2A6F2");
            });

            modelBuilder.Entity<Category>(entity =>
            {
                entity.Property(e => e.CategoryId).HasColumnName("CategoryID");

                entity.Property(e => e.CategoryName)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Description).HasColumnType("text");
            });

            modelBuilder.Entity<ERole>(entity =>
            {
                entity.HasKey(e => e.RoleId)
                    .HasName("PK__eRoles__8AFACE3A91BC2BCA");

                entity.ToTable("eRoles");

                entity.Property(e => e.RoleId)
                    .ValueGeneratedNever()
                    .HasColumnName("RoleID");

                entity.Property(e => e.RoleName)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<EUser>(entity =>
            {
                entity.HasKey(e => e.Id)
                    .HasName("PK__eUsers__1788CCAC14065AB4");

                entity.ToTable("eUsers");

                entity.HasIndex(e => e.Email, "UQ__eUsers__A9D105342A0436A4")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("UserID");

                entity.Property(e => e.Address)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Email)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.FullName)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.PasswordHash)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Phone)
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.RoleId).HasColumnName("RoleID");

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.EUsers)
                    .HasForeignKey(d => d.RoleId)
                    .HasConstraintName("FK__eUsers__RoleID__3B75D760");
            });

            modelBuilder.Entity<Headphone>(entity =>
            {
                entity.Property(e => e.HeadphoneId).HasColumnName("HeadphoneID");

                entity.Property(e => e.BatteryLife)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Connectivity)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.FrequencyResponse)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ProductId).HasColumnName("ProductID");

                entity.Property(e => e.Type)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.Headphones)
                    .HasForeignKey(d => d.ProductId)
                    .HasConstraintName("FK__Headphone__Produ__693CA210");
            });

            modelBuilder.Entity<Keyboard>(entity =>
            {
                entity.Property(e => e.KeyboardId).HasColumnName("KeyboardID");

                entity.Property(e => e.Connectivity)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Layout)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ProductId).HasColumnName("ProductID");

                entity.Property(e => e.SwitchType)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Type)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.Keyboards)
                    .HasForeignKey(d => d.ProductId)
                    .HasConstraintName("FK__Keyboards__Produ__66603565");
            });

            modelBuilder.Entity<Laptop>(entity =>
            {
                entity.Property(e => e.LaptopId).HasColumnName("LaptopID");

                entity.Property(e => e.BatteryCapacity)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Gpu)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("GPU");

                entity.Property(e => e.OperatingSystem)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Processor)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.ProductId).HasColumnName("ProductID");

                entity.Property(e => e.Ram)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("RAM");

                entity.Property(e => e.ScreenSize)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Storage)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.Laptops)
                    .HasForeignKey(d => d.ProductId)
                    .HasConstraintName("FK__Laptops__Product__6C190EBB");
            });

            modelBuilder.Entity<Order>(entity =>
            {
                entity.Property(e => e.OrderId).HasColumnName("OrderID");

                entity.Property(e => e.OrderDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.ShippingAddress)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.StatusOrdersId).HasColumnName("StatusOrdersID");

                entity.Property(e => e.TotalAmount).HasColumnType("decimal(10, 2)");

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.HasOne(d => d.StatusOrders)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.StatusOrdersId)
                    .HasConstraintName("FK__Orders__StatusOr__4AB81AF0");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK__Orders__UserID__49C3F6B7");
            });

            modelBuilder.Entity<OrderItem>(entity =>
            {
                entity.Property(e => e.OrderItemId).HasColumnName("OrderItemID");

                entity.Property(e => e.OrderId).HasColumnName("OrderID");

                entity.Property(e => e.Price).HasColumnType("decimal(10, 2)");

                entity.Property(e => e.ProductId).HasColumnName("ProductID");

                entity.HasOne(d => d.Order)
                    .WithMany(p => p.OrderItems)
                    .HasForeignKey(d => d.OrderId)
                    .HasConstraintName("FK__OrderItem__Order__4D94879B");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.OrderItems)
                    .HasForeignKey(d => d.ProductId)
                    .HasConstraintName("FK__OrderItem__Produ__4E88ABD4");
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.Property(e => e.ProductId).HasColumnName("ProductID");

                entity.Property(e => e.BrandId).HasColumnName("BrandID");

                entity.Property(e => e.CategoryId).HasColumnName("CategoryID");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Description).HasColumnType("text");

                entity.Property(e => e.Price).HasColumnType("decimal(10, 2)");

                entity.Property(e => e.ProductName)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.HasOne(d => d.Brand)
                    .WithMany(p => p.Products)
                    .HasForeignKey(d => d.BrandId)
                    .HasConstraintName("FK__Products__BrandI__440B1D61");

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.Products)
                    .HasForeignKey(d => d.CategoryId)
                    .HasConstraintName("FK__Products__Catego__4316F928");
            });

            modelBuilder.Entity<Review>(entity =>
            {
                entity.Property(e => e.ReviewId).HasColumnName("ReviewID");

                entity.Property(e => e.Comment).HasColumnType("text");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.ProductId).HasColumnName("ProductID");

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.Reviews)
                    .HasForeignKey(d => d.ProductId)
                    .HasConstraintName("FK__Reviews__Product__534D60F1");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Reviews)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK__Reviews__UserID__5441852A");
            });

            modelBuilder.Entity<ShoppingCart>(entity =>
            {
                entity.HasKey(e => e.CartId)
                    .HasName("PK__Shopping__51BCD7976EC3C8B0");

                entity.ToTable("ShoppingCart");

                entity.Property(e => e.CartId).HasColumnName("CartID");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.ShoppingCarts)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK__ShoppingC__UserI__5812160E");
            });

            modelBuilder.Entity<TypeStatusOrder>(entity =>
            {
                entity.HasKey(e => e.StatusOrdersId)
                    .HasName("PK__TypeStat__25829A46CA673836");

                entity.Property(e => e.StatusOrdersId)
                    .ValueGeneratedNever()
                    .HasColumnName("StatusOrdersID");

                entity.Property(e => e.StatusName)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Wishlist>(entity =>
            {
                entity.Property(e => e.WishlistId).HasColumnName("WishlistID");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Wishlists)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK__Wishlists__UserI__5FB337D6");
            });

            modelBuilder.Entity<WishlistItem>(entity =>
            {
                entity.Property(e => e.WishlistItemId).HasColumnName("WishlistItemID");

                entity.Property(e => e.ProductId).HasColumnName("ProductID");

                entity.Property(e => e.WishlistId).HasColumnName("WishlistID");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.WishlistItems)
                    .HasForeignKey(d => d.ProductId)
                    .HasConstraintName("FK__WishlistI__Produ__6383C8BA");

                entity.HasOne(d => d.Wishlist)
                    .WithMany(p => p.WishlistItems)
                    .HasForeignKey(d => d.WishlistId)
                    .HasConstraintName("FK__WishlistI__Wishl__628FA481");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
