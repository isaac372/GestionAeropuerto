using System;
using System.Collections.Generic;

#nullable disable

namespace managementAirport.Models.Data
{
    public partial class Rutum
    {
        public Rutum()
        {
            Vuelos = new HashSet<Vuelo>();
        }

        public int Id { get; set; }
        public int IdOrigen { get; set; }
        public int IdDestino { get; set; }
        public DateTime FechaDespegue { get; set; }
        public DateTime FechaAterrizaje { get; set; }

        public virtual Destino IdDestinoNavigation { get; set; }
        public virtual Origen IdOrigenNavigation { get; set; }
        public virtual ICollection<Vuelo> Vuelos { get; set; }
    }
}
