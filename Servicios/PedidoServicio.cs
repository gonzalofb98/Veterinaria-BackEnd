using Entities;
using Entities.Interface;
using Servicios.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servicios
{
    public class PedidoServicio : IPedidoServicio
    {
        private readonly IRepositorioPedido _repositorioPedidos;
        public PedidoServicio(IRepositorioPedido repositorioPedidos)
        {
            _repositorioPedidos = repositorioPedidos;
        }

        public void Agregar(Pedido nuevoPedido)
        {
            _repositorioPedidos.Agregar(nuevoPedido);
        }
        
        public Pedido BuscarPorId(int id)
        {
            return _repositorioPedidos.BuscarPorId(id);
        }

        public List<Pedido> ObtenerTodos()
        {
            return _repositorioPedidos.ObtenerTodos();
        }

        public List<Pedido> ObtenerPedidoPorCliente(Cliente cliente)
        {
            return _repositorioPedidos.ObtenerPedidoPorCliente(cliente);
        }
        public void DespacharPedido(int id)
        {
            _repositorioPedidos.DespacharPedido(id);
        }
    }
}
