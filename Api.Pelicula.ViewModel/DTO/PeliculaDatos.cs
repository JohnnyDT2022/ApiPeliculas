using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Peliculas.ViewModel.DTO
{
    [JsonObject]
    [Serializable]
    public class PeliculaDatos
    {
        public int IdPelicula { get; set; }
        public string NombrePelicula { get; set; }
        public string Generos { get; set; }
    }
}
