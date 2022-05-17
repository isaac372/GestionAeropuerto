using System;
using System.Collections.Generic;

#nullable disable

namespace managementAirport.Models.Data
{
    public partial class RolOperacion
    {
        public int Idrol { get; set; }
        public int Idoperacion { get; set; }

        public virtual Operacione IdoperacionNavigation { get; set; }
        public virtual Rol IdrolNavigation { get; set; }
    }
}
