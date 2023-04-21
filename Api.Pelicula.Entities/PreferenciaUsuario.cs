using System;
using System.Collections.Generic;

namespace Api.Peliculas.Entities;

public partial class PreferenciaUsuario
{
    public int IdPreferenciaUsuario { get; set; }

    public int IdUsuario { get; set; }

    public int IdGeneroPelicula { get; set; }

    public bool? Estado { get; set; }

    public string UsuarioCreacion { get; set; } = null!;

    public DateTime FechaCreacion { get; set; }

    public string UsuarioModificacion { get; set; } = null!;

    public DateTime FechaModificacion { get; set; }

    public virtual GeneroPelicula IdGeneroPeliculaNavigation { get; set; } = null!;

    public virtual Usuario IdUsuarioNavigation { get; set; } = null!;
}
