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
    public class AerolineaController : ControllerBase
    {
        private IRepository<Aerolinea> _repository;

        public AerolineaController(IRepository<Aerolinea> repository)
        {
            _repository = repository;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> Get()
        {
            var Aerolinea = await _repository.GetAll();
            return Ok(Aerolinea);
        }
        [HttpGet("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetById(int id)
        {
            var Aerolinea = await _repository.GetById(id);
            return Ok(Aerolinea);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> Create(Aerolinea aerolinea)
        {
            _ = await _repository.Create(aerolinea);
            return Ok();
        }
        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Update(Aerolinea aerolinea)
        {
            var currentDestino = await _repository.GetById(aerolinea.Id);
            if (currentDestino == null)
            {
                return BadRequest("Origen to update not found");
            }

            _ = await _repository.Update(aerolinea);
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
