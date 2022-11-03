using System;
using System.Collections.Generic;

namespace ApI.Data;

public class Garage
{
    public Guid Id { get; set; }

    public string Name { get; set; }

    public List<Door> Doors { get; set; }
}