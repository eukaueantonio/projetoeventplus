using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using webapi.event_.Domains;
using webapi.event_.Interfaces;

namespace webapi.event_.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class PresencasEventosController : ControllerBase
    {
        private readonly IPresencasEventosRepository _presencasEventosRepository;

        public PresencasEventosController(IPresencasEventosRepository presencasEventosRepository)
        {
            _presencasEventosRepository = presencasEventosRepository;
        }

        [HttpPut]


        public IActionResult Put(Guid id, PresencasEventos presencaEvento)
        {
            try
            {
                _presencasEventosRepository.Atualizar(id, presencaEvento);
                return NoContent();
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpDelete("{Id}")]
        public IActionResult Delete(Guid Id)
        {
            try
            {
                _presencasEventosRepository.Deletar(Id);
                return NoContent();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                List<PresencasEventos> ListaPresencas = _presencasEventosRepository.Listar();
                return Ok(ListaPresencas);
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpGet("ListarMinhas/{Id}")]
        public IActionResult Get(Guid Id)
        {
            try
            {
                List<PresencasEventos> ListaMinhas = _presencasEventosRepository.ListarMinhas(Id);
                return Ok(ListaMinhas);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpGet("BuscarPorId/{id}")]
        public IActionResult GetById(Guid Id)
        {
            try
            {
                PresencasEventos presencaBuscada = _presencasEventosRepository.BuscarPorId(Id);

                return Ok(presencaBuscada);
            }

            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}