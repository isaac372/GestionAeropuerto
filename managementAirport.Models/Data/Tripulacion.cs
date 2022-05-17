using System;
using System.Collections.Generic;

#nullable disable

namespace managementAirport.Models.Data
{
    public partial class Tripulacion
    {
        public int IdTripulacion { get; set; }
        public int IdAvion { get; set; }
        public string Puesto { get; set; }
        public string PrimerNombre { get; set; }
        public string SegundoNombre { get; set; }
        public string PrimerApellido { get; set; }
        public string SegundoApellido { get; set; }
        public bool? Estado { get; set; }

        public virtual Avion IdAvionNavigation { get; set; }
    }
}
