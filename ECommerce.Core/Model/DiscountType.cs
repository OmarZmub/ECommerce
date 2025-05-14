using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.Data.Models;

public partial class DiscountType
{
    [Key]
    public long Id { get; set; }

    [Column("type_name")]
    [StringLength(30)]
    public string TypeName { get; set; } = null!;

    [InverseProperty("DiscountType")]
    public virtual ICollection<Discount> Discounts { get; set; } = new List<Discount>();
}
