using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.Data.Models;

public partial class Discount
{
    [Key]
    public long Id { get; set; }

    [Column("discount_code")]
    [StringLength(50)]
    public string DiscountCode { get; set; } = null!;

    [Column("discount_percentage", TypeName = "decimal(5, 2)")]
    public decimal DiscountPercentage { get; set; }

    [Column("discount_amount", TypeName = "decimal(18, 2)")]
    public decimal DiscountAmount { get; set; }

    [Column("start_date", TypeName = "datetime")]
    public DateTime StartDate { get; set; }

    [Column("end_date", TypeName = "datetime")]
    public DateTime EndDate { get; set; }

    [Column("discount_type_Id")]
    public long DiscountTypeId { get; set; }

    [Column("is_active")]
    public bool IsActive { get; set; }

    [ForeignKey("DiscountTypeId")]
    [InverseProperty("Discounts")]
    public virtual DiscountType DiscountType { get; set; } = null!;

    [InverseProperty("Discount")]
    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();

    [InverseProperty("Discount")]
    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
}
