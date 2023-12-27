using System;
using System.Collections.Generic;

namespace ProductAccounting.Models;

public partial class User
{
    public int IdUser { get; set; }

    public string Login { get; set; } = null!;

    public string Password { get; set; } = null!;

    public string Email { get; set; } = null!;

    public virtual ICollection<ShoppingList> ShoppingLists { get; } = new List<ShoppingList>();

    public virtual ICollection<StoredProduct> StoredProducts { get; } = new List<StoredProduct>();
}
