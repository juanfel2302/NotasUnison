namespace Notas_Unison_Core.Contratos.Servicios;

public interface IServicio<T>
{
    void Agregar(T NotaNueva);
    List<T> Listar();
    T ObtenerPorId(Guid id);
    void Modificar(T NotaNodificada);
    void Eliminar(T NotaEliminada);
}