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
    public class DestinoController : ControllerBase
    {
        private IRepository<Destino> _repository;

        public DestinoController(IRepository<Destino> repository)
        {
            _repository = repository;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> Get()
        {
            var Destino = await _repository.GetAll();
            return Ok(Destino);
        }
        [HttpGet("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetById(int id)
        {
            var Destino = await _repository.GetById(id);
            return Ok(Destino);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> Create(Destino destino)
        {
            _ = await _repository.Create(destino);
            return Ok();
        }
        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Update(Destino destino)
        {
            var currentDestino = await _repository.GetById(destino.Id);
            if (currentDestino == null)
            {
                return BadRequest("Origen to update not found");
            }

            _ = await _repository.Update(destino);
            return Ok();
        }

        /// <summary>
        /// Funcion para la eliminacion de un destino
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
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
