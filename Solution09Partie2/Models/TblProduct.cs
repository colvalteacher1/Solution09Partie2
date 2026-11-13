using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Solution09Partie2.Models;

public partial class TblProduct
{
    [Key]
    public int ProductId { get; set; }

    public string ProductName { get; set; } = null!;

    public string? Category { get; set; }

    public decimal? Price { get; set; }

    public int? StockQuantity { get; set; }

    public string? Description { get; set; }

    [JsonIgnore]
    public virtual ICollection<TblOrder> TblOrders { get; set; } = new List<TblOrder>();
}
