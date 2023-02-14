using Dtos.Request;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servicios.Interface
{
    public interface IUsuarioServicio
    {
        Usuario Agregar(Usuario entity);
        bool AgregarComboAPedido(Cliente usuarioExistente, Combo<Mascota> combo);
        public bool AgregarPedido(string email, Pedido pedido);
        bool RegistrarMascota(Mascota mascota, string email);
        Usuario BuscarPorEmail(string email);
        Mascota? BuscarMascota(string email, string nombre);
        Pedido BuscarPedidoPorCodigo(string email, string codigo);
        List<Usuario> ObtenerVendedores();
        List<Usuario> ObtenerClientes();

        bool VerificarContraseña(Usuario usuarioExistente, string contrasenia);
        bool DespacharPedido(Cliente usuarioExistente, string codigo);
    }
}
