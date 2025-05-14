using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.Data.Models;

public partial class PaymentDetail
{
    [Key]
    public long Id { get; set; }

    [Column("order_Id")]
    public long OrderId { get; set; }

    [Column("payment_method_Id")]
    public long PaymentMethodId { get; set; }

    [Column("amount_paid", TypeName = "decimal(6, 2)")]
    public decimal AmountPaid { get; set; }

    [Column("payment_date", TypeName = "datetime")]
    public DateTime PaymentDate { get; set; }

    [Column("status_Id")]
    public long StatusId { get; set; }

    [ForeignKey("OrderId")]
    [InverseProperty("PaymentDetails")]
    public virtual Order Order { get; set; } = null!;

    [ForeignKey("PaymentMethodId")]
    [InverseProperty("PaymentDetails")]
    public virtual PaymentMethod PaymentMethod { get; set; } = null!;

    [ForeignKey("StatusId")]
    [InverseProperty("PaymentDetails")]
    public virtual PaymentStatus Status { get; set; } = null!;
}
