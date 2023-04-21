using Api.Peliculas.Entities;
using Api.Peliculas.IRepository;
using Api.Peliculas.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Peliculas.Logic
{
    public class PeliculaLogic
    {
        private readonly IPeliculaRepository _pelicularepository;

        public PeliculaLogic(IPeliculaRepository peliculaRepository)
        {
            _pelicularepository = peliculaRepository;
        }

        public Tuple<List<ItemDesplegableDataSet>, string> ConsultarGenerosPeliculas()
        {
            var resultadoBD = Task.Run(async () => await _pelicularepository.ObtenerGenerosPeliculas()).Result;
            return resultadoBD;
        }

        public Tuple<List<PeliculaDataSet>, string> ConsultarPeliculasDisponibles()
        {
            var resultadoBD = Task.Run(async () => await _pelicularepository.ObtenerPeliculas()).Result;
            return resultadoBD;
        }

        public Tuple<List<PeliculaDataSet>, string> ConsultarPeliculasSugeridas(string UserName)
        {
            var resultadoBD = Task.Run(async () => await _pelicularepository.ObtenerPeliculasSugeridas(UserName)).Result;
            return resultadoBD;
        }


    }
}
