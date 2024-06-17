using AspProjekat2024.Application.DTO.Creates;
using AspProjekat2024.Application.UseCases.Commands;
using AspProjekat2024.Implementation;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AspProjekat2024.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserCartsController : ControllerBase
    {
        private readonly UseCaseHandler _handler;
        public UserCartsController(UseCaseHandler handler)
        {
            _handler = handler;
        }
        // GET: api/<UserCartsController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<UserCartsController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<UserCartsController>
        [HttpPost]
        public IActionResult Post([FromBody] CreateUserCartDto dto, [FromServices] ICreateUserCartCommand command)
        {
            _handler.HandleCommand(command, dto);
            return StatusCode(201);

        }

        // PUT api/<UserCartsController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<UserCartsController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
