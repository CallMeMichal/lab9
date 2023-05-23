using lab9.Entities;
using lab9.ModelsDTO;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Server.IIS.Core;
using Microsoft.EntityFrameworkCore;
using System;
using System.Net;
using System.Net.WebSockets;

namespace lab9.Service
{
    public class TripDbService : ITripDbService
    {
        private readonly _2019sbdContext _context;

        public TripDbService(_2019sbdContext context)
        {
            _context = context;
        }

        public async Task<IList<TripDTO>> GetTripAsync(CancellationToken cancellationToken = default)
        {
            return await _context.Trips.Select(t => new TripDTO(t.Name, t.Description, t.DateFrom, t.DateTo, t.MaxPeople, t.ClientTrips, t.IdCountries)).ToListAsync();


        }




        public async Task<bool> AddKlientToTrip(ClientDTO client)
        {
            try
            {
                var recordExist = _context.Clients.FirstOrDefault(x => x.Pesel == client.Pesel);
                //var clientRegistered = _context.ClientTrips.Any(t => t.IdClient == id && t.IdTrip = client.IdTrip);
                var TripExist = _context.Trips.Any(x => x.IdTrip == client.IdTrip);
                int clientsCount = await _context.Clients.CountAsync();
                if (recordExist == null)
                {


                    Client client1 = new()
                    {
                        FirstName = client.FirstName,
                        LastName = client.LastName,
                        Email = client.Email,
                        Telephone = client.Telephone,
                        Pesel = client.Pesel,
                        IdClient = clientsCount

                    };
                        _context.Add(client1);


                    ClientTrip cl1 = new()
                    {
                        PaymentDate=client.PaymentDate
                    };
                    _context.Add(cl1);

                    Trip trip1 = new()
                    {
                        IdTrip= client.IdTrip,
                        Name = client.Name,
                        
                    };
                    _context.Add(trip1);

                    
                }
                _context.SaveChanges();

                return true;
            }
            catch(Exception ex)
            {
                return false;
            }            
            
        }

    }
}

