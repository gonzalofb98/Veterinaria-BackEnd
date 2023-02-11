using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servicios.Interface
{
    public interface ITokenParameters
    {
        string Usuario { get; set; }
        string ContraseniaHash { get; set; }
        string Id { get; set; }
    }
}
