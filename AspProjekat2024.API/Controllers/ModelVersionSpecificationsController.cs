﻿using AspProjekat2024.Application.DTO.Creates;
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
    public class ModelVersionSpecificationsController : ControllerBase
    {
        private UseCaseHandler _handler;
        public ModelVersionSpecificationsController(UseCaseHandler handler)
        {
            _handler = handler;
        }
        // GET: api/<ModelVersionSpecificationsController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<ModelVersionSpecificationsController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<ModelVersionSpecificationsController>
        [HttpPost]
        [Authorize]
        public IActionResult Post([FromBody] CreateModelVersionSpecificationDto dto, [FromServices] ICreateModelVersionSpecification command)
        {
            try
            {
                _handler.HandleCommand(command, dto);
                return StatusCode(201);
            }
            catch(Exception ex)
            {
                return StatusCode(500);
            }
        }

        // PUT api/<ModelVersionSpecificationsController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ModelVersionSpecificationsController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
