using managementAirport.Models.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace managementAirport.Repository
{
    public interface IOrigenDestino
    {
        Task<IEnumerable<Aeropuerto>> GetAll();
        Task<List<Aeropuerto>> Search(string name);
    }
}
