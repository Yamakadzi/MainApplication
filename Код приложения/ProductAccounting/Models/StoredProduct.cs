using System;
using System.Collections.Generic;

namespace ProductAccounting.Models;

public partial class StoredProduct
{
    public int IdProduct { get; set; }

    public string NameProduct { get; set; } = null!;

    public DateTime ShelfLife { get; set; }

    public int IdUser { get; set; }

    public int? Count { get; set; }

    public virtual User IdUserNavigation { get; set; } = null!;
}
