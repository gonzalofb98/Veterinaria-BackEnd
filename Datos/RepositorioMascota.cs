using Entities;
using Entities.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public class RepositorioMascota : IRepositorioMascota
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

        public List<Mascota> _mascotas = new List<Mascota>();

        public IEnumerable<Mascota> GetTodos()
        {
            return _mascotas.ToList();
        }

        public Mascota GetPorId(int id)
        {
            var lista = _mascotas.Where(x => x.Id == id);
            if (!lista.Any())
            {
                return null;
            }
            else
            {
                return lista.First();
            }
        }

        public void Agregar(Mascota mascota)
        {
            _mascotas.Add(mascota);
        }
    }
}
