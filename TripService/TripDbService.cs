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




        public async Task<bool> AddKlientToTrip(ClientDTO client,int idTrip)
        {
            try
            {

                Client mainClient;
                var recordExist = _context.Clients.FirstOrDefault(x => x.Pesel == client.Pesel);
                bool tripInClient = false;
               
                bool TripExist = _context.Trips.Any(x => x.IdTrip == client.IdTrip);

                int clientsCount = await _context.Clients.CountAsync();

                if (!TripExist)
                {
                    throw new Exception("trip nie istnieje");
                }

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
                       IdClient = client1.IdClient,
                       IdTrip = idTrip,
                       RegisteredAt= DateTime.Now,
                       PaymentDate=null,
                    };
                    _context.Add(cl1);

                    //sprawdzenie wycieczki
                   // tripInClient = _context.ClientTrips.Any(x => x.IdClient == client1.IdClient);
                    mainClient = client1;



                }
                else
                {
                    
                    Client client1 = recordExist;
                    //sprawdzenie wycieczki
                   // tripInClient = _context.ClientTrips.Any(x => x.IdClient == client1.IdClient);
                    mainClient = client1;
                }

                if(tripInClient)
                {
                    throw new Exception("Klient jest zapisany na wycieczke");
                }
                else
                {
                    ClientTrip clientTrip = new()
                    {
                        IdClient= mainClient.IdClient,
                        IdTrip  = idTrip,
                        RegisteredAt= DateTime.Now,
                        PaymentDate=null,
                    };
                    
                }

                await _context.SaveChangesAsync();


                return true;
            }
            catch(Exception ex)
            {

               
                return false;
            }            
            
        }

    }
}

