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
    public class PeliculaRepository : IPeliculaRepository
    {
        private readonly IServiceProvider _serviceProvider;
        public PeliculaRepository(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

     
        public async Task<Tuple<List<ItemDesplegableDataSet>, string>> ObtenerGenerosPeliculas()
        {
            string? mensajeDb = "";
            List<ItemDesplegableDatos> ItemDesplegableDTOList = new List<ItemDesplegableDatos>();
            List<ItemDesplegableDataSet> listare = null!;
            Tuple<List<ItemDesplegableDataSet>, string> data = null!;


            using (var db = _serviceProvider.GetService<Data.PeliculasContext>())
            {
                listare = await db.ConsultarItemDesplegableDataSets.FromSqlInterpolated(@$"sp_GeneroPeliculaSelect 
                       ").ToListAsync();
            }

            data = new Tuple<List<ItemDesplegableDataSet>, string>(listare, mensajeDb);
            return data;

        }

        public async Task<Tuple<List<PeliculaDataSet>, string>> ObtenerPeliculas()
        {
            string? mensajeDb = "";
            List<PeliculaDatos> PeliculaDTOList = new List<PeliculaDatos>();
            List<PeliculaDataSet> listare = null!;
            Tuple<List<PeliculaDataSet>, string> data = null!;


            using (var db = _serviceProvider.GetService<Data.PeliculasContext>())
            {
                listare = await db.ConsultarPeliculaDataSets.FromSqlInterpolated(@$"sp_PeliculasRegistradasSelect 
                       ").ToListAsync();
            }

            data = new Tuple<List<PeliculaDataSet>, string>(listare, mensajeDb);
            return data;

        }

        public async Task<Tuple<List<PeliculaDataSet>, string>> ObtenerPeliculasSugeridas(String UserName)
        {
            string? mensajeDb = "";
            List<PeliculaDatos> PeliculaDTOList = new List<PeliculaDatos>();
            List<PeliculaDataSet> listare = null!;
            Tuple<List<PeliculaDataSet>, string> data = null!;


            using (var db = _serviceProvider.GetService<Data.PeliculasContext>())
            {
                listare = await db.ConsultarPeliculaDataSets.FromSqlInterpolated(@$"sp_SugerenciaPeliculasSelect 
                          @UserName= {UserName}").ToListAsync();
            }

            data = new Tuple<List<PeliculaDataSet>, string>(listare, mensajeDb);
            return data;

        }

    }
}