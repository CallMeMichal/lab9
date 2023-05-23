using System;
using System.Collections.Generic;

namespace lab9.Entities;

public partial class Country
{
    public int IdCountry { get; set; }

    public string Name { get; set; }

    public virtual ICollection<Trip> IdTrips { get; set; } = new List<Trip>();
}
