using System;
using System.Collections.Generic;

namespace ProductAccounting.Models;

public partial class ShoppingList
{
    public int IdShopingList { get; set; }

    public string NameProduct { get; set; } = null!;

    public int? Count { get; set; }

    public int IdUser { get; set; }

    public virtual User IdUserNavigation { get; set; } = null!;
}
