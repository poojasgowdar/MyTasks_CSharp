using System;
using System.Collections.Generic;

namespace SecurityDemoMVC.Models;

public partial class UserRolesMapping
{
    public int Id { get; set; }

    public int UserId { get; set; }

    public int RoleId { get; set; }

    public virtual RoleMaster Role { get; set; } = null!;

    public virtual User User { get; set; } = null!;
}
