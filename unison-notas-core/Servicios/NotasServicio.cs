using notas_unison_core.Contratos.Repositorios;
using notas_unison_core.Contratos.Servicios;
using notas_unison_core.modelos;

namespace notas_unison_core.Servicios;

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

    public Notas ObtenerPorI(Guid id)
    {
        return repositorio.ObtenerPorI(id);
    }

    public void Modificar(Notas notasModificar)
    {
        repositorio.Modificar(notasModificar);
    }

    public void Eliminar(Notas notasEliminar)
    {
        repositorio.Eliminar(notasEliminar);
    }
    
}