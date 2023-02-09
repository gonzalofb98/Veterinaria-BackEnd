using Entities;
using Entities.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public class RepositorioMascota : IRepository<Mascota>
    {
        private static RepositorioMascota instance = null;
        public static RepositorioMascota Instance
        {
            get
            {
                if (instance == null)
                    instance = new RepositorioMascota();
                return instance;
            }
        }
        protected RepositorioMascota() { IniciarPersistenciaMascota(); }

        private void IniciarPersistenciaMascota()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Mascota> GetTodos()
        {
            throw new NotImplementedException();
        }

        public Mascota GetPorId(int id)
        {
            throw new NotImplementedException();
        }

        public void Agregar(Mascota entity)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
