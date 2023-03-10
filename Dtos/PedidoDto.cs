using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dtos
{
    public class PedidoDto
    {
        public string Codigo { get; set; }
        public string Direccion { get; set; }
        public List<ComboDto> Combos { get; set; }
        public Estado Estado { get; set; }
        public string FechaCreacion { get; set; }
    }
}
