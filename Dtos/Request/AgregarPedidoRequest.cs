using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dtos.Request
{
    public class AgregarPedidoRequest
    {
        [Required]
        public string Direccion { get; set; }
    }
}
