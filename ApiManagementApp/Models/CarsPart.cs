using System;
using System.Collections.Generic;

namespace Management;

public partial class CarsPart
{
    public int CarId { get; set; }

    public int PartId { get; set; }

    public  Car Car { get; set; } = null!;
    public  Part Part { get; set; } = null!;
}
