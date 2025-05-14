using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ECommerce.Data;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.Data.Models;

public partial class Review
{
    [Key]
    public long Id { get; set; }

    [Column("user_Id")]
    [ForeignKey("User")]
    public string UserId { get; set; }

    [Column("product_Id")]
    public long ProductId { get; set; }

    [Column("rating")]
    public int? Rating { get; set; }

    [Column("comment")]
    [StringLength(100)]
    public string? Comment { get; set; }

    [Column("review_date", TypeName = "datetime")]
    public DateTime ReviewDate { get; set; }

    [ForeignKey("ProductId")]
    [InverseProperty("Reviews")]
    public virtual Product Product { get; set; } = null!;

    
    public virtual User User { get; set; } = null!;
}
