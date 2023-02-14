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
    public class Repositorio : IRepositorio
    {
        private static Repositorio instance = null;
        public static Repositorio Instance
        {
            get
            {
                if (instance == null)
                    instance = new Repositorio();
                return instance;
            }
        }

        public List<Usuario> _usuarios = new List<Usuario>();

        public Repositorio() { IniciarPersistenciaUsuario(); }

        private void IniciarPersistenciaUsuario()
        {
            Vendedor vendedor1 = new Vendedor("Admin", "admin", "admin@gmail.com");
            vendedor1.Contrasenia = "admin";

            Cliente cliente1 = new Cliente("Gonzalo 2", "Fernandez Braña 2", "gonzalo@gmail.com");
            cliente1.Contrasenia = "Gonzalo";
            cliente1.Mascotas = new List<Mascota>();

            _usuarios.Add(vendedor1);
            _usuarios.Add(cliente1);
        }

        public Usuario AgregarUsuario(Usuario entity)
        {
            _usuarios.Add(entity);
            return _usuarios.Where(x => x == entity).FirstOrDefault();
        }

        public List<Usuario> ObtenerTodosLosPedidos()
        {
            return _usuarios;
        }

        public Usuario BuscarPorEmail(string email)
        {
            var usuario = _usuarios.Where(x => x.Email == email);
            return usuario.FirstOrDefault();
        }

        public Usuario? BuscarPedidoPorId(string id)
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

        public bool AgregarPedido(string email, Pedido pedido)
        {
            var cliente = (Cliente) BuscarPorEmail(email);
            pedido.AgregarCombos(cliente.PedidoPendiente.Combos);
            cliente.PedidoPendiente.Combos.Clear();
            cliente.AgregarPedido(pedido);
            return true;
        }

        public Pedido? BuscarPedidoPorCodigo(string email, string codigo)
        {
            var usuario = _usuarios.Where(x => x.Email == email).FirstOrDefault() as Cliente;
            if (usuario != null)
            {
                var pedido = usuario.BuscarPedido(codigo);
                if(pedido != null)
                {
                    return pedido;
                }
                else
                {
                    return null;
                }
            }
            else
            {
                return null;
            }
        }

        public bool AgregarComboAPedido(Cliente usuarioExistente, Combo<Mascota> combo)
        {
            var usuario = _usuarios.Where(x => x == usuarioExistente).FirstOrDefault() as Cliente;

            usuario.PedidoPendiente.AgregarCombo(combo);
            return true;
        }

        public bool DespacharPedido(Cliente usuarioExistente, string codigo)
        {
            var usuario = _usuarios.Where(x => x == usuarioExistente).FirstOrDefault() as Cliente;

            var pedido = usuario.BuscarPedido(codigo);
            if (pedido != null)
            {
                pedido.Estado = Estado.DESPACHADO;
                return true;
            }
            else
                return false;
        }

        
    }
}
