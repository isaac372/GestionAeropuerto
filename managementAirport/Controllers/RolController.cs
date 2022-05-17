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
    public class RolController : ControllerBase
    {
        private IRepository<Rol> _repository;

        public RolController(IRepository<Rol> repository)
        {
            _repository = repository;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> Get()
        {
            var Rol = await _repository.GetAll();
            return Ok(Rol);
        }
        [HttpGet("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetById(int id)
        {
            var Rol = await _repository.GetById(id);
            return Ok(Rol);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> Create(Rol rol)
        {
            _ = await _repository.Create(rol);
            return Ok();
        }
        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Update(Rol rol)
        {
            var currentRol = await _repository.GetById(rol.Id);
            if (currentRol == null)
            {
                return BadRequest("Rol to update not found");
            }

            _ = await _repository.Update(rol);
            return Ok();
        }
        [HttpDelete("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Delete(int id)
        {
            var currentRol = await _repository.GetById(id);
            if (currentRol == null)
            {
                return BadRequest("Rol to delete not found");
            }
            _ = await _repository.Delete(id);
            return Ok();
        }
    }
}
