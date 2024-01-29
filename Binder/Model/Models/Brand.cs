using System;
using System.Collections.Generic;

namespace Models;

public partial class Brand
{
    public int Id { get; set; }

    public string Name { get; set; }

    public virtual Product Product { get; set; }
}
