using System;
using System.Collections.Generic;

#nullable disable

namespace managementAirport.Models.Data
{
    public partial class Escala
    {
        public int Id { get; set; }
        public int Cantidad { get; set; }
        public byte[] Tiempo { get; set; }
        public int? IdVuelo { get; set; }

        public virtual Vuelo IdVueloNavigation { get; set; }
    }
}
