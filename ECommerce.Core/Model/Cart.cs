using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ECommerce.Data;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.Data.Models;

[Table("Cart")]
[Index("UserId", Name = "IX_Cart", IsUnique = true)]
public partial class Cart
{
    [Key]
    public long Id { get; set; }

    [Column("user_Id")]
    [ForeignKey("User")]
    public string UserId { get; set; }

    [Column("created_at", TypeName = "datetime")]
    public DateTime CreatedAt { get; set; }

    [Column("updated_at", TypeName = "datetime")]
    public DateTime UpdatedAt { get; set; }

    [Column("total_item")]
    public int TotalItem { get; set; }

    [Column("total_price", TypeName = "decimal(18, 2)")]
    public decimal TotalPrice { get; set; }

    [InverseProperty("Cart")]
    public virtual ICollection<CartItem> CartItems { get; set; } = new List<CartItem>();

    
    public virtual User User { get; set; } 
}
