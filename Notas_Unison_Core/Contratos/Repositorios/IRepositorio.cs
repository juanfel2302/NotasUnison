namespace Notas_Unison_Core.Contratos.Repositorios;

public interface IRepositorio<T>
{
    /*
     * 1. CREATE
     * 2. READ
     * 3. UPDATE
     * 4. DELETE
     */
    
    void Agregar(T notaNueva);
    List<T> Listar();
    T ObtenerPorId(Guid id);
    void Modificar(T notaModificada);
    void Eliminar(T notaAEliminar);
}