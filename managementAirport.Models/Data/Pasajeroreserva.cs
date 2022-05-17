using System;
using System.Collections.Generic;

#nullable disable

namespace managementAirport.Models.Data
{
    public partial class Pasajeroreserva
    {
        public int Id { get; set; }
        public int Idpasajero { get; set; }
        public int Idreserva { get; set; }

        public virtual Pasajero IdpasajeroNavigation { get; set; }
        public virtual Reserva IdreservaNavigation { get; set; }
    }
}
