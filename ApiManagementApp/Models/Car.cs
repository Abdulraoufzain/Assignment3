using System;
using System.Collections.Generic;

namespace Management;

public class Car
{
    public int Id { get; set; }
    public string Name { get; set; }

    public string Model { get; set; } = null!;

    public DateTime Year { get; set; }

    public string Gear { get; set; } = null!;

    public string? KmKm { get; set; } 

    public ICollection<Sale> Sales { get; set; } = new List<Sale>();
    public string KM { get; set; }
}
