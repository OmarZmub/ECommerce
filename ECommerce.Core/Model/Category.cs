using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.Data.Models;

public partial class Category
{
    [Key]
    public long Id { get; set; }

    [Column("category_name")]
    [StringLength(50)]
    public string CategoryName { get; set; } = null!;

    [Column("description")]
    [StringLength(100)]
    public string? Description { get; set; }

    [Column("created_at", TypeName = "datetime")]
    public DateTime CreatedAt { get; set; }

    [Column("updated_at", TypeName = "datetime")]
    public DateTime UpdatedAt { get; set; }

    [Column("status")]
    public bool Status { get; set; }

    [Column("parent_category_Id")]
    public long? ParentCategoryId { get; set; }

    [InverseProperty("ParentCategory")]
    public virtual ICollection<Category> InverseParentCategory { get; set; } = new List<Category>();

    [ForeignKey("ParentCategoryId")]
    [InverseProperty("InverseParentCategory")]
    public virtual Category? ParentCategory { get; set; }

    [InverseProperty("Category")]
    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
}
