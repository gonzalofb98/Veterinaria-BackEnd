using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;
using Entities.Interface;
using Servicios.Interface;

namespace Servicios
{
    public class MascotaServicio : IMascotaServicio
    {
        private readonly IRepositorioMascota _repositorioMascotas;
        public MascotaServicio(IRepositorioMascota repositorioPedidos)
        {
            _repositorioMascotas = repositorioPedidos;
        }

        public List<Mascota> ObtenerTodos()
        {
            return _repositorioMascotas.ObtenerTodos();
        }
        public Mascota BuscarPorId(int id)
        {
            return _repositorioMascotas.BuscarPorId(id);
        }
        public void Agregar(Mascota entity)
        {
            _repositorioMascotas.Agregar(entity);
        }
    }
}
