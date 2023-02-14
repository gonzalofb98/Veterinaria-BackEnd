using AutoMapper;
using Dtos.Request;
using Entities;
using Entities.Interface;
using Servicios.Interface;

namespace Servicios
{
    public class UsuarioServicio : IUsuarioServicio
    {
        private readonly IRepositorio _repositorioUsuarios;
        public UsuarioServicio(IRepositorio repositorioUsuarios)
        {
            _repositorioUsuarios = repositorioUsuarios;
        }

        public Usuario Agregar(Usuario entity)
        {
            return _repositorioUsuarios.AgregarUsuario(entity); ;
        }

        public Usuario? BuscarPorEmail(string email)
        {
            var usuario = _repositorioUsuarios.BuscarPorEmail(email);
            return usuario;
        }

        public List<Usuario> ObtenerClientes()
        {
            return _repositorioUsuarios.ObtenerClientes();
        }

        public List<Usuario> ObtenerVendedores()
        {
            return _repositorioUsuarios.ObtenerVendedores();
        }

        public bool VerificarContraseña(Usuario usuarioExistente, string contrasenia)
        {
            var usuario = _repositorioUsuarios.BuscarPorEmail(usuarioExistente.Email);
            if(usuario.Contrasenia == contrasenia)
                return true;
            else
                return false;
        }

        public Mascota BuscarMascota(string email, string nombre)
        {
            return _repositorioUsuarios.BuscarMascota(email, nombre);
        }

        public bool RegistrarMascota(Mascota mascota, string email)
        {
            return _repositorioUsuarios.RegistrarMascota(mascota, email);
        }

        public bool AgregarPedido(string email, Pedido pedido)
        {
            return _repositorioUsuarios.AgregarPedido(email, pedido);
        }

        public Pedido BuscarPedidoPorCodigo(string email, string codigo)
        {
            return _repositorioUsuarios.BuscarPedidoPorCodigo(email, codigo);
        }

        public bool AgregarComboAPedido(Cliente usuarioExistente, Combo<Mascota> combo)
        {
            return _repositorioUsuarios.AgregarComboAPedido(usuarioExistente, combo);
        }

        public bool DespacharPedido(Cliente usuarioExistente, string codigo)
        {
            return _repositorioUsuarios.DespacharPedido(usuarioExistente, codigo);
        }
    }
}