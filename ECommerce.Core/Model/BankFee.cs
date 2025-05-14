using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.Data.Models;

public partial class BankFee
{
    [Key]
    public long Id { get; set; }

    [Column("payment_method_Id")]
    public long PaymentMethodId { get; set; }

    [Column("fee_percentage", TypeName = "decimal(5, 2)")]
    public decimal FeePercentage { get; set; }

    [Column("effective_from", TypeName = "datetime")]
    public DateTime EffectiveFrom { get; set; }

    [Column("effective_to", TypeName = "datetime")]
    public DateTime? EffectiveTo { get; set; }

    [ForeignKey("PaymentMethodId")]
    [InverseProperty("BankFees")]
    public virtual PaymentMethod PaymentMethod { get; set; } = null!;
}
