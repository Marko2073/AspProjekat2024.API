using AspProjekat2024.Application.DTO.Creates;
using AspProjekat2024.Application.UseCases.Commands;
using AspProjekat2024.Implementation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Reflection.Metadata;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AspProjekat2024.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PricesController : ControllerBase
    {
        private UseCaseHandler _handler;
        public PricesController(UseCaseHandler handler)
        {
            _handler = handler;
        }
        // GET: api/<PricesController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<PricesController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<PricesController>
        [HttpPost]
        [Authorize]
        public IActionResult Post([FromBody] CreatePriceDto dto, [FromServices] ICreatePriceCommand command)
        {
            try
            {
                _handler.HandleCommand(command, dto);
                return StatusCode(201);
            }
            catch
            {
                return StatusCode(500);
            }



        }

        // PUT api/<PricesController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<PricesController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
