using System;
using System.Collections.Generic;

namespace Management;

public partial class Customer
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string Age { get; set; } = null!;

    public string Address { get; set; } = null!;

    public virtual ICollection<Sale> Sales { get; set; } = new List<Sale>();
}
