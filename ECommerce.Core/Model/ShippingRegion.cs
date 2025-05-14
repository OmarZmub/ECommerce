using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.Data.Models;

public partial class ShippingRegion
{
    [Key]
    public long Id { get; set; }

    [Column("region_name")]
    [StringLength(50)]
    public string RegionName { get; set; } = null!;

    [Column("shipping_cost", TypeName = "decimal(6, 2)")]
    public decimal ShippingCost { get; set; }

    public int EstimatedDeliveryDays { get; set; }

    [Column("IsCODAvailable")]
    public bool IsCodavailable { get; set; }

    [StringLength(250)]
    public string? Notes { get; set; }

    [InverseProperty("Region")]
    public virtual ICollection<Address> Addresses { get; set; } = new List<Address>();
}
