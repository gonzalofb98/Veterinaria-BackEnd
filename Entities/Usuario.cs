using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Usuario : EntidadBase
    { 
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Email { get; set; }
        public Rol Rol { get; set; }
        public List<Mascota> Mascotas { get; set; }
    }
}
