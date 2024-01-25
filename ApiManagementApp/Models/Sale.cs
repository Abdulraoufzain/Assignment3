using System;
using System.Collections.Generic;

namespace Management;

public partial class Sale
{
    public int Id { get; set; }

    public string Total { get; set; } = null!;

    public int CarId { get; set; }

    public int CoustomerId { get; set; }

    public virtual Car Car { get; set; } = null!;

    public virtual Customer Coustomer { get; set; } = null!;
}
