using Api.Peliculas.Entities;
using Api.Peliculas.IServices;
using Api.Peliculas.Logic;
using Api.Peliculas.ViewModel;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Api.Peliculas.Services
{
    public class UsuarioService : IUsuarioService
    {
        private readonly UsuarioLogic _usuarioLogic;
        private readonly ILogger<UsuarioService> _logger;
        public UsuarioService(UsuarioLogic usuarioLogic,
            ILogger<UsuarioService> logger)
        {
            _usuarioLogic = usuarioLogic;
            _logger = logger;
        }

        public RespuestaGenerica InsertarUsuario(string UserName, string PassWord)
        {
            RespuestaGenerica resultado = new RespuestaGenerica();
            string mensajeResultado = string.Empty;

            bool respuestaValidacion = true;

            if (!respuestaValidacion)
                return resultado;

            try
            {
                mensajeResultado = _usuarioLogic.InsertarUsuario(UserName, PassWord);

                resultado.StatusCode = 200;
                resultado.DescripcionId = "OK";
                resultado.Response = mensajeResultado;

                return resultado;

            }
            catch (Exception ex)
            {
                var parametros = $"Usuario Service Layer Try: UserName {UserName}, PassWord {PassWord}";
                var props = new Dictionary<string, object>(){
                            { "Metodo", "InsertarUsuario" },
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

        public RespuestaGenerica ConsultarUsuariosRegistrado()
        {
            Tuple<List<UsuarioRegistradoDataSet>, string> resulLogic = null!;
            RespuestaGenerica resultado = new RespuestaGenerica();

            bool respuestaValidacion = true;

            if (!respuestaValidacion)
                return resultado;

            try
            {
                resulLogic = _usuarioLogic.ConsultarUsuariosRegistrado();

                resultado.StatusCode = 200;
                resultado.DescripcionId = "OK";
                resultado.Response = resulLogic.Item1;

                return resultado;

            }
            catch (Exception ex)
            {
                var parametros = $"Usuario Service Layer Try:";
                var props = new Dictionary<string, object>(){
                            { "Metodo", "ConsultarUsuariosRegistrado" },
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

        public RespuestaGenerica ReporteUsuariosRegistrado()
        {
            Tuple<DataSet, string> resulLogic = null!;
            RespuestaGenerica resultado = new RespuestaGenerica();

            bool respuestaValidacion = true;

            if (!respuestaValidacion)
                return resultado;

            try
            {
                resulLogic = _usuarioLogic.ReporteUsuariosRegistrado();

                resultado.StatusCode = 200;
                resultado.DescripcionId = "OK";
                resultado.Response = resulLogic.Item1;

                return resultado;

            }
            catch (Exception ex)
            {
                var parametros = $"Usuario Service Layer Try:";
                var props = new Dictionary<string, object>(){
                            { "Metodo", "ConsultarUsuariosRegistrado" },
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
