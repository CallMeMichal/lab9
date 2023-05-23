using System;
using System.Collections.Generic;

namespace lab9.Entities;

public partial class Trip
{
    public int IdTrip { get; set; }

    public string Name { get; set; }

    public string Description { get; set; }

    public DateTime DateFrom { get; set; }

    public DateTime DateTo { get; set; }

    public int MaxPeople { get; set; }

    public virtual ICollection<ClientTrip> ClientTrips { get; set; } = new List<ClientTrip>();

    public virtual ICollection<Country> IdCountries { get; set; } = new List<Country>();
}
