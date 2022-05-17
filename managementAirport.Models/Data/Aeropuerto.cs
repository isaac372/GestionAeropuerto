using System;
using System.Collections.Generic;

#nullable disable

namespace managementAirport.Models.Data
{
    public partial class Aeropuerto
    {
        public Aeropuerto()
        {
            Destinos = new HashSet<Destino>();
            Origens = new HashSet<Origen>();
        }

        public int Id { get; set; }
        public string Nombre { get; set; }
        public int? IdDepartamento { get; set; }

        public virtual Departamento IdDepartamentoNavigation { get; set; }
        public virtual ICollection<Destino> Destinos { get; set; }
        public virtual ICollection<Origen> Origens { get; set; }
    }
}
