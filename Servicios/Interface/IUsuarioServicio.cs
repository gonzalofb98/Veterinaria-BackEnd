using Dtos.Request;
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
        List<Usuario> ObtenerClientes();
        List<Usuario> ObtenerVendedores();
        Usuario BuscarPorEmail(string email);
        bool VerificarContraseña(Usuario usuarioExistente, string contrasenia);
        Mascota? BuscarMascota(string email, string nombre);
        bool RegistrarMascota(AgregarMascotaRequest mascota, string email);
    }
}
