using System;
using System.Collections.Generic;

#nullable disable

namespace managementAirport.Models.Data
{
    public partial class Pasajero
    {
        public Pasajero()
        {
            Equipajes = new HashSet<Equipaje>();
            Pasajeroreservas = new HashSet<Pasajeroreserva>();
        }

        public int Id { get; set; }
        public string Nombre { get; set; }
        public int Pasaporte { get; set; }
        public int IdAsiento { get; set; }

        public virtual Asiento IdAsientoNavigation { get; set; }
        public virtual ICollection<Equipaje> Equipajes { get; set; }
        public virtual ICollection<Pasajeroreserva> Pasajeroreservas { get; set; }
    }
}
