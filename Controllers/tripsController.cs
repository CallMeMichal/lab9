using lab9.Entities;
using lab9.ModelsDTO;
using lab9.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace lab9.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class tripsController : ControllerBase
    {
        private readonly TripDbService _tripDbService;

        public tripsController(TripDbService tripDbService)
        {
            _tripDbService = tripDbService;
        }

        [HttpGet]
        public async Task<IActionResult> GetTripsAsync(CancellationToken cancellationToken)
        {

            IList<TripDTO> trips = await _tripDbService.GetTripAsync(cancellationToken);
            return Ok(trips);
        }


        [HttpPost("{IdTrip}/clients")]
        public async Task<IActionResult> AddClientToTrip(CancellationToken cancellationToken, ClientDTO client, int IdTrip)
        {
            var z = await _tripDbService.AddKlientToTrip(client, IdTrip);
            return Ok(z);
        }


        

    }
}
