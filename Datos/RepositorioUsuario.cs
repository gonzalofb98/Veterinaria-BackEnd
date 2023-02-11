using Entities;
using Entities.Interface;
using Entities.TiposMascotas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public class RepositorioUsuario : IRepositorioUsuario
    {
        private static RepositorioUsuario instance = null;
        public static RepositorioUsuario Instance
        {
            get
            {
                if (instance == null)
                    instance = new RepositorioUsuario();
                return instance;
            }
        }

        public List<Usuario> _usuarios = new List<Usuario>();

        static Vendedor vendedor1 = new Vendedor("Gonzalo", "Fernandez Braña", "gonzalofb98@gmail.com");
        static Cliente cliente1 = new Cliente("Gonzalo 2", "Fernandez Braña 2", "gonzalo@gmail.com");

        public RepositorioUsuario() { IniciarPersistenciaUsuario(); }

        private void IniciarPersistenciaUsuario()
        {
            _usuarios.Add(vendedor1);
            _usuarios.Add(cliente1);
        }

        public List<Usuario> ObtenerTodos()
        {
            return _usuarios;
        }

        public Usuario BuscarPorEmail(string email)
        {
            var usuario = _usuarios.Where(x => x.Email == email);
            return usuario.FirstOrDefault();
        }

        public Usuario? BuscarPorId(string id)
        {
            var lista = _usuarios.Where( x => x.Id == id);
            if (!lista.Any()){
                return null;
            }
            else
            {
                return lista.First();
            }
        }

        public bool Agregar(Usuario usuario)
        {
            _usuarios.Add(usuario);
            return true;
        }

        public List<Usuario> ObtenerClientes()
        {
            var clientes = _usuarios.Where(x => x is Cliente);
            return clientes.ToList();
        }

        public List<Usuario> ObtenerVendedores()
        {
            var vendedores = _usuarios.Where(x => x is Vendedor);
            return vendedores.ToList();
        }

        public bool RegistrarMascota(Mascota mascota, string email)
        {
            var usuario = _usuarios.Where(x => x.Email == email).FirstOrDefault() as Cliente;

            usuario.RegistrarMascota(mascota);
            return true;
        }

        public Mascota? BuscarMascota(string email, string nombre)
        {
            var usuario = _usuarios.Where(x => x.Email == email).FirstOrDefault() as Cliente;
            if (usuario != null)
            {
                var mascota = usuario.Mascotas.Where(m => m.Nombre == nombre);
                if (mascota.Any())
                    return mascota.FirstOrDefault();
                else
                    return null;
            }
            else
            {
                return null;
            }
        }
    }
}
