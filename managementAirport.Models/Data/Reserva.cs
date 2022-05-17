using System;
using System.Collections.Generic;

#nullable disable

namespace managementAirport.Models.Data
{
    public partial class Reserva
    {
        public Reserva()
        {
            Pasajeroreservas = new HashSet<Pasajeroreserva>();
        }

        public int Id { get; set; }
        public int IdPasajero { get; set; }
        public DateTime FechaReserva { get; set; }
        public int IdAsiento { get; set; }
        public int IdVuelo { get; set; }
        public int IdAgencia { get; set; }

        public virtual Agencium IdAgenciaNavigation { get; set; }
        public virtual ICollection<Pasajeroreserva> Pasajeroreservas { get; set; }
    }
}
