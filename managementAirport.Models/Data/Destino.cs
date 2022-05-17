using System;
using System.Collections.Generic;

#nullable disable

namespace managementAirport.Models.Data
{
    public partial class Destino
    {
        public Destino()
        {
            Ruta = new HashSet<Rutum>();
        }

        public int Id { get; set; }
        public int Idaeropuerto { get; set; }

        public virtual Aeropuerto IdaeropuertoNavigation { get; set; }
        public virtual ICollection<Rutum> Ruta { get; set; }
    }
}
