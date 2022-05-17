using System;
using System.Collections.Generic;

#nullable disable

namespace managementAirport.Models.Data
{
    public partial class Asiento
    {
        public Asiento()
        {
            Pasajeros = new HashSet<Pasajero>();
        }

        public int Id { get; set; }
        public int IdVuelo { get; set; }
        public string Estado { get; set; }

        public virtual ICollection<Pasajero> Pasajeros { get; set; }
    }
}
