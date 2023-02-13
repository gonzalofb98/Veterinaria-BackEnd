using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Cliente : Usuario
    {
        public Cliente()
        {
            Id = Guid.NewGuid().ToString();
            Mascotas= new List<Mascota>();
            Pedidos = new List<Pedido>();
            PedidoPendiente = new Pedido();
        }
        public Cliente(string nombre, string apellido, string email) : base(nombre, apellido, email)
        {
        }

        public List<Mascota> Mascotas { get; set; }
        public List<Pedido> Pedidos { get; set; }
        public Pedido PedidoPendiente { get; set; }

        public void RegistrarMascota(Mascota mascota)
        {
            Mascotas.Add(mascota);
        }
        public void AgregarPedido(Pedido pedido)
        {
            Pedidos.Add(pedido);
        }

        public Pedido? BuscarPedido(string codigo)
        {
            return Pedidos.Where(x => x.Codigo == codigo).FirstOrDefault();
        }
    }
}
