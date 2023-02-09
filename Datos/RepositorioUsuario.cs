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

        static Vendedor vendedor1 = new Vendedor("Gonzalo", "Fernandez Braña", "gonzalofb98@gmail.com", "123123123");
        static Cliente cliente1 = new Cliente("Gonzalo", "Fernandez Braña", "gonzalofb98@gmail.com", "123123123");

        protected RepositorioUsuario() { IniciarPersistenciaUsuario(); }

        private void IniciarPersistenciaUsuario()
        {
            _usuarios.Add(vendedor1);
            cliente1.RegistrarMascota(new Perro("Luna", 2011, 14.4, true, cliente1));
            _usuarios.Add(cliente1);
        }

        public IEnumerable<Usuario> GetTodos()
        {
            return _usuarios.ToList();
        }

        public Usuario? GetPorId(int id)
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

        public void Agregar(Usuario usuario)
        {
            _usuarios.Add(usuario);
        }

        public IEnumerable<Usuario> GetClientes()
        {
            var clientes = _usuarios.Where(x => x is Cliente);
            return clientes.ToList();
        }

        public IEnumerable<Usuario> GetVendedores()
        {
            var vendedores = _usuarios.Where(x => x is Vendedor);
            return vendedores.ToList();
        }
    }
}
