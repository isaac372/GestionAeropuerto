using System;
using System.Collections.Generic;

#nullable disable

namespace managementAirport.Models.Data
{
    public partial class Vuelo
    {
        public Vuelo()
        {
            Escala1s = new HashSet<Escala1>();
            Escalas = new HashSet<Escala>();
        }

        public int Id { get; set; }
        public int IdAerolinea { get; set; }
        public int? Idruta { get; set; }

        public virtual Aerolinea IdAerolineaNavigation { get; set; }
        public virtual Rutum IdrutaNavigation { get; set; }
        public virtual ICollection<Escala1> Escala1s { get; set; }
        public virtual ICollection<Escala> Escalas { get; set; }
    }
}
