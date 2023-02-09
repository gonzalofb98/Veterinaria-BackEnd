using Entities;
using Entities.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public class RepositorioUsuario : IRepository<Usuario>
    {
        private static RepositorioUsuario instance = null;
        public static RepositorioUsuario Instance
        {
            get
            {
                if (instance == null)
                    instance = new RepositorioUsuario();
                return instance;
            }
        }
        protected RepositorioUsuario() { IniciarPersistenciaUsuario(); }

        private void IniciarPersistenciaUsuario()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Usuario> GetTodos()
        {
            throw new NotImplementedException();
        }

        public Usuario GetPorId(int id)
        {
            throw new NotImplementedException();
        }

        public void Agregar(Usuario entity)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
