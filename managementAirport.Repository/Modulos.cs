using managementAirport.Models.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace managementAirport.Repository
{
    public class Modulos : IModulos
    {
        private GestionAeropuertoContext _context;

        public Modulos(GestionAeropuertoContext context)
        {
            _context = context;
        }
        public async Task<Modulo> GetById(int id) => await _context.Modulos.FindAsync(id);

        public async Task<List<ModuloNew>> GetByIdRol(int id)
        {
            var Modulos = new List<ModuloNew>();

            var data = await _context.Modulos.Where(e => e.Idrol == id).ToListAsync();

            foreach (var item in data)
            {
                var Modulo = new ModuloNew();
                Modulo.Id = item.Id;
                Modulo.Nombre = item.Nombre;
                Modulo.Idrol = item.Idrol;

                Modulos.Add(Modulo);
            }
            return Modulos;
        }


        public async Task<int> Create(Modulo modulo)
        {
            _ = _context.AddAsync(modulo);
            return await _context.SaveChangesAsync();
        }

        public async Task<int> Update(Modulo modulo)
        {
            _context.Attach(modulo);
            _context.Entry(modulo).State = EntityState.Modified;
            return await _context.SaveChangesAsync();
        }
        public async Task<int> Delete(int id)
        {
            var exist = await _context.Modulos.FindAsync(id);
            _context.Remove(exist);
            return await _context.SaveChangesAsync();
        }


    }
}
