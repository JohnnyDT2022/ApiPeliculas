using Api.Peliculas.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Peliculas.IServices
{
    public interface IPeliculaService
    {
        RespuestaGenerica ConsultarGenerosPelicula();
        RespuestaGenerica ConsultarPeliculasDisponibles();
        RespuestaGenerica ConsultarPeliculasSugeridas(string UserName);
    }
}
