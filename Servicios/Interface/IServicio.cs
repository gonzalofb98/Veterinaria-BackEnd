namespace Servicios.Interface
{
    public interface IServicio<T>
    {
        public List<T> ObtenerTodos();
        public T BuscarPorId(int id);
        public void Agregar(T entity);
    }
}