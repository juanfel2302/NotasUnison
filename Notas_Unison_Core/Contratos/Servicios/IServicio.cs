namespace Notas_Unison_Core.Contratos.Servicios;

public interface IServicio<T>
{
    void Agregar(T notaNueva);
    List<T> Listar();
    T ObtenerPorId(Guid Id);
    void Modificar(T notaModificada);
    void Eliminar(T notaAEliminar);
}