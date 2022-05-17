using System;
using System.Collections.Generic;

#nullable disable

namespace managementAirport.Models.Data
{
    public partial class Origen
    {
        public Origen()
        {
            Ruta = new HashSet<Rutum>();
        }

        public int Id { get; set; }
        public int IdAeropuerto { get; set; }

        public virtual Aeropuerto IdAeropuertoNavigation { get; set; }
        public virtual ICollection<Rutum> Ruta { get; set; }
    }
}
