using Microsoft.AspNetCore.Mvc;

namespace lab9.ClientService
{
    public interface IClientDbService
    {
        public Task<IActionResult> DeleteClient(int idClient);
    }
}
