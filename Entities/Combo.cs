using Entities.TiposMascotas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Combo<T> where T : Mascota
    {
        public double CantidadAlimento { get; set; }
        public int ComplementoDietario { get; set; }

        public Combo(T mascota)
        {
            CantidadAlimento = mascota.CalcularAlimento();
            ComplementoDietario = mascota.CalcularComplemento();
        }
    }
}
