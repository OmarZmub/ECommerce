using ECommerce.Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.Data
{
    public class database : IdentityDbContext<User>
    {
        public database()
        {
            
        }

        public database(DbContextOptions op): base(op)
        {
            
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<IdentityRole>().HasData(
                new IdentityRole()
                {
                    Id = "1",
                    Name = "Admin",
                    NormalizedName = "admin",
                    ConcurrencyStamp = "Guid.NewGuid().ToString()",
                },
                 new IdentityRole()
                 {
                     Id = "Guid.NewGuid().ToString()",
                     Name = "User",
                     NormalizedName = "user",
                     ConcurrencyStamp = "Guid.NewGuid().ToString()",
                 }
                );

            modelBuilder.Entity<Address>(entity =>
            {
                entity.HasOne(d => d.Region).WithMany(p => p.Addresses)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Addresses_ShippingRegions");

                entity.HasOne(d => d.User).WithMany(p => p.Addresses)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Addresses_Users");
            });

            modelBuilder.Entity<BankFee>(entity =>
            {
                entity.HasOne(d => d.PaymentMethod).WithMany(p => p.BankFees)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_BankFees_PaymentMethods");
            });

            modelBuilder.Entity<Cart>(entity =>
            {
                //entity.HasOne(d => d.User).WithOne(p => p.Cart)
                //    .OnDelete(DeleteBehavior.ClientSetNull)
                //    .HasConstraintName("FK_Cart_Users");
            });

            modelBuilder.Entity<CartItem>(entity =>
            {
                entity.HasOne(d => d.Cart).WithMany(p => p.CartItems)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CartItems_Cart");

                entity.HasOne(d => d.Product).WithMany(p => p.CartItems)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CartItems_Products");
            });

            modelBuilder.Entity<Category>(entity =>
            {
                entity.HasOne(d => d.ParentCategory).WithMany(p => p.InverseParentCategory).HasConstraintName("FK_Categories_Categories1");
            });

            modelBuilder.Entity<Discount>(entity =>
            {
                entity.HasOne(d => d.DiscountType).WithMany(p => p.Discounts)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Discounts_DiscountTypes");
            });

            modelBuilder.Entity<Order>(entity =>
            {
                entity.HasOne(d => d.Discount).WithMany(p => p.Orders).HasConstraintName("FK_Orders_Discounts");

                entity.HasOne(d => d.ShippingAddress).WithMany(p => p.Orders)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Orders_Addresses");

                entity.HasOne(d => d.Status).WithMany(p => p.Orders)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Orders_OrderStatus");

                //entity.HasOne(d => d.User).WithMany(p => p.Orders)
                //    .OnDelete(DeleteBehavior.ClientSetNull)
                //    .HasConstraintName("FK_Orders_Users");
            });

            modelBuilder.Entity<OrderItem>(entity =>
            {
                entity.HasOne(d => d.Order).WithMany(p => p.OrderItems)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_OrderItems_Orders");

                entity.HasOne(d => d.Product).WithMany(p => p.OrderItems)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_OrderItems_Products");
            });

            modelBuilder.Entity<PaymentDetail>(entity =>
            {
                entity.HasOne(d => d.Order).WithMany(p => p.PaymentDetails)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PaymentDetails_Orders");

                entity.HasOne(d => d.PaymentMethod).WithMany(p => p.PaymentDetails)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PaymentDetails_PaymentMethods");

                entity.HasOne(d => d.Status).WithMany(p => p.PaymentDetails)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PaymentDetails_PaymentStatus");
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.HasOne(d => d.Category).WithMany(p => p.Products)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Products_Categories");

                entity.HasOne(d => d.Discount).WithMany(p => p.Products)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Products_Discounts");
            });

            modelBuilder.Entity<ProductImage>(entity =>
            {
                entity.HasOne(d => d.Product).WithMany(p => p.ProductImages)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ProductImages_Products");
            });

            modelBuilder.Entity<Review>(entity =>
            {
                entity.HasOne(d => d.Product).WithMany(p => p.Reviews)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Reviews_Products");

                //entity.HasOne(d => d.User).WithMany(p => p.Reviews)
                //    .OnDelete(DeleteBehavior.ClientSetNull)
                //    .HasConstraintName("FK_Reviews_Users");
            });

            modelBuilder.Entity<StockMovement>(entity =>
            {
                entity.HasOne(d => d.Product).WithMany(p => p.StockMovements)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_StockMovements_Products");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("PK__Users__3214EC076955B873");


                entity.Property(e => e.IsActive).HasDefaultValue(true);


                entity.Property(e => e.TwoFactorEnabled).HasDefaultValue(false);

            });


        }


        public DbSet<Address> Addresses { get; set; } = null!;

        public virtual DbSet<BankFee> BankFees { get; set; }

        public virtual DbSet<Cart> Carts { get; set; }

        public virtual DbSet<CartItem> CartItems { get; set; }

        public virtual DbSet<Category> Categories { get; set; }

        public virtual DbSet<Discount> Discounts { get; set; }

        public virtual DbSet<DiscountType> DiscountTypes { get; set; }

        public virtual DbSet<Order> Orders { get; set; }

        public virtual DbSet<OrderItem> OrderItems { get; set; }

        public virtual DbSet<OrderStatus> OrderStatuses { get; set; }

        public virtual DbSet<PaymentDetail> PaymentDetails { get; set; }

        public virtual DbSet<PaymentMethod> PaymentMethods { get; set; }

        public virtual DbSet<PaymentStatus> PaymentStatuses { get; set; }

        public virtual DbSet<Product> Products { get; set; }

        public virtual DbSet<ProductImage> ProductImages { get; set; }

        public virtual DbSet<Review> Reviews { get; set; }

        public virtual DbSet<ShippingRegion> ShippingRegions { get; set; }

        public virtual DbSet<StockMovement> StockMovements { get; set; }

    }

}

