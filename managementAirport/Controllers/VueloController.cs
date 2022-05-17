using managementAirport.Models.Data;
using managementAirport.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace managementAirport.Services.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VueloController : ControllerBase
    {
        private IRepository<Vuelo> _repository;

        public VueloController(IRepository<Vuelo> repository)
        {
            _repository = repository;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> Get()
        {
            var Vuelo = await _repository.GetAll();
            return Ok(Vuelo);
        }
        [HttpGet("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetById(int id)
        {
            var Vuelo = await _repository.GetById(id);
            return Ok(Vuelo);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> Create(Vuelo vuelo)
        {
            _ = await _repository.Create(vuelo);
            return Ok();
        }
        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Update(Vuelo vuelo)
        {
            var currentDestino = await _repository.GetById(vuelo.Id);
            if (currentDestino == null)
            {
                return BadRequest("Origen to update not found");
            }

            _ = await _repository.Update(vuelo);
            return Ok();
        }
        [HttpDelete("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Delete(int id)
        {
            var currentDestino = await _repository.GetById(id);
            if (currentDestino == null)
            {
                return BadRequest("Origen to delete not found");
            }
            _ = await _repository.Delete(id);
            return Ok();
        }

    }
}
