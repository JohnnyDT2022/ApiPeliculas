using Api.Peliculas.IServices;
using Api.Peliculas.Services;
using Api.Peliculas.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace API.Peliculas.Controllers
{
    public class PeliculaController : Controller
    {
        private readonly IPeliculaService _peliculaService;
        public PeliculaController(IPeliculaService peliculaService)
        {
            _peliculaService = peliculaService;
        }

        /// <summary>
        /// Consulta una colección de activaciones para colocarlos en una tabla y aplicar paginación de datos.
        /// </summary>
        /// <param name="">Los parámetros para buscar las activaciones.</param>
        /// <returns>Retorna una colección de activaciones en formato JSON.</returns>

        [HttpGet]
        [Route("ObtenerGenerosPeliculas")]
        public ActionResult<RespuestaGenerica> ObtenerGenerosPeliculas()
        {
            return Ok(_peliculaService.ConsultarGenerosPelicula());
        }

        [HttpGet]
        [Route("ObtenerPeliculasDisponibles")]
        public ActionResult<RespuestaGenerica> ObtenerPeliculasDisponibles()
        {
            return Ok(_peliculaService.ConsultarPeliculasDisponibles());
        }

        [HttpGet]
        [Route("ObtenerPeliculasSugeridas")]
        public ActionResult<RespuestaGenerica> ObtenerPeliculasSugeridas(string UserName)
        {
            return Ok(_peliculaService.ConsultarPeliculasSugeridas(UserName));
        }
    }
}
