using Api.Peliculas.IServices;
using Api.Peliculas.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Formats.Asn1;
using System.IO;
using CsvHelper;
using System.Globalization;

namespace Api.Peliculas.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {

        private readonly IUsuarioService _usuarioService;
        public UsuarioController(IUsuarioService usuarioService)
        {
            _usuarioService = usuarioService;
        }

        [HttpPost]
        [Route("CrearUsuario")]
        public ActionResult<RespuestaGenerica> CrearUsuario(string UserName, string PassWord)
        {
            return Ok(_usuarioService.InsertarUsuario(UserName, PassWord));
        }

        [HttpGet]
        [Route("ConsultarUsuariosRegistrados")]
        public ActionResult<RespuestaGenerica> ConsultarUsuariosRegistrados()
        {
            return Ok(_usuarioService.ConsultarUsuariosRegistrado());
        }
        
        [HttpGet]
        [Route("ReporteUsuariosRegistrados")]
        public byte[] ReporteUsuariosRegistrados()
        {
            var respuestaDataSet = _usuarioService.ReporteUsuariosRegistrado();
            MemoryStream memoryStream = new MemoryStream();
            StreamWriter streamWriter = new StreamWriter(memoryStream, System.Text.Encoding.GetEncoding(1252));
            using (CsvWriter csvWriter = new CsvWriter(streamWriter, CultureInfo.InvariantCulture))
            {
                if (respuestaDataSet.Response.Tables.Count > 0)
                {
                    //var cabecera = new[] { "Nombre Persona", "Fecha", "Turno", "Hora Inicio Turno", "Hora Fin Turno" };
                    foreach (var col in respuestaDataSet.Response.Tables[0].Columns)
                    {
                        csvWriter.WriteField(col.ToString());
                    }
                    csvWriter.NextRecord();
                    foreach (DataRow ceseFuncionAux in respuestaDataSet.Response.Tables[0].Rows)
                    {
                        foreach (var col in respuestaDataSet.Response.Tables[0].Columns)
                        {
                            csvWriter.WriteField(ceseFuncionAux[col.ToString()]);
                        }
                        csvWriter.NextRecord();
                    }
                }
                else
                {
                    csvWriter.WriteField("NO SE ENCONTRÓ LA INFORMACIÓN REQUERIDA");
                }
                csvWriter.Flush();
            }
            return memoryStream.ToArray();
        }
        
    }
}
