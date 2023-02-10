using Entities;
using Entities.Interface;
using Servicios.Interface;

namespace Servicios
{
    public class UsuarioServicio : IUsuarioServicio
    {
        private readonly IRepositorioUsuario _repositorioUsuarios;
        public UsuarioServicio(IRepositorioUsuario repositorioUsuarios)
        {
            _repositorioUsuarios = repositorioUsuarios;
        }

        public void Agregar(Usuario entity)
        {
            _repositorioUsuarios.Agregar(entity);
        }

        public Usuario BuscarPorId(int id)
        {
            return _repositorioUsuarios.BuscarPorId(id);
        }

        public List<Usuario> GetClientes()
        {
            return _repositorioUsuarios.GetClientes();
        }

        public List<Usuario> GetVendedores()
        {
            return _repositorioUsuarios.GetVendedores();
        }

        public List<Usuario> ObtenerTodos()
        {
            return _repositorioUsuarios.ObtenerTodos();
        }
    }
}