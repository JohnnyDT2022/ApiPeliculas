using Api.Peliculas.Entities;
using Api.Peliculas.IRepository;
using Api.Peliculas.ViewModel;
using Api.Peliculas.ViewModel.DTO;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;


namespace Api.Peliculas.Repository
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly IServiceProvider _serviceProvider;
        public UsuarioRepository(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public async Task<string> InsertarUsuario(string UserName, string PassWord)
        {
            string? mensajeDb = "";

            SqlParameter Usuario = new SqlParameter("@UserName", UserName);
            SqlParameter Pass = new SqlParameter("@PassWord",  PassWord);
            SqlParameter UsuarioCreacion = new SqlParameter("@UsuarioCreacion", UserName);
            SqlParameter mensaje = new SqlParameter("@Mensaje", DBNull.Value);

            using (var db = _serviceProvider.GetService<Data.PeliculasContext>())
            {
               var resultado =  db.Set<UsuarioInsertDataSet>().FromSqlRaw(@$"EXEC [dbo].[sp_UsuarioInsert] @UserName, @PassWord, @UsuarioCreacion,  @Mensaje OUTPUT ", Usuario, Pass, UsuarioCreacion, mensaje);

                mensajeDb = mensaje.Value?.ToString();
            }


            return mensajeDb;

        }

        public async Task<Tuple<List<UsuarioRegistradoDataSet>, string>> ObtenerUsuariosRegistrados()
        {
            string? mensajeDb = "";
            List<UsuarioRegistradoDatos> UsuarioRegistroDTOList = new List<UsuarioRegistradoDatos>();
            List<UsuarioRegistradoDataSet> listare = null!;
            Tuple<List<UsuarioRegistradoDataSet>, string> data = null!;


            using (var db = _serviceProvider.GetService<Data.PeliculasContext>())
            {
                listare = await db.ConsultarUsuarioRegistradoDataSets.FromSqlInterpolated(@$"sp_ReporteUsuarioSelect 
                       ").ToListAsync();
            }

            data = new Tuple<List<UsuarioRegistradoDataSet>, string>(listare, mensajeDb);
            return data;

        }

        
        public async Task<Tuple<DataSet, string>> ObtenerUsuariosRegistradosDataSet()
        {
            string? mensajeDb = "";
            List<UsuarioRegistradoDatos> UsuarioRegistroDTOList = new List<UsuarioRegistradoDatos>();
            DataSet listare = null!;
            Tuple<DataSet, string> data = null!;


            using (var db = _serviceProvider.GetService<Data.PeliculasContext>())
            {
                listare = (DataSet)db.ConsultarUsuariosRegistradosDataSets.FromSqlInterpolated(@$"sp_ReporteUsuarioSelect 
                       ");
            }

            data = new Tuple<DataSet, string>(listare, mensajeDb);
            return data;

        }
        
    }
}