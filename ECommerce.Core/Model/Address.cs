using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ECommerce.Data;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.Data.Models;

public partial class Address
{
    [Key]
    [Column("id")]
    public long Id { get; set; }

    [ForeignKey("User")]
    [Column("user_Id")]
    public string UserId { get; set; }

    [Column("region_Id")]
    public long RegionId { get; set; }

    [Column("street")]
    [StringLength(30)]
    public string? Street { get; set; }

    [Column("city")]
    [StringLength(30)]
    public string? City { get; set; }

    [Column("postal_code")]
    [StringLength(30)]
    public string? PostalCode { get; set; }

    [Column("is_primary")]
    public bool? IsPrimary { get; set; }

    [Column("country")]
    [StringLength(50)]
    public string? Country { get; set; }

    [Column("bulding_number")]
    [StringLength(10)]
    public string? BuldingNumber { get; set; }

    [Column("floor_number")]
    [StringLength(10)]
    public string? FloorNumber { get; set; }

    [Column("apartment_number")]
    [StringLength(10)]
    public string? ApartmentNumber { get; set; }

    [Column("created_at", TypeName = "datetime")]
    public DateTime? CreatedAt { get; set; }

    [Column("updated_at", TypeName = "datetime")]
    public DateTime? UpdatedAt { get; set; }

    [Column("notes")]
    [StringLength(250)]
    public string? Notes { get; set; }

    [InverseProperty("ShippingAddress")]
    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();

    [ForeignKey("RegionId")]
    [InverseProperty("Addresses")]
    public virtual ShippingRegion Region { get; set; } = null!;



    public virtual User User { get; set; } 
}
