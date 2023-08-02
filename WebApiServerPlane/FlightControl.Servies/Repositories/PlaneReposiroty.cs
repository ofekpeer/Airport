
using FlightControl.Models.Models;
using Microsoft.EntityFrameworkCore;
using PlaneControl.Logic.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightControl.Servies.Repositories
{
    public class PlaneReposiroty : IRepository<Flight>
    {
        public readonly DataContext Context;
        public PlaneReposiroty(DataContext context)
        {
            Context = context;
        }

        public async Task<Flight> Add(Flight item)
        {
            Context.Flights.Add(item);
            Context.SaveChanges();
            return item;
        }

        public async Task<bool> Delete(int id)
        {
            return true;
        }

        public async Task<ICollection<Flight>> GetAll()
        {
            //foreach (var fFlight in Context.Flights.Include(p => p.Terminal).ToList())
            //    fFlight.Terminal.Flights = null;
            return await Context.Flights
                .Include(p => p.Terminal).ToListAsync();
        }

        public async Task<Flight> GetById(int id)
        {
            return Context.Flights.FirstOrDefault(plane => plane.Id == id);
        }

        public Task<bool> UpDate(Flight item)
        {
            throw new NotImplementedException();
        }
    }
}
