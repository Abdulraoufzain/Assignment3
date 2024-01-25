using System;
using System.Collections.Generic;

namespace Management;

public partial class Supplier
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string Address { get; set; } = null!;

    public virtual ICollection<Part> Parts { get; set; } = new List<Part>();
}
