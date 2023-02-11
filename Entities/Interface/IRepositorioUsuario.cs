using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Interface
{
    public interface IRepositorioUsuario : IRepository<Usuario>
    {
        List<Usuario> ObtenerClientes();
        List<Usuario> ObtenerVendedores();
        Usuario BuscarPorEmail(string email);
        bool RegistrarMascota(Mascota mascota, string email);
        Mascota? BuscarMascota( string email, string nombre);
    }
}
