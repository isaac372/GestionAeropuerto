using System;
using System.Collections.Generic;

#nullable disable

namespace managementAirport.Models.Data
{
    public partial class Equipaje
    {
        public int Id { get; set; }
        public double Peso { get; set; }
        public int Cantidad { get; set; }
        public int IdPasajero { get; set; }

        public virtual Pasajero IdPasajeroNavigation { get; set; }
    }
}
