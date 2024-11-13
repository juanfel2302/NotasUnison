using Notas_Unison_Core.Contratos.Repositorios;
using Notas_Unison_Core.Contratos.Servicios;
using Notas_Unison_Core.Models;

namespace Notas_Unison_Core.Servicios;

public class NotaServicio(IRepositorio<Nota> repositorio) : IServicio<Nota>
{
    public void Agregar(Nota NotaNueva)
    {
        repositorio.Agregar(NotaNueva);
    }

    public List<Nota> Listar()
    {
        return repositorio.Listar();
    }

    public Nota ObtenerPorId(Guid id)
    {
        return repositorio.ObtenerPorId(id);
    }

    public void Modificar(Nota NotaModificada)
    {
        repositorio.Modificar(NotaModificada);
    }

    public void Eliminar(Nota NotaEliminada)
    {
        repositorio.Eliminar(NotaEliminada);
    }
}