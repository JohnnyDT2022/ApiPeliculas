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
    public class ItemDesplegableDatos
    {
        public int Value { get; set; }
        public string Text { get; set; }
    }
}
