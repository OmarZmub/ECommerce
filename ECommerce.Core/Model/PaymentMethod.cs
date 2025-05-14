using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.Data.Models;

public partial class PaymentMethod
{
    [Key]
    public long Id { get; set; }

    [Column("method_name")]
    [StringLength(20)]
    public string MethodName { get; set; } = null!;

    [InverseProperty("PaymentMethod")]
    public virtual ICollection<BankFee> BankFees { get; set; } = new List<BankFee>();

    [InverseProperty("PaymentMethod")]
    public virtual ICollection<PaymentDetail> PaymentDetails { get; set; } = new List<PaymentDetail>();
}
