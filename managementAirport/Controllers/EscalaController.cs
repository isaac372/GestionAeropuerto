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
    public class EscalaController : ControllerBase
    {
        private IRepository<Escala> _repository;

        public EscalaController(IRepository<Escala> repository)
        {
            _repository = repository;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> Get()
        {
            var escala = await _repository.GetAll();
            return Ok(escala);
        }
        [HttpGet("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetById(int id)
        {
            var escala = await _repository.GetById(id);
            return Ok(escala);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> Create(Escala escala)
        {
            _ = await _repository.Create(escala);
            return Ok();
        }
        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Update(Escala escala)
        {
            var currentDestino = await _repository.GetById(escala.Id);
            if (currentDestino == null)
            {
                return BadRequest("Origen to update not found");
            }

            _ = await _repository.Update(escala);
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
