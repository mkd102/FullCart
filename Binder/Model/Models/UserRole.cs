using System;
using System.Collections.Generic;

namespace Models;

public partial class UserRole
{
    public int UserRoleId { get; set; }

    public int UserId { get; set; }

    public int RoleId { get; set; }

    public virtual User User { get; set; }

    public virtual Role UserRoleNavigation { get; set; }
}
