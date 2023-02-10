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
        public List<Usuario> GetClientes();
        public List<Usuario> GetVendedores();
    }
}
