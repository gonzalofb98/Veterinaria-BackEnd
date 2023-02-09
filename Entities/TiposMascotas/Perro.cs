using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.TiposMascotas
{
    public class Perro : Mascota
    {
        public Perro(string nombre, int anioNacimiento, double peso, bool castrado, Usuario duenio) : base(nombre, anioNacimiento, peso, castrado, duenio)
        {
        }

        override
        public double CalcularAlimento()
        {
            return 0.8 * Peso;
        }

        override
        public int CalcularComplemento()
        {
            var complemento = getEdad() / 3;
            if (Castrado && getEdad() > 5) complemento++;
            return complemento;
        }
    }
}
