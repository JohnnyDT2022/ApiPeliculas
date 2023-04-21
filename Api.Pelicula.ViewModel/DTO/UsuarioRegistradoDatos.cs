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
    public class UsuarioRegistradoDatos
    {
        public string UserName { get; set; }
        public string GenerosPreferidos { get; set; }
    }
}
