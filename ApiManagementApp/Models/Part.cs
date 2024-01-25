using System;
using System.Collections.Generic;

namespace Management;

public partial class Part
{
    public int Id { get; set; }

    public string Name { get; set; } 

    public string Price { get; set; } = null!;

    public string Qunantity { get; set; } = null!;

    public int SupliersId { get; set; }

    public virtual Supplier Supliers { get; set; } = null!;
}
