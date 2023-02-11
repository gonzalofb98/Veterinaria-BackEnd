namespace Servicios.Interface
{
    public interface IServicio<T>
    {
        public List<T> ObtenerTodos();
        public T BuscarPorId(string id);
        public bool Agregar(T entity);
    }
}