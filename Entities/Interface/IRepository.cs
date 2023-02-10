﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Interface
{
    public interface IRepository<T>
        where T : EntidadBase
    {
        public List<T> ObtenerTodos();
        public T BuscarPorId(int id);
        public void Agregar(T entity);
    }
}
