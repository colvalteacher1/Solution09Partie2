using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Solution09Partie2.Models;

public partial class TblOrder
{
    [Key]
    public int OrderId { get; set; }

    public int? CustomerId { get; set; }

    public int? ProductId { get; set; }

    public DateTime? OrderDate { get; set; }

    public int? OrderQuantity { get; set; }

    [JsonIgnore]
    public virtual TblCustomer? Customer { get; set; }

    [JsonIgnore]
    public virtual TblProduct? Product { get; set; }
}
