using System;
using System.Collections.Generic;

#nullable disable

namespace managementAirport.Models.Data
{
    public partial class Pai
    {
        public Pai()
        {
            Departamentos = new HashSet<Departamento>();
        }

        public int Id { get; set; }
        public string Nombre { get; set; }

        public virtual ICollection<Departamento> Departamentos { get; set; }
    }
}
