using System;
using System.Collections.Generic;

namespace Api.Peliculas.Entities;

public partial class GeneroPelicula
{
    public int IdGeneroPelicula { get; set; }

    public string Descripcion { get; set; } = null!;

    public bool? Estado { get; set; }

    public string UsuarioCreacion { get; set; } = null!;

    public DateTime FechaCreacion { get; set; }

    public string UsuarioModificacion { get; set; } = null!;

    public DateTime FechaModificacion { get; set; }

    public virtual ICollection<PeliculaxGenero> PeliculaxGeneros { get; set; } = new List<PeliculaxGenero>();

    public virtual ICollection<PreferenciaUsuario> PreferenciaUsuarios { get; set; } = new List<PreferenciaUsuario>();
}
