using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.Data.Models;

public partial class StockMovement
{
    [Key]
    public long Id { get; set; }

    [Column("product_Id")]
    public long ProductId { get; set; }

    [Column("type")]
    [StringLength(20)]
    public string Type { get; set; } = null!;

    [Column("quantity")]
    public int Quantity { get; set; }

    [Column("movement_date", TypeName = "datetime")]
    public DateTime MovementDate { get; set; }

    [Column("reason")]
    [StringLength(150)]
    public string? Reason { get; set; }

    [ForeignKey("ProductId")]
    [InverseProperty("StockMovements")]
    public virtual Product Product { get; set; } = null!;
}
