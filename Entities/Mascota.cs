using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Mascota : EntidadBase
    {
        public String Nombre { get; set; }
        public int AñoNacimiento { get; set; }
        public float Peso { get; set; }

        public int getEdad()
        {
            return DateTime.Now.Year - AñoNacimiento;
        }
    }
}
