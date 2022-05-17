using System;
using System.Collections.Generic;

#nullable disable

namespace managementAirport.Models.Data
{
    public partial class Aerolinea
    {
        public Aerolinea()
        {
            Agencia = new HashSet<Agencium>();
            Flotillas = new HashSet<Flotilla>();
            Tarifas = new HashSet<Tarifa>();
            Vuelos = new HashSet<Vuelo>();
        }

        public int Id { get; set; }
        public string Nombre { get; set; }

        public virtual ICollection<Agencium> Agencia { get; set; }
        public virtual ICollection<Flotilla> Flotillas { get; set; }
        public virtual ICollection<Tarifa> Tarifas { get; set; }
        public virtual ICollection<Vuelo> Vuelos { get; set; }
    }
}
