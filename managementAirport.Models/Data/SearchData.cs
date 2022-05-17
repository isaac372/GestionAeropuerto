using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace managementAirport.Models.Data
{
    public class SearchData
    {
        public int IDvuelo { get; set; }
        public string Origen { get; set; }
        public string Destino { get; set; }
        public DateTime fechaDespegue { get; set; }
        public DateTime fechaAterrizaje { get; set; }
        public string Aerolinea { get; set; }
        public int cantidadAsiento { get; set; }
        public List<Pasajero> pasajeros { get; set; }
        public string auxFlotilla { get; set; }
        public string auxAvion { get; set; }
        public string auxModelo { get; set; }

        public SearchData()
        {
            pasajeros = new List<Pasajero> { };
        }
    }
}
