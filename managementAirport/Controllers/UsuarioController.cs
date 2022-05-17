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
    public class UsuarioController : ControllerBase
    {
        private IUsuario _repository;
        private IModulos _Modulorepository;


        public UsuarioController(IUsuario repository, IModulos ModuloReposity)
        {
            _repository = repository;
            _Modulorepository = ModuloReposity;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> Get()
        {
            var usuario = await _repository.GetAll();
            return Ok(usuario);
        }
        [HttpGet("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetById(int id)
        {
            var usuario = await _repository.GetById(id);
            return Ok(usuario);
        }

        [HttpPost]
        [Route("Login")]
        public async Task<UsuariosResponse> Login(Usuario usuario)
        {
            try
            {
                UsuariosResponse NewInstance = await _repository.Login(usuario.Nombre, usuario.Password);

                var Modules = await _Modulorepository.GetByIdRol(NewInstance.IdRol);

                foreach (var item in Modules)
                {
                    NewInstance.modulos.Add(item);
                }

                return NewInstance;
            }
            catch (Exception)
            {
                return new UsuariosResponse { };
            }
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> Create(Usuario usuario)
        {
            _ = await _repository.Create(usuario);
            return Ok();
        }
        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Update(Usuario usuario)
        {
            var currentRol = await _repository.GetById(usuario.Id);
            if (currentRol == null)
            {
                return BadRequest("Rol to update not found");
            }

            _ = await _repository.Update(usuario);
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
