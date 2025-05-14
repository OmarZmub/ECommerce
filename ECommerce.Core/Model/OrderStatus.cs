using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.Data.Models;

[Table("OrderStatus")]
public partial class OrderStatus
{
    [Key]
    public long Id { get; set; }

    [Column("status_name")]
    [StringLength(20)]
    public string StatusName { get; set; } = null!;

    [InverseProperty("Status")]
    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
}
