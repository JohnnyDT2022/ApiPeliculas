using Api.Peliculas.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Peliculas.IServices
{
    public interface IUsuarioService
    {
        RespuestaGenerica InsertarUsuario(string UserName, string PassWord);

        RespuestaGenerica ConsultarUsuariosRegistrado();
        RespuestaGenerica ReporteUsuariosRegistrado();
    }
}