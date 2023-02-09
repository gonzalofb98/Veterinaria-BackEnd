using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.TiposMascotas
{
    public class Gato : Mascota
    {
        override
        public double CalcularAlimento()
        {
            return 0.5 * Peso;
        }

        override
        public int CalcularComplemento()
        {
            var complemento = 0;
            if (getEdad() > 5) complemento++;
            if (Castrado) complemento++;
            return complemento;
        }
    }
}
