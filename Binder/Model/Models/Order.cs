using System;
using System.Collections.Generic;

namespace Models;

public partial class Order
{
    public int Id { get; set; }

    public int CustomerId { get; set; }

    public string Status { get; set; }

    public virtual User Customer { get; set; }

    public virtual ICollection<OrderProduct> OrderProducts { get; set; } = new List<OrderProduct>();
}
