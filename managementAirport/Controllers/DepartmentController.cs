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
    public class DepartmentController : ControllerBase
    {
        private IRepository<Departamento> _repository;

        public DepartmentController(IRepository<Departamento> repository)
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
        public async Task<IActionResult> Create(Departamento departament)
        {
            _ = await _repository.Create(departament);
            return Ok();
        }
        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Update(Departamento departament)
        {
            var currentDepatament = await _repository.GetById(departament.Id);
            if (currentDepatament == null)
            {
                return BadRequest("Product to update not found");
            }

            _ = await _repository.Update(departament);
            return Ok();
        }
        [HttpDelete("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Delete(int id)
        {
            var currentDepartament = await _repository.GetById(id);
            if (currentDepartament == null)
            {
                return BadRequest("Product to delete not found");
            }
            _ = await _repository.Delete(id);
            return Ok();

        }
    }
}