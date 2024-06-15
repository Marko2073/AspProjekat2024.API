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
    public class PurchasesController : ControllerBase
    {
        private UseCaseHandler _handler;
        public PurchasesController(UseCaseHandler handler)
        {
            _handler = handler;
        }

        // GET: api/<PurchasesController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<PurchasesController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<PurchasesController>
        [HttpPost]
        [Authorize]
        public IActionResult Post([FromBody] CreatePurchaseDto dto, [FromServices] ICreatePurchaseCommand command)
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

        // PUT api/<PurchasesController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<PurchasesController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}