using Notas_Unison_Core.Contratos.Repositorios;
using Notas_Unison_Core.BaseDeDatos;
using Notas_Unison_Core.Models;

namespace Notas_Unison_Core.Repositorios;

public class NotasRepositorio : IRepositorio<Notas>
{
    public void Agregar(Notas NotaNueva)
    {
        using var bd = new NotasDB();
        bd.Notas.Add(NotaNueva);
        bd.SaveChanges();
    }

    public List<Notas> Listar()
    {
        using var bd = new NotasDB();
        return bd.Notas.ToList();
    }

    public Notas ObtenerPorId(Guid id)
    {
        using var bd = new NotasDB();
        var resultado = bd.Notas.Find(id);
        return resultado ?? new Notas();
    }

    public void Modificar(Notas NotaModificada)
    {
        using var bd = new NotasDB();
        bd.Notas.Update(NotaModificada);
        bd.SaveChanges();
    }

    public void Eliminar(Notas NotaEliminada)
    {
        using var bd = new NotasDB();
        bd.Notas.Remove(NotaEliminada);
        bd.SaveChanges();
    }
}