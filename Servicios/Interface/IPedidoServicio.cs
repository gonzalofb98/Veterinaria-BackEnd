using Entities;

namespace Servicios.Interface
{
    public interface IPedidoServicio : IServicio<Pedido>
    {
        public List<Pedido> ObtenerPedidoPorCliente(Cliente cliente);
        public void DespacharPedido(string id);
    }
}