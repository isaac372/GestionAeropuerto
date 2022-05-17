using managementAirport.Models.Data;
using managementAirport.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace managementAirport.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaisController : ControllerBase
    {
        private IRepository<Pai> _repository;

        public PaisController(IRepository<Pai> repository)
        {
            _repository = repository;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> Get()
        {
            var pais = await _repository.GetAll();
            return Ok(pais);
        }
        [HttpGet("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetById(int id)
        {
            var pais = await _repository.GetById(id);
            return Ok(pais);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> Create(Pai pais)
        {
            _ = await _repository.Create(pais);
            return Ok();
        }
        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Update(Pai pais)
        {
            var currentProduct = await _repository.GetById(pais.Id);
            if (currentProduct == null)
            {
                return BadRequest("Product to update not found");
            }

            _ = await _repository.Update(pais);
            return Ok();
        }
        [HttpDelete("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Delete(int id)
        {
            var currentPais = await _repository.GetById(id);
            if (currentPais == null)
            {
                return BadRequest("Product to delete not found");
            }
            _ = await _repository.Delete(id);
            return Ok();
        }


    }
}
