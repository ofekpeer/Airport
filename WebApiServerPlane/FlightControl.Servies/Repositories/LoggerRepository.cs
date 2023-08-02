
using FlightControl.Models.Models;
using PlaneControl.Logic.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightControl.Servies.Repositories
{
    public class LoggerRepository : IRepository<Logger>
    {
        public readonly DataContext Context;
        public LoggerRepository(DataContext context)
        {
            Context = context;
        }


        public async Task<Logger> Add(Logger item)
        {
            Context.Add(item);
            Context.SaveChanges();
            return item;
        }

        public async Task<bool> Delete(int id)
        {
            var loggerDelete = Context.Loggers.FirstOrDefault(x => x.Id == id)!;
            if (loggerDelete != null)
            {
                Context.Loggers.Remove(loggerDelete);
                return true;

            }
            return false;

        }

        public async Task<ICollection<Logger>> GetAll()
        {
            return Context.Loggers.ToList();
        }

        public async Task<Logger> GetById(int id)
        {
            return Context.Loggers.FirstOrDefault(x => x.Id == id)!;
        }

        public Task<bool> UpDate(Logger item)
        {
            throw new NotImplementedException();
        }
    }
}
