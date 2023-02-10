using Dtos.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dtos.Response
{
    public class VerPedidosResponse
    {
        public List<PedidoDto> Pedidos { get; set; }
    }
}
