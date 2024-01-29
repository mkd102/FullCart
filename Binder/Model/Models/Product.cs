using System;
using System.Collections.Generic;

namespace Models;

public partial class Product
{
    public int Id { get; set; }

    public string Name { get; set; }

    public string Description { get; set; }

    public int Price { get; set; }

    public int BrandId { get; set; }

    public int CategoryId { get; set; }

    public int Quantity { get; set; }

    public byte[] Image { get; set; }

    public virtual Category Category { get; set; }

    public virtual Brand IdNavigation { get; set; }

    public virtual ICollection<OrderProduct> OrderProducts { get; set; } = new List<OrderProduct>();
}
