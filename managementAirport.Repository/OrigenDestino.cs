using managementAirport.Models.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace managementAirport.Repository
{
    public class OrigenDestino : IOrigenDestino
    {
        private GestionAeropuertoContext _context;


        public OrigenDestino(GestionAeropuertoContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Aeropuerto>> GetAll() => await _context.Aeropuertos.ToListAsync();
        public async Task<List<Aeropuerto>> Search(string aeropuerto)

        {
            var results = await GetAll();

            var result = from ed in results
                         where ed.Nombre.Contains(aeropuerto.ToUpper())
                         select new Aeropuerto
                         {
                             Id = ed.Id,
                             Nombre = ed.Nombre,
                             IdDepartamento = ed.IdDepartamento,
                         };
            return result.ToList();
        }


    }
}
