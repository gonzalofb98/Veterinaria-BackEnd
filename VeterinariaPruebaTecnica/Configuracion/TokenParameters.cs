using Servicios.Interface;

namespace VeterinariaPruebaTecnica.Configuracion
{
    public class TokenParameters : ITokenParameters
    {
        public string Usuario { get; set; }
        public string ContraseniaHash { get; set; }
        public string Id { get; set; }
    }
}
