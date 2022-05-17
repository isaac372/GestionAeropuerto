using System;
using System.Collections.Generic;

#nullable disable

namespace managementAirport.Models.Data
{
    public partial class Escala1
    {
        public int Id { get; set; }
        public int Cantidad { get; set; }
        public TimeSpan Tiempo { get; set; }
        public int IdVuelo { get; set; }

        public virtual Vuelo IdVueloNavigation { get; set; }
    }
}
