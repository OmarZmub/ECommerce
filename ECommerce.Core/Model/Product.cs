using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.Data.Models;

public partial class Product
{
    [Key]
    public long Id { get;   set; }

    [Column("category_Id")]
    public long CategoryId { get; set; }

    [Column("product_name")]
    [StringLength(50)]
    public string ProductName { get; set; } = null!;

    [Column("description")]
    [StringLength(200)]
    public string Description { get; set; } = null!;

    [Column("price", TypeName = "decimal(18, 2)")]
    public decimal Price { get; set; }

    [Column("stock_quantity")]
    public int StockQuantity { get; set; }

    [Column("is_featured")]
    public bool IsFeatured { get; set; }

    [Column("discount_Id")]
    public long DiscountId { get; set; }

    [Column("average_rating")]
    public double AverageRating { get; set; }

    [InverseProperty("Product")]
    public virtual ICollection<CartItem>? CartItems { get; set; } = new List<CartItem>();

    [ForeignKey("CategoryId")]
    [InverseProperty("Products")]
    public virtual Category Category { get; set; } = null!;

    [ForeignKey("DiscountId")]
    [InverseProperty("Products")]
    public virtual Discount Discount { get; set; } = null!;

    [InverseProperty("Product")]
    public virtual ICollection<OrderItem>? OrderItems { get; set; } = new List<OrderItem>();

    [InverseProperty("Product")]
    public virtual ICollection<ProductImage>? ProductImages { get; set; } = new List<ProductImage>();

    [InverseProperty("Product")]
    public virtual ICollection<Review>? Reviews { get; set; } = new List<Review>();

    [InverseProperty("Product")]
    public virtual ICollection<StockMovement>? StockMovements { get; set; } = new List<StockMovement>();
}
