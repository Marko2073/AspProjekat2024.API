﻿using AspProjekat2024.Application.DTO.Creates;
using AspProjekat2024.Application.DTO.Searches;
using AspProjekat2024.Application.DTO.Updates;
using AspProjekat2024.Application.UseCases.Commands;
using AspProjekat2024.Application.UseCases.Queries;
using AspProjekat2024.Implementation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Reflection.Metadata;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AspProjekat2024.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ModelVersionsController : ControllerBase
    {
        private UseCaseHandler _handler;
        public ModelVersionsController(UseCaseHandler handler)
        {
            _handler = handler;
        }
        // GET: api/<ModelVersionsController>
        [HttpGet]
        public IActionResult Get([FromQuery] BaseSearch search, [FromServices] IGetModelVersionQuery query)
        {
            return Ok(_handler.HandleQuery(query, search));

        }

        // GET api/<ModelVersionsController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<ModelVersionsController>
        [HttpPost]
        [Authorize]
        public IActionResult Post([FromBody] CreateModelVersionDto dto, [FromServices] ICreateModelVersionCommand command)
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

        // PUT api/<ModelVersionsController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] UpdateModelVersionDto dto, [FromServices] IUpdateModelVersionCommand command)
        {
            try
            {

                dto.Id = id;
                _handler.HandleCommand(command, dto);
                return StatusCode(204);
            }
            catch
            {
                return StatusCode(500);

            }
        }

        // DELETE api/<ModelVersionsController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
