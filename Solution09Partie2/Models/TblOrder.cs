using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Solution09Partie2.Models;

public partial class TblOrder
{
    [Key]
    public int OrderId { get; set; }

    public int? CustomerId { get; set; }

    public int? ProductId { get; set; }

    public DateTime? OrderDate { get; set; }

    public int? OrderQuantity { get; set; }

    public virtual TblCustomer? Customer { get; set; }

    public virtual TblProduct? Product { get; set; }
}
