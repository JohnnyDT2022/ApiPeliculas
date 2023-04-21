using System;
using System.Collections.Generic;

namespace Api.Peliculas.Entities;

public partial class Usuario
{
    public int IdUsuario { get; set; }

    public string UserName { get; set; } = null!;

    public string PassWord { get; set; } = null!;

    public bool? Estado { get; set; }

    public string UsuarioCreacion { get; set; } = null!;

    public DateTime Fechacreacion { get; set; }

    public string UsuarioModificacion { get; set; } = null!;

    public DateTime FechaModificacion { get; set; }

    public virtual ICollection<PreferenciaUsuario> PreferenciaUsuarios { get; set; } = new List<PreferenciaUsuario>();
}
