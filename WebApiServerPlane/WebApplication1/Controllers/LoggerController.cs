using FlightControl.Models.Models;
using FlightControl.Servies.Repositories;
using Microsoft.AspNetCore.Mvc;
using PlaneControl.Logic;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoggerController : ControllerBase
    {
        public readonly IRepository<Logger> logger;

        public LoggerController(IRepository<Logger> logger)
        {
            this.logger = logger;
        }
        // GET: api/<LoggerController>
        [HttpGet]
        public async Task<IEnumerable<Logger>> Get()
        {
            return await logger.GetAll();
        }

        // GET api/<LoggerController>/5
        [HttpGet("{id}")]
        public async Task<Logger> GetById(int id)
        {
            return await logger.GetById(id);
        }

        // POST api/<LoggerController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<LoggerController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<LoggerController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
