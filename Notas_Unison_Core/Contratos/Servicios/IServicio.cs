namespace Notas_Unison_Core.Contratos.Servicios;

public interface IServicio<T>
{
    void Agregar(T NotaNueva);
    List<T> Listar();
    T ObtenerPorId(Guid Id);
    
}