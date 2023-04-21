using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Peliculas.ViewModel
{
    public class RespuestaGenerica
    {
        public int StatusCode { get; set; }
        public dynamic Response { get; set; }
        [MaxLength(5, ErrorMessage = "Hasta 5 caracteres permitidos")]
        public string DescripcionId { get; set; }
        public string ErrorList { get; set; }

        public RespuestaGenerica()
        {
            ErrorList = "";
        }

    }
}
