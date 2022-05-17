using System;
using System.Collections.Generic;

#nullable disable

namespace managementAirport.Models.Data
{
    public partial class Flotilla
    {
        public Flotilla()
        {
            Avions = new HashSet<Avion>();
        }

        public int Id { get; set; }
        public string Nombre { get; set; }
        public int? IdAerolinea { get; set; }
        public int? Cantidad { get; set; }

        public virtual Aerolinea IdAerolineaNavigation { get; set; }
        public virtual ICollection<Avion> Avions { get; set; }
    }
}
