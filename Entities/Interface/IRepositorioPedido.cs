using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Interface
{
    public interface IRepositorioPedido : IRepository<Pedido> 
    {
        public IEnumerable<Pedido> GetPedidoPorCliente(Cliente cliente);
        public void DespacharPedido(int id);
    }
}
