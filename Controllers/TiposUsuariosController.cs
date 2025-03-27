using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using webapi.event_.Domains;
using webapi.event_.Interfaces;

namespace webapi.event_.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class TiposUsuariosController : ControllerBase
    {
        private readonly ITiposUsuariosRepository _tiposUsuariosRepository;

        public TiposUsuariosController(ITiposUsuariosRepository tiposUsuariosRepository)
        {
            _tiposUsuariosRepository = tiposUsuariosRepository;
        }
        //cadastrar
        [HttpPost]
        public IActionResult Post(TiposUsuarios tiposUsuarios)
        {
            try
            {
                _tiposUsuariosRepository.Cadastrar(tiposUsuarios);
                return StatusCode(201, tiposUsuarios);
            }
            catch (Exception error)
            {

                return BadRequest(error.Message);
            }
        }
        //deletar
        [HttpDelete("{id}")]
        public IActionResult DeleteById(Guid id)
        {
            try
            {
                _tiposUsuariosRepository.Deletar(id);
                return NoContent();
            }
            catch (Exception)
            {

                throw;
            }
        }
        //listar
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                List<TiposUsuarios> listaDosUsuarios = _tiposUsuariosRepository.Listar();
                return Ok(listaDosUsuarios);
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }
        //buscar por id 
        [HttpGet("BuscarPorId/{id}")]
        public IActionResult GetById(Guid id)
        {
            try
            {
                TiposUsuarios tiposUsuariosBuscado = _tiposUsuariosRepository.BuscarPorId(id);
                return Ok(tiposUsuariosBuscado);
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }
        //atualizar 
        [HttpPut("{id}")]
        public IActionResult Put(Guid id, TiposUsuarios tiposUsuarios)
        {
            try
            {
                _tiposUsuariosRepository.Atualizar(id, tiposUsuarios);
                return NoContent();
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }
    }
}