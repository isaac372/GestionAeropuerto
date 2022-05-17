using System;
using System.Collections.Generic;

#nullable disable

namespace managementAirport.Models.Data
{
    public partial class Operacione
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public int IdModulo { get; set; }

        public virtual Modulo IdModuloNavigation { get; set; }
    }
}
