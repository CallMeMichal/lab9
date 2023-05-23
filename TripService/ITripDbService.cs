using lab9.Entities;
using lab9.ModelsDTO;
using Microsoft.AspNetCore.Mvc;

namespace lab9.Service
{
    public interface ITripDbService
    {
        public Task<bool> AddKlientToTrip(ClientDTO client, int idTrip);
    }
}
