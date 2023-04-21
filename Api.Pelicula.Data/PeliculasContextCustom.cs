using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Api.Peliculas.Entities;
using System.Data;

namespace Api.Peliculas.Data
{
    public partial class PeliculasContext
    {
        public virtual DbSet<UsuarioRegistradoDataSet> ConsultarUsuarioRegistradoDataSets { get; set; }
        public virtual DbSet<ItemDesplegableDataSet> ConsultarItemDesplegableDataSets { get; set; }
        public virtual DbSet<PeliculaDataSet> ConsultarPeliculaDataSets { get; set; }
        public virtual DbSet<DataSet> ConsultarUsuariosRegistradosDataSets { get; set; }


    }
}
