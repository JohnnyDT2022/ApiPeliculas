using Api.Peliculas.Entities;

namespace Api.Peliculas.IRepository
{
    public interface IPeliculaRepository
    {
        Task<Tuple<List<ItemDesplegableDataSet>, string>> ObtenerGenerosPeliculas();

        Task<Tuple<List<PeliculaDataSet>, string>> ObtenerPeliculas();
        Task<Tuple<List<PeliculaDataSet>, string>> ObtenerPeliculasSugeridas(String UserName);
    }
}