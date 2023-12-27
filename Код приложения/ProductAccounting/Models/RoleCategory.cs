using System;
using System.Collections.Generic;

namespace ProductAccounting.Models;

public partial class RoleCategory
{
    public int IdCategory { get; set; }

    public string NameCategory { get; set; } = null!;

    public virtual ICollection<User> Users { get; } = new List<User>();
}
