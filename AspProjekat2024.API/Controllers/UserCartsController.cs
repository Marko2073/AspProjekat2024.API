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
    public class UserCartsController : ControllerBase
    {
        private readonly UseCaseHandler _handler;
        public UserCartsController(UseCaseHandler handler)
        {
            _handler = handler;
        }
        // GET: api/<UserCartsController>
        [HttpGet]
        public IActionResult Get([FromQuery] BaseSearch search, [FromServices] IGetOrdersQuery query)
        {
            return Ok(_handler.HandleQuery(query, search));
        }

        // POST api/<UserCartsController>
        [HttpPost]
        [Authorize]
        public IActionResult Post([FromBody] CreateUserCartDto dto, [FromServices] ICreateUserCartCommand command)
        {
            _handler.HandleCommand(command, dto);
            return StatusCode(201);

        }

       
    }
}
