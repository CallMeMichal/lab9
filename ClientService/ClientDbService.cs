using lab9.Entities;
using Microsoft.AspNetCore.Mvc;

namespace lab9.ClientService
{
    public class ClientDbService : IClientDbService
    {
        private readonly _2019sbdContext _context;

        public ClientDbService(_2019sbdContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> DeleteClient(int idClient)
        {


            var a = await _context.Clients.FindAsync(idClient);
            var b = _context.ClientTrips.Where(x => x.IdClient == idClient);


            if (!(b.Any()))
            {
                _context.Remove(a);
                _context.SaveChangesAsync();
                return new ObjectResult("OK - Usunięto klienta") { StatusCode = 200 };

            }
            else
            {
                return new ObjectResult("Nie można usunąć klienta, ponieważ ma przypisaną wycieczkę.") { StatusCode = 400 };

            }






        }
    }
}
