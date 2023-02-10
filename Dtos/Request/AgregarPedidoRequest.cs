using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dtos.Request
{
    public class AgregarPedidoRequest
    {
        public int Codigo { get; set; }
        public string Direccion { get; set; }
    }
}
