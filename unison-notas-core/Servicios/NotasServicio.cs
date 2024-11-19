using Unison_Almacen_Core.Contratos.Repositorios;
using Unison_Almacen_Core.Contratos.Servicios;                                      
using Unison_Almacen_Core.Modelos;

namespace Unison_Almacen_Core.Servicios;

public class NotasServicio(IRepositorio<Notas> repositorio) : IServicio<Notas>
{
    public void Agregar(Notas notasNuevo)
    {
        repositorio.Agregar(notasNuevo);
    }

    public List<Notas> Listar()
    {
        return repositorio.Listar();
    }

    public Notas ObtenerPorId(Guid id)
    {
        return repositorio.ObtenerPorId(id);
    }

    public void Modificar(Notas notasModificado)
    {
        repositorio.Modificar(notasModificado);
    }

    public void Eliminar(Notas notasAEliminar)
    {
        repositorio.Eliminar(notasAEliminar);
    }
}