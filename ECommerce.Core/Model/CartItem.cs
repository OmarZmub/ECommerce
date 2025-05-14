using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.Data.Models;

public partial class CartItem
{
    [Key]
    public long Id { get; set; }

    [Column("cart_Id")]
    public long CartId { get; set; }

    [Column("product_Id")]
    public long ProductId { get; set; }

    [Column("quantity")]
    public int Quantity { get; set; }

    [Column("price_at_addition", TypeName = "decimal(18, 2)")]
    public decimal PriceAtAddition { get; set; }

    [Column("discount_applied", TypeName = "decimal(18, 2)")]
    public decimal? DiscountApplied { get; set; }

    [ForeignKey("CartId")]
    [InverseProperty("CartItems")]
    public virtual Cart Cart { get; set; } = null!;

    [ForeignKey("ProductId")]
    [InverseProperty("CartItems")]
    public virtual Product Product { get; set; } = null!;
}
