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
    public class TerminalRepository : IRepository<Terminal>
    {
        public readonly DataContext Context;
        public TerminalRepository(DataContext context)
        {
            Context = context;
        }

        public Task<Terminal> Add(Terminal item)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<ICollection<Terminal>> GetAll()
        {
            return Context.Terminals.ToList();
        }

        public async Task<Terminal?> GetById(int id)
        {
            return Context.Terminals.FirstOrDefault(item => item.Id == id);
        }

        public Task<bool> UpDate(Terminal item)
        {
            throw new NotImplementedException();
        }
    }
}
