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
    public class OrigenController : ControllerBase
    {
        private IRepository<Origen> _repository;

        public OrigenController(IRepository<Origen> repository)
        {
            _repository = repository;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> Get()
        {
            var Origen = await _repository.GetAll();
            return Ok(Origen);
        }
        [HttpGet("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetById(int id)
        {
            var Origen = await _repository.GetById(id);
            return Ok(Origen);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> Create(Origen Origen)
        {
            _ = await _repository.Create(Origen);
            return Ok();
        }
        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Update(Origen Origen)
        {
            var currentProduct = await _repository.GetById(Origen.Id);
            if (currentProduct == null)
            {
                return BadRequest("Origen to update not found");
            }

            _ = await _repository.Update(Origen);
            return Ok();
        }
        [HttpDelete("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Delete(int id)
        {
            var currentOrigen = await _repository.GetById(id);
            if (currentOrigen == null)
            {
                return BadRequest("Origen to delete not found");
            }
            _ = await _repository.Delete(id);
            return Ok();
        }

    }
}
