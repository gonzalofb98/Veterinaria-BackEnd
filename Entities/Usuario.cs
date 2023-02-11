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
        public string Contrasenia { get; set; }

        public Usuario()
        {
            Id = Guid.NewGuid().ToString();
        }
        public Usuario(string nombre, string apellido, string email)
        {
            Nombre = nombre;
            Apellido = apellido;
            Id = Guid.NewGuid().ToString();
            Email = email;
        }
    }
}
