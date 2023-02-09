using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Vendedor : Usuario
    {
        public void DespacharPedido(Pedido pedido)
        {
            pedido.Estado = Estado.DESPACHADO;
        }
    }
}
