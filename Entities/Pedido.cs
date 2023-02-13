using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Pedido : EntidadBase
    {
        public List<Combo<Mascota>> Combos { get; set; }

        public Estado Estado { get; set; }

        public string Codigo { get; set; }

        [Required]
        public string Direccion { get; set; }

        public string FechaCreacion { get; set; }

        public Pedido()
        {
            Id = Guid.NewGuid().ToString();
            Estado = Estado.PENDIENTE;
            var fecha = DateTime.Now;
            FechaCreacion = fecha.ToString();
            Combos = new List<Combo<Mascota>>();
            Codigo = Guid.NewGuid().ToString();
        }

        public void AgregarCombo(Combo<Mascota> combo)
        {
            Combos.Add(combo);
        }
        public void AgregarCombos(List<Combo<Mascota>> combo)
        {
            Combos.AddRange(combo);
        }
    }

    public enum Estado
    {
        PENDIENTE,
        DESPACHADO,
        CANCELADO
    }
}
