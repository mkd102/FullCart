using System;
using System.Collections.Generic;

namespace Models;

public partial class User
{
    public int Id { get; set; }

    public string FirstName { get; set; }

    public string LastName { get; set; }

    public string EmailId { get; set; }

    public string Password { get; set; }

    public string Address { get; set; }

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();

    public virtual ICollection<UserRole> UserRoles { get; set; } = new List<UserRole>();
}
