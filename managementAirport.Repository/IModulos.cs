using managementAirport.Models.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace managementAirport.Repository
{
    public interface IModulos
    {
        Task<Modulo> GetById(int id);
        Task<List<ModuloNew>> GetByIdRol(int id);
        Task<int> Create(Modulo modulo);
        Task<int> Update(Modulo modulo);
        Task<int> Delete(int id);
    }
}
