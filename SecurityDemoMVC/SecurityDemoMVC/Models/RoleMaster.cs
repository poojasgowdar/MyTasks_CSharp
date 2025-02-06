using System;
using System.Collections.Generic;

namespace SecurityDemoMVC.Models;

public partial class RoleMaster
{
    public int Id { get; set; }

    public string? RollName { get; set; }

    public virtual ICollection<UserRolesMapping> UserRolesMappings { get; set; } = new List<UserRolesMapping>();
}
