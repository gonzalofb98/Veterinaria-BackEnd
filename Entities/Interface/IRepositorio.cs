using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Interface
{
    public interface IRepositorio
    {
        List<Usuario> ObtenerClientes();
        List<Usuario> ObtenerVendedores();
        Usuario BuscarPorEmail(string email);
        bool RegistrarMascota(Mascota mascota, string email);
        Mascota? BuscarMascota( string email, string nombre);
        public bool AgregarPedido(string email, Pedido pedido);
        Pedido BuscarPedidoPorCodigo(string email, string codigo);
        bool AgregarComboAPedido(Cliente usuarioExistente, Combo<Mascota> combo);
        bool DespacharPedido(Cliente usuarioExistente, string codigo);
        public List<Pedido> ObtenerTodosLosPedidos();
        public Pedido BuscarPedidoPorId(string id);
        public bool AgregarPedido(Pedido entity);
    }
}
