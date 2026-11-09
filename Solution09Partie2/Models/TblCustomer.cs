using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Solution09Partie2.Models;

public partial class TblCustomer
{
    [Key]
    public int CustomerId { get; set; }

    public string? CustomerName { get; set; }

    public string? City { get; set; }

    public DateOnly? CreationDate { get; set; }

    [JsonIgnore]
    public virtual ICollection<TblOrder> TblOrders { get; set; } = new List<TblOrder>();
}
