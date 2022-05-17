using System;
using System.Collections.Generic;

#nullable disable

namespace managementAirport.Models.Data
{
    public partial class Departamento
    {
        public Departamento()
        {
            Aeropuertos = new HashSet<Aeropuerto>();
        }

        public int Id { get; set; }
        public string Nombre { get; set; }
        public int Idpais { get; set; }

        public virtual Pai IdpaisNavigation { get; set; }
        public virtual ICollection<Aeropuerto> Aeropuertos { get; set; }
    }
}
