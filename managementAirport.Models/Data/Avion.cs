using System;
using System.Collections.Generic;

#nullable disable

namespace managementAirport.Models.Data
{
    public partial class Avion
    {
        public Avion()
        {
            Tripulacions = new HashSet<Tripulacion>();
        }

        public int IdAvion { get; set; }
        public int IdFlotilla { get; set; }
        public string Modelo { get; set; }
        public string Placa { get; set; }

        public virtual Flotilla IdFlotillaNavigation { get; set; }
        public virtual ICollection<Tripulacion> Tripulacions { get; set; }
    }
}
