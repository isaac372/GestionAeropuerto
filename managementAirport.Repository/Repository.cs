using managementAirport.Models.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace managementAirport.Repository
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        private GestionAeropuertoContext _context;
        private DbSet<TEntity> _dbset;

        public Repository(GestionAeropuertoContext context)
        {
            _context = context;
            _dbset = context.Set<TEntity>();
        }

        public async Task<IEnumerable<TEntity>> GetAll() => await _dbset.ToListAsync();
        public async Task<TEntity> GetById(int id) => await _dbset.FindAsync(id);

        public async Task<int> Create(TEntity data)
        {
            _ = _dbset.AddAsync(data);
            return await _context.SaveChangesAsync();
        }
        public async Task<int> Delete(int id)
        {
            var exist = await _dbset.FindAsync(id);
            _dbset.Remove(exist);
            return await _context.SaveChangesAsync();
        }
        public async Task<int> Update(TEntity data)
        {
            _dbset.Attach(data);
            _context.Entry(data).State = EntityState.Modified;
            return await _context.SaveChangesAsync();
        }
    }
}
