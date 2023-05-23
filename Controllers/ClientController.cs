using lab9.ClientService;
using lab9.ModelsDTO;
using lab9.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace lab9.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientController : ControllerBase
    {

        private readonly IClientDbService _clientDbService;

        public ClientController(IClientDbService clientDbService)
        {
            _clientDbService = clientDbService;
        }

        [HttpDelete("{idClient}")]
        public async Task<IActionResult> DeleteClient(CancellationToken cancellationToken,int idClient)
        {
            var a = new ViewModel222();


            var sk = await _clientDbService.DeleteClient(idClient);
            return sk;
        }
    }
}
