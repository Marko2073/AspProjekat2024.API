using AspProjekat2024.Application.DTO.Creates;
using AspProjekat2024.Application.DTO.Searches;
using AspProjekat2024.Application.UseCases.Commands;
using AspProjekat2024.Application.UseCases.Queries;
using AspProjekat2024.Implementation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AspProjekat2024.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ModelsController : ControllerBase
    {
        private UseCaseHandler _handler;
        public ModelsController(UseCaseHandler handler)
        {
            _handler = handler;
        }
        // GET: api/<ModelsController>
        [HttpGet]
        [Authorize]

        public IActionResult Get([FromQuery] BaseSearch search, [FromServices] IGetModelsQuery query)
        {
            return Ok(_handler.HandeQuery(query, search));
        }

        // GET api/<ModelsController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<ModelsController>
        [HttpPost]
        public IActionResult Post([FromBody] CreateModelDto dto, [FromServices] ICreateModelCommand command)
        {
            try
            {
                _handler.HandeCommand(command, dto);
                return StatusCode(201);
            }
            catch
            {
                return StatusCode(500);
            }
        }

        // PUT api/<ModelsController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ModelsController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
