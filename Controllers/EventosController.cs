using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using webapi.event_.Domains;
using webapi.event_.Interfaces;

namespace webapi.event_.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
     public class EventoController : Controller
    {
        private readonly IEventosRepository _eventosRepository;

        public EventoController(IEventosRepository eventoRepository)
        {
            _eventosRepository = eventoRepository;
        }

        /// <summary>
        /// Endpoint  para Listar Todos os Eventos Presentes no Banco de Dados
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                List<Eventos> Listar = _eventosRepository.Listar();
                return Ok(Listar);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        /// <summary>
        /// Endpoint  para Cadastar um Evento no Banco de Dados
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Post(Eventos novoEvento)
        {
            try
            {
                _eventosRepository.Cadastrar(novoEvento);

                return Created();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        /// <summary>
        /// Endpoint  para Deletar um Evento no Banco de Dados
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete]
        public IActionResult Deletar(Guid id)
        {
            try
            {
                _eventosRepository.Deletar(id);

                return NoContent();
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Endpoint  para Atualizar um Evento no Banco de Dados
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public IActionResult Put(Guid id, Eventos Evento)
        {
            try
            {
                _eventosRepository.Atualizar(id, Evento);

                return NoContent();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        /// <summary>
        /// Endpoint  para ListarPorId Varios Eventos no Banco de Dados
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("ListarPorId{id}")]
        public IActionResult GetById(Guid id)
        {
            try
            {
                List<Eventos> ListarPorId = _eventosRepository.ListarPorId(id);
                return Ok(ListarPorId);

            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        /// <summary>
        /// Endpoint  próximos Eventos no Banco de Dados
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("ListarProximosEventos{id}")]
        public IActionResult ListarProximosEventos()
        {
            try
            {
                List<Eventos> ProximosEventos = _eventosRepository.ProximosEventos();
                return Ok(ProximosEventos);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}