using lab9.Entities;

namespace lab9.ModelsDTO
{
    public class TripDTO
    {
        public TripDTO(string name, string description, DateTime dateFrom, DateTime dateTo, int maxPeople, ICollection<ClientTrip> clientTrips, ICollection<Country> idCountries)
        {
            Name = name;
            Description = description;
            DateFrom = dateFrom;
            DateTo = dateTo;
            MaxPeople = maxPeople;
            ClientTrips = clientTrips;
            IdCountries = idCountries;
        }

        public string Name { get; }
        public string Description { get; }
        public DateTime DateFrom { get; }
        public DateTime DateTo { get; }

        public int MaxPeople { get; }
        public virtual ICollection<ClientTrip> ClientTrips { get; } = new List<ClientTrip>();
        public virtual ICollection<Country> IdCountries { get; } = new List<Country>();

    }



    public class ViewModel222
    {
        public ClientDTO ClientDTO { get; set; }
         public TripDTO TripDTO { get; set;}
        

    }
}
