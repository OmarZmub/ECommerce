using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.Data.Models;

public partial class ProductImage
{
    [Key]
    public long Id { get; set; }

    [Column("product_Id")]
    public long ProductId { get; set; }

    [Column("image_url")]
    [StringLength(200)]
    public string ImageUrl { get; set; } = null!;

    [ForeignKey("ProductId")]
    [InverseProperty("ProductImages")]
    public virtual Product Product { get; set; } = null!;
}
