namespace Notas_Unison_Core.Contratos.Repositorios;

public interface IRepositorio<T>
{
    void Agregar(T NotaNueva);
    List<T> Listar();
    T ObtenerPorId(Guid id);
    void Modificar(T NotaModificada);
    void Eliminar(T NotaEliminada);
}