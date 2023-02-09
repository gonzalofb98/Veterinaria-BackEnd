using Entities;
using Entities.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public class RepositorioPedido : IRepository<Pedido>
    {
        private static RepositorioPedido instance = null;
        public static RepositorioPedido Instance
        {
            get
            {
                if (instance == null)
                    instance = new RepositorioPedido();
                return instance;
            }
        }
        protected RepositorioPedido() { IniciarPersistenciaPedido(); }

        private void IniciarPersistenciaPedido()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Pedido> GetTodos()
        {
            throw new NotImplementedException();
        }

        public Pedido GetPorId(int id)
        {
            throw new NotImplementedException();
        }

        public void Agregar(Pedido entity)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
