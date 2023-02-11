using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Vendedor : Usuario
    {
        public Vendedor()
        {
            Id = Guid.NewGuid().ToString();
        }
        public Vendedor(string nombre, string apellido, string email) : base(nombre, apellido, email)
        {
        }

    }
}
