using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using webapi.event_.Domains;
using webapi.event_.Interfaces;

namespace webapi.event_.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class TiposEventosController : ControllerBase
    {
        private readonly ITiposEventosRepository _tiposEventosRepository;

        public TiposEventosController(ITiposEventosRepository tiposEventosRepository)
        {
            _tiposEventosRepository = tiposEventosRepository;
        }

        //cadastrar
        [HttpPost]
        public IActionResult Post(TiposEventos tiposEventos)
        {
            try
            {
                _tiposEventosRepository.Cadastrar(tiposEventos);

                return Created();
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }
        //deletar
        [HttpDelete("{id}")]
        public IActionResult DeleteById(Guid id)
        {
            try
            {
                _tiposEventosRepository.Deletar(id);
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
                List<TiposEventos> listaDeEventos = _tiposEventosRepository.Listar();
                return Ok(listaDeEventos);
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }

        //BuscarPorId 
        [HttpGet("BuscarPorId/{id}")]
        public IActionResult GetById(Guid id)
        {
            try
            {
                TiposEventos tiposEventosBuscado = _tiposEventosRepository.BuscarPorId(id);
                return Ok(tiposEventosBuscado);
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }


        [HttpPut("{id}")]
        public IActionResult Put(Guid id, TiposEventos tiposEventos)
        {
            try
            {
                _tiposEventosRepository.Atualizar(id, tiposEventos);

                return NoContent();
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }

        }
    }
}
