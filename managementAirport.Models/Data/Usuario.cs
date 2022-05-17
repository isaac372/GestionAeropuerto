using System;
using System.Collections.Generic;

#nullable disable

namespace managementAirport.Models.Data
{
    public partial class Usuario
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public int? Telefono { get; set; }
        public int IdRol { get; set; }

        public virtual Rol IdRolNavigation { get; set; }
    }
}
