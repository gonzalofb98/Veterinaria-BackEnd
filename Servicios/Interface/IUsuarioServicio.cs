using Dtos.Request;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servicios.Interface
{
    public interface IUsuarioServicio : IServicio<Usuario>
    {
        List<Usuario> ObtenerClientes();
        List<Usuario> ObtenerVendedores();
        Usuario BuscarPorEmail(string email);
        bool VerificarContraseña(Usuario usuarioExistente, string contrasenia);
        Mascota? BuscarMascota(string email, string nombre);
        bool RegistrarMascota(Mascota mascota, string email);
        public bool AgregarPedido(string email, Pedido pedido);
        Pedido BuscarPedidoPorCodigo(string email, string codigo);
        bool AgregarComboAPedido(Cliente usuarioExistente, Combo<Mascota> combo);
        bool DespacharPedido(Cliente usuarioExistente, string codigo);
    }
}
