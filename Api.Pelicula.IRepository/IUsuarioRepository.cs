using Api.Peliculas.Entities;
using System.Data;

namespace Api.Peliculas.IRepository
{
    public interface IUsuarioRepository
    {
        Task<string> InsertarUsuario(string UserName, string PassWord);
        Task<Tuple<List<UsuarioRegistradoDataSet>, string>> ObtenerUsuariosRegistrados();
        Task<Tuple<DataSet, string>> ObtenerUsuariosRegistradosDataSet();
    }
}