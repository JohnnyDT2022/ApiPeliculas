using Api.Peliculas.Entities;
using Api.Peliculas.IServices;
using Api.Peliculas.Logic;
using Api.Peliculas.ViewModel;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Peliculas.Services
{
    public class PeliculaService : IPeliculaService
    {
        private readonly PeliculaLogic _peliculaLogic;
        private readonly ILogger<PeliculaService> _logger;
        public PeliculaService(PeliculaLogic peliculaLogic,
            ILogger<PeliculaService> logger)
        {
            _peliculaLogic = peliculaLogic;
            _logger = logger;
        }

        public RespuestaGenerica ConsultarGenerosPelicula()
        {
            Tuple<List<ItemDesplegableDataSet>, string> resulLogic = null!;
            RespuestaGenerica resultado = new RespuestaGenerica();

            bool respuestaValidacion = true;

            if (!respuestaValidacion)
                return resultado;

            try
            {
                resulLogic = _peliculaLogic.ConsultarGenerosPeliculas();

                resultado.StatusCode = 200;
                resultado.DescripcionId = "OK";
                resultado.Response = resulLogic.Item1;

                return resultado;

            }
            catch (Exception ex)
            {
                var parametros = $"Pelicula Service Layer Try:";
                var props = new Dictionary<string, object>(){
                            { "Metodo", "ConsultarGenerosPelicula" },
                            { "Sitio", "PELICULAS-API" },
                            { "Parametros", parametros }
                    };

                using (_logger.BeginScope(props))
                {
                    _logger.LogError($"Error {ex.Message}");
                }
                resultado.StatusCode = 400;
                resultado.DescripcionId = "ERROR";
                resultado.Response = null!;
                resultado.ErrorList = "Error: " + ex.Message;
                //resultado.ErrorList = "APP Se produjo un error en la aplicación. Vuelva a intentar. ";

                return resultado;

            }

        }

        public RespuestaGenerica ConsultarPeliculasDisponibles()
        {
            Tuple<List<PeliculaDataSet>, string> resulLogic = null!;
            RespuestaGenerica resultado = new RespuestaGenerica();

            bool respuestaValidacion = true;

            if (!respuestaValidacion)
                return resultado;

            try
            {
                resulLogic = _peliculaLogic.ConsultarPeliculasDisponibles();

                resultado.StatusCode = 200;
                resultado.DescripcionId = "OK";
                resultado.Response = resulLogic.Item1;

                return resultado;

            }
            catch (Exception ex)
            {
                var parametros = $"Pelicula Service Layer Try:";
                var props = new Dictionary<string, object>(){
                            { "Metodo", "ConsultarPeliculasDisponibles" },
                            { "Sitio", "PELICULAS-API" },
                            { "Parametros", parametros }
                    };

                using (_logger.BeginScope(props))
                {
                    _logger.LogError($"Error {ex.Message}");
                }
                resultado.StatusCode = 400;
                resultado.DescripcionId = "ERROR";
                resultado.Response = null!;
                resultado.ErrorList = "Error: " + ex.Message;
                //resultado.ErrorList = "APP Se produjo un error en la aplicación. Vuelva a intentar. ";

                return resultado;

            }

        }

        public RespuestaGenerica ConsultarPeliculasSugeridas(string UserName)
        {
            Tuple<List<PeliculaDataSet>, string> resulLogic = null!;
            RespuestaGenerica resultado = new RespuestaGenerica();

            bool respuestaValidacion = true;

            if (!respuestaValidacion)
                return resultado;

            try
            {
                resulLogic = _peliculaLogic.ConsultarPeliculasSugeridas(UserName);

                resultado.StatusCode = 200;
                resultado.DescripcionId = "OK";
                resultado.Response = resulLogic.Item1;

                return resultado;

            }
            catch (Exception ex)
            {
                var parametros = $"Pelicula Service Layer Try: UserName {UserName}";
                var props = new Dictionary<string, object>(){
                            { "Metodo", "ConsultarPeliculasSugeridas" },
                            { "Sitio", "PELICULAS-API" },
                            { "Parametros", parametros }
                    };

                using (_logger.BeginScope(props))
                {
                    _logger.LogError($"Error {ex.Message}");
                }
                resultado.StatusCode = 400;
                resultado.DescripcionId = "ERROR";
                resultado.Response = null!;
                resultado.ErrorList = "Error: " + ex.Message;
                //resultado.ErrorList = "APP Se produjo un error en la aplicación. Vuelva a intentar. ";

                return resultado;

            }

        }
    }
}
