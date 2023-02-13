using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Usuario : EntidadBase
    {
        [Required]
        public string Nombre { get; set; }
        [Required]
        public string Apellido { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
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
