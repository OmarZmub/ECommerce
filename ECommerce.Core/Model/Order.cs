using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ECommerce.Data;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.Data.Models;

public partial class Order
{
    [Key]
    [Column("id")]
    public long Id { get; set; }

    [Column("user_Id")]
    [ForeignKey("User")]

    public string UserId { get; set; }

    [Column("order_date", TypeName = "datetime")]
    public DateTime OrderDate { get; set; }

    [Column("status_Id")]
    public long StatusId { get; set; }

    [Column("total_amount", TypeName = "decimal(6, 2)")]
    public decimal TotalAmount { get; set; }

    [Column("shipping_address_Id")]
    public long ShippingAddressId { get; set; }

    [Column("shipping_cost", TypeName = "decimal(6, 2)")]
    public decimal ShippingCost { get; set; }

    [Column("discount_Id")]
    public long? DiscountId { get; set; }

    [StringLength(30)]
    public string RefNumber { get; set; } = null!;

    [Column(TypeName = "datetime")]
    public DateTime LastModifiedDate { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? DeletedDate { get; set; }

    public bool Active { get; set; }

    [ForeignKey("DiscountId")]
    [InverseProperty("Orders")]
    public virtual Discount? Discount { get; set; }

    [InverseProperty("Order")]
    public virtual ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();

    [InverseProperty("Order")]
    public virtual ICollection<PaymentDetail> PaymentDetails { get; set; } = new List<PaymentDetail>();

    [ForeignKey("ShippingAddressId")]
    [InverseProperty("Orders")]
    public virtual Address ShippingAddress { get; set; } 

    [ForeignKey("StatusId")]
    [InverseProperty("Orders")]
    public virtual OrderStatus Status { get; set; }

    
    public virtual User User { get; set; } 
}
