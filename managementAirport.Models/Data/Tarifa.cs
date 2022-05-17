using System;
using System.Collections.Generic;

#nullable disable

namespace managementAirport.Models.Data
{
    public partial class Tarifa
    {
        public int Id { get; set; }
        public decimal? Monto { get; set; }
        public int? IdAerolinea { get; set; }

        public virtual Aerolinea IdAerolineaNavigation { get; set; }
    }
}
