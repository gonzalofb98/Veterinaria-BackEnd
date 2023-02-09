using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Rol
    {
        public string Nombre { get; set; }
        public List<Usuario> Usuarios { get; set; }

    }
}
