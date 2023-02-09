using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Vendedor : Usuario
    {
        public Vendedor(string nombre, string apellido, string email, string contrasenia) : base(nombre, apellido, email, contrasenia)
        {
        }

    }
}
