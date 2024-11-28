using Notas_Unison_Core.Contratos.Repositorios;
using Notas_Unison_Core.Contratos.Servicios;
using Notas_Unison_Core.Modelos;

namespace Notas_Unison_Core.Servicios;

public class NotaServicio(IRepositorio<Nota> repositorio) : IServicio<Nota>
{
    public void Agregar(Nota notaNueva)
    {
        repositorio.Agregar(notaNueva);
    }

    public List<Nota> Listar()
    {
        return repositorio.Listar();
    }

    public Nota ObtenerPorId(Guid id)
    {
        return repositorio.ObtenerPorId(id);
    }

    public void Modificar(Nota notaModificada)
    {
        repositorio.Modificar(notaModificada);
    }

    public void Eliminar(Nota notaAEliminar)
    {
        repositorio.Eliminar(notaAEliminar);
    }
}