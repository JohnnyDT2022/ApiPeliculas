using Api.Peliculas.Entities;
using Api.Peliculas.IRepository;
using Api.Peliculas.ViewModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Peliculas.Logic
{
    public class UsuarioLogic
    {
        private readonly IUsuarioRepository _usuariorepository;

        public UsuarioLogic(IUsuarioRepository usuarioRepository)
        {
            _usuariorepository = usuarioRepository;
        }

        public string InsertarUsuario(string UserName, string PassWord)
        {
            var resultadoBD = Task.Run(async () => await _usuariorepository.InsertarUsuario(UserName, PassWord)).Result;
            return resultadoBD;
        }


        public Tuple<List<UsuarioRegistradoDataSet>, string> ConsultarUsuariosRegistrado()
        {
            var resultadoBD = Task.Run(async () => await _usuariorepository.ObtenerUsuariosRegistrados()).Result;
            return resultadoBD;
        }

        public Tuple<DataSet, string> ReporteUsuariosRegistrado()
        {
            var resultadoBD = Task.Run(async () => await _usuariorepository.ObtenerUsuariosRegistradosDataSet()).Result;
            return resultadoBD;
        }
    }
}
