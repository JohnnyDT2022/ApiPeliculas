using System;
using System.Collections.Generic;

namespace Api.Peliculas.Entities;

public partial class Pelicula
{
    public int IdPelicula { get; set; }

    public string Descripcion { get; set; } = null!;

    public string? Sinopsis { get; set; }

    public bool? Estado { get; set; }

    public string UsuarioCreacion { get; set; } = null!;

    public DateTime FechaCreacion { get; set; }

    public string UsuarioModificacion { get; set; } = null!;

    public DateTime FechaModificacion { get; set; }

    public virtual ICollection<PeliculaxGenero> PeliculaxGeneros { get; set; } = new List<PeliculaxGenero>();
}
