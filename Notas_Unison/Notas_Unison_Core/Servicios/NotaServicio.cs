using Notas_Unison_Core.Contratos.Repositorios;
using Notas_Unison_Core.Contratos.Servicios;
using Notas_Unison_Core.Models;

namespace Notas_Unison_Core.Servicios;

public class NotaServicio(IRepositorio<Notas> repositorio) : IServicio<Notas>
{
    public void Agregar(Notas NotaNueva)
    {
        repositorio.Agregar(NotaNueva);
    }

    public List<Notas> Listar()
    {
        return repositorio.Listar();
    }

    public Notas ObtenerPorId(Guid id)
    {
        return repositorio.ObtenerPorId(id);
    }

    public void Modificar(Notas NotaModificada)
    {
        repositorio.Modificar(NotaModificada);
    }

    public void Eliminar(Notas NotaEliminada)
    {
        repositorio.Eliminar(NotaEliminada);
    }
}