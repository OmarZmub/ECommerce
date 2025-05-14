using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.Data.Models;

public partial class OrderItem
{
    [Key]
    public long Id { get; set; }

    [Column("order_Id")]
    public long OrderId { get; set; }

    [Column("product_Id")]
    public long ProductId { get; set; }

    [Column("quantity")]
    public int Quantity { get; set; }

    [Column("price_at_purchase", TypeName = "decimal(18, 2)")]
    public decimal PriceAtPurchase { get; set; }

    [ForeignKey("OrderId")]
    [InverseProperty("OrderItems")]
    public virtual Order Order { get; set; } = null!;

    [ForeignKey("ProductId")]
    [InverseProperty("OrderItems")]
    public virtual Product Product { get; set; } = null!;
}
