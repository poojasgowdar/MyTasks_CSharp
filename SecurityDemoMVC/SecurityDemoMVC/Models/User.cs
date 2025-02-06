using System;
using System.Collections.Generic;

namespace SecurityDemoMVC.Models;

public partial class User
{
    public int Id { get; set; }

    public string? UserName { get; set; }

    public string? UserPassword { get; set; }

    public virtual ICollection<UserRolesMapping> UserRolesMappings { get; set; } = new List<UserRolesMapping>();
}
