using System;
using System.Collections.Generic;

#nullable disable

namespace managementAirport.Models.Data
{
    public partial class Agencium
    {
        public Agencium()
        {
            Reservas = new HashSet<Reserva>();
        }

        public int Id { get; set; }
        public string Nombre { get; set; }
        public int Idaerolineas { get; set; }

        public virtual Aerolinea IdaerolineasNavigation { get; set; }
        public virtual ICollection<Reserva> Reservas { get; set; }
    }
}
