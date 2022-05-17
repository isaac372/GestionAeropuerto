using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace managementAirport.Models.Data
{
    [Serializable]
    [JsonObject]
    public class UsuariosResponse
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public int? Telefono { get; set; }
        public int IdRol { get; set; }
        //public Rol rol { get; set; }
        public List<ModuloNew> modulos { get; set; }

        public UsuariosResponse()
        {
            modulos = new List<ModuloNew> { };
        }
    }
}
