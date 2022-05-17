using managementAirport.Models.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace managementAirport.Repository
{
    public interface IUsuario
    {
        Task<IEnumerable<Usuario>> GetAll();
        Task<Usuario> GetById(int id);
        Task<int> Create(Usuario usuario);
        Task<int> Update(Usuario usuario);
        Task<int> Delete(int id);
        Task<UsuariosResponse> Login(string usuario, string password);
    }
}
