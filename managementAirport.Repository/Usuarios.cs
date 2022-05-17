using managementAirport.Models.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace managementAirport.Repository
{
    public class Usuarios : IUsuario
    {
        private GestionAeropuertoContext _context;


        public Usuarios(GestionAeropuertoContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Usuario>> GetAll() => await _context.Usuarios.ToListAsync();
        public async Task<Usuario> GetById(int id) => await _context.Usuarios.FindAsync(id);

        public async Task<UsuariosResponse> Login(string usuario, string password)
        {
            var NewInstance = new UsuariosResponse();

            var User = await _context.Usuarios.Where(e => e.Nombre == usuario && e.Password == password).FirstAsync();

            NewInstance.Id = User.Id;
            NewInstance.Nombre = User.Nombre;
            NewInstance.Apellido = User.Apellido;
            NewInstance.Password = User.Password;
            NewInstance.Email = User.Email;
            NewInstance.Telefono = User.Telefono;
            NewInstance.IdRol = User.IdRol;

            return NewInstance;
        }
        public async Task<int> Create(Usuario usuario)
        {
            _ = _context.AddAsync(usuario);
            return await _context.SaveChangesAsync();
        }

        public async Task<int> Delete(int id)
        {
            var exist = await _context.Usuarios.FindAsync(id);
            _context.Remove(exist);
            return await _context.SaveChangesAsync();
        }
        public async Task<int> Update(Usuario usuario)
        {
            _context.Attach(usuario);
            _context.Entry(usuario).State = EntityState.Modified;
            return await _context.SaveChangesAsync();
        }
    }
}
