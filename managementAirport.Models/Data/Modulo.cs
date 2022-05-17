using System;
using System.Collections.Generic;

#nullable disable

namespace managementAirport.Models.Data
{
    public partial class Modulo
    {
        public Modulo()
        {
            Operaciones = new HashSet<Operacione>();
        }

        public int Id { get; set; }
        public string Nombre { get; set; }
        public int? Idrol { get; set; }

        public virtual Rol IdrolNavigation { get; set; }
        public virtual ICollection<Operacione> Operaciones { get; set; }
    }
}
