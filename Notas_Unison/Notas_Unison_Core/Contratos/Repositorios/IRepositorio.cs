namespace Notas_Unison_Core.Contratos.Repositorios;

public interface IRepositorio<T>
{
    void Agregar(T productoNuevo);
    List<T> Listar();
    T ObtenerPorId(Guid id);
    void Modificar(T productoModificado);
    void Eliminar(T productoAEliminar);
}