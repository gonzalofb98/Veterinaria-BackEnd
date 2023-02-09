using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public abstract class Mascota : EntidadBase
    {
        public string Nombre { get; set; }
        public int AnioNacimiento { get; set; }
        public double Peso { get; set; }
        public bool Castrado { get; set; }
        public Usuario Duenio { get; set; }

        public int getEdad()
        {
            return DateTime.Now.Year - AnioNacimiento;
        }

        public virtual double CalcularAlimento() { return 0; }
        public virtual int CalcularComplemento() { return 0; }
    }
}
