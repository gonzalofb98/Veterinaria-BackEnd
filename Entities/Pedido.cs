using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Pedido : EntidadBase
    {
        public List<Combo<Mascota>> Combos { get; set; }

        public Estado Estado { get; set; }

        public int Codigo { get; set; }

        public string Direccion { get; set; }

        public string FechaCreacion { get; set; }

        public Pedido()
        {
            Estado = Estado.PENDIENTE;
            var fecha = DateTime.Now;
            FechaCreacion = fecha.ToString();
        }

        public void AgregarCombo(Combo<Mascota> combo)
        {
            Combos.Add(combo);
        }
    }

    public enum Estado
    {
        PENDIENTE,
        DESPACHADO,
        CANCELADO
    }
}
