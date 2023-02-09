using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Cliente : Usuario
    {
        public List<Mascota> Mascotas { get; set; }
        public List<Pedido> Pedidos { get; set; }

        public void RegistrarMascota(Mascota mascota)
        {
            Mascotas.Add(mascota);
        }
        public void AgregarPedido(Pedido pedido)
        {
            Pedidos.Add(pedido);
        }
    }
}
