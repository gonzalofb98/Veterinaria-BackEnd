using AutoMapper;
using Dtos.Request;
using Entities;
using Entities.Interface;
using Servicios.Interface;

namespace Servicios
{
    public class UsuarioServicio : IUsuarioServicio
    {
        private readonly IRepositorioUsuario _repositorioUsuarios;
        private readonly IMapper _mapper;
        public UsuarioServicio(IRepositorioUsuario repositorioUsuarios, IMapper mapper)
        {
            _repositorioUsuarios = repositorioUsuarios;
            _mapper = mapper;
        }

        public bool Agregar(Usuario entity)
        {
            _repositorioUsuarios.Agregar(entity);
            return true;
        }

        public Usuario? BuscarPorEmail(string email)
        {
            var usuario = _repositorioUsuarios.BuscarPorEmail(email);
            return usuario;
        }

        public Usuario BuscarPorId(string id)
        {
            return _repositorioUsuarios.BuscarPorId(id);
        }

        public List<Usuario> ObtenerClientes()
        {
            return _repositorioUsuarios.ObtenerClientes();
        }

        public List<Usuario> ObtenerVendedores()
        {
            return _repositorioUsuarios.ObtenerVendedores();
        }

        public List<Usuario> ObtenerTodos()
        {
            return _repositorioUsuarios.ObtenerTodos();
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

        public bool RegistrarMascota(AgregarMascotaRequest mascotaDto, string email)
        {
            var mascota = _mapper.Map<Mascota>(mascotaDto);

            return _repositorioUsuarios.RegistrarMascota(mascota, email);
        }
    }
}