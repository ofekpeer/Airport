using FlightControl.Models.Models;
using FlightControl.Servies.Repositories;
using Microsoft.AspNetCore.Mvc;
using PlaneControl.Logic;
using PlaneControl.Logic.Contexts;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlaneController : ControllerBase
    {
        public readonly IRepository<Flight> plane;
        public readonly Airterminal airterminal;
        public readonly DataContext dataContext;

        public PlaneController(IRepository<Flight> plane, Airterminal airterminal, DataContext dataContext)
        {
            this.plane = plane;
            this.airterminal = airterminal; 
            this.dataContext = dataContext;
        }
        // GET: api/<PlaneController>
        [HttpGet]
        public async Task<IEnumerable<Flight>> Get()
        {
            return await plane.GetAll();
        }

        // GET api/<PlaneController>/5
        [HttpGet("{id}")]
        public async Task<Flight?> Get(int id)
        {
            return await plane.GetById(id);
        }

        // POST api/<PlaneController>
        [HttpPost]
        public async void Post([FromBody] Flight value)
        {
            if (value != null)
            {
                await plane.Add(value);
                //airterminal.data = dataContext;
                airterminal.TeminalsLogic(value);
            }
        }

        // DELETE api/<PlaneController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            plane.Delete(id);
        }
    }
}
