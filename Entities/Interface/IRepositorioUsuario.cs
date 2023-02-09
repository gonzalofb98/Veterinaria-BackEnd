using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Interface
{
    public interface IRepositorioUsuario : IRepository<Usuario>
    {
        public IEnumerable<Usuario> GetClientes();
        public IEnumerable<Usuario> GetVendedores();
    }
}
