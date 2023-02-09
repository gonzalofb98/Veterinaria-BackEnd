using Entities;
using Entities.Interface;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public class RepositorioPedido : IRepositorioPedido
    {
        private static RepositorioPedido instance = null;
        public static RepositorioPedido Instance
        {
            get
            {
                if (instance == null)
                    instance = new RepositorioPedido();
                return instance;
            }
        }

        public List<Pedido> _pedidos = new List<Pedido>();

        public IEnumerable<Pedido> GetTodos()
        {
            return _pedidos.ToList();
        }

        public IEnumerable<Pedido> GetPedidoPorCliente(Cliente cliente) 
        {
            var listaPedidos = _pedidos.Where(x => x.Cliente == cliente);
            if (!listaPedidos.Any())
            {
                return null;
            }
            else
            {
                return listaPedidos.ToList();
            }
        }

        public void DespacharPedido(int id) 
        {
            var pedido = _pedidos.FirstOrDefault(x => x.Id == id);
            if (pedido != null)
            {
                int index = _pedidos.IndexOf(pedido);
                pedido.Estado = Estado.DESPACHADO;
                _pedidos[index] = pedido;
            }
        }

        public Pedido GetPorId(int id)
        {
            var lista = _pedidos.Where(x => x.Id == id);
            if (!lista.Any())
            {
                return null;
            }
            else
            {
                return lista.First();
            }
        }

        public void Agregar(Pedido pedido)
        {
            _pedidos.Add(pedido);
        }
    }
}
