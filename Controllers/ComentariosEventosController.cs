using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using webapi.event_.Domains;
using webapi.event_.Interfaces;

namespace webapi.event_.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ComentariosEventosController : Controller
    {
        
        private readonly IComentariosEventosRepository _comentariosEventosRepository;

        public ComentariosEventosController(IComentariosEventosRepository comentariosEventosRepository)
        {
            _comentariosEventosRepository = comentariosEventosRepository;
        }

        /// <summary>
        /// Endpoint para cadastrar Comentarios
        /// </summary>
        /// <param name="novoFeedback"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Post(ComentariosEventos comentarioEvento)
        {
            try
            {
                _comentariosEventosRepository.Cadastrar(comentarioEvento);
                return Created();
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }

        }

        /// <summary>
        /// Endpoint para listar Comentarios
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Get(Guid id)
        {
            try
            {
                List<ComentariosEventos> Listar = _comentariosEventosRepository.Listar(id);

                return Ok(Listar);
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }

        }

        /// <summary>
        /// Endpoint para deletar Comentarios
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            try
            {
                _comentariosEventosRepository.Deletar(id);
                return NoContent();
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Endpoint para buscar Comentarios por Id dos usuarios
        /// </summary>
        /// <param name="UsuarioId"></param>
        /// <param name="EventoId"></param>
        /// <returns></returns>
        [HttpGet("BuscarPorIdUsuario/{UsuarioId},{EventoId}")]
        public IActionResult GetById(Guid UsuarioId, Guid EventoId)
        {
            try
            {
                ComentariosEventos novoFeedback = _comentariosEventosRepository.BuscarPorIdUsuario(UsuarioId, EventoId);
                return Ok(novoFeedback);
            }
            catch (Exception error)
            {

                return BadRequest(error.Message);
            }
        }
    }
}
