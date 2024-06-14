using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AspProjekat2024.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SpecificationsController : ControllerBase
    {
        // GET: api/<SpecificationsController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<SpecificationsController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<SpecificationsController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<SpecificationsController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<SpecificationsController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
