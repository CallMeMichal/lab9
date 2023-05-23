using lab9.Entities;

namespace lab9.ModelsDTO
{
    public class ClientDTO
    {
        public ClientDTO(string firstName, string lastName, string email, string telephone, string pesel, int idTrip, string name, DateTime paymentDate)
        {
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            Telephone = telephone;
            Pesel = pesel;
            IdTrip = idTrip;
            Name = name;
            PaymentDate = paymentDate;
        }

        public string FirstName { get;}

        public string LastName { get; }

        public string Email { get;}

        public string Telephone { get; }

        public string Pesel { get; }

        public int IdTrip { get;}

        public string Name { get; }
        public DateTime PaymentDate { get;}

        



    }
}


