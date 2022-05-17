using System;
using System.Collections.Generic;

#nullable disable

namespace managementAirport.Models.Data
{
    public partial class Rol
    {
        public Rol()
        {
            Modulos = new HashSet<Modulo>();
            Usuarios = new HashSet<Usuario>();
        }

        public int Id { get; set; }
        public string Nombre { get; set; }

        public virtual ICollection<Modulo> Modulos { get; set; }
        public virtual ICollection<Usuario> Usuarios { get; set; }
    }
}
