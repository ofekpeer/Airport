using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightControl.Servies.Repositories
{
    public interface IRepository<T> where T : class
    {
        Task<T?> GetById(int id);
        Task<ICollection<T>> GetAll();
        Task<T> Add(T item);
        Task<bool> Delete(int id);
        Task<bool> UpDate(T item);
    }
}
