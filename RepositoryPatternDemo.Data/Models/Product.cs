using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace RepositoryPatternDemo.Data.Models;

public partial class Product
{
    [Key]
    public int Id { get; set; }

    [Unicode(false)]
    public string Name { get; set; } = null!;

    [Column(TypeName = "decimal(18, 5)")]
    public decimal? Price { get; set; }
}
