using notas_unison_core.BaseDeDatos;
using notas_unison_core.Contratos.Repositorios;
using notas_unison_core.modelos;


namespace notas_unison_core.Repositorios;

public class NotasRepositorios : IRepositorio<Notas>
{
    public void Agregar(Notas notasNuevo)
    {
        using var bd = new NotasBD();
        
        bd.Notas.Add(notasNuevo);
        
        bd.SaveChanges();
    }

    public List<Notas> Listar()
    {
        using var bd= new NotasBD();
        
        return bd.Notas.ToList();
    }

    public Notas ObtenerPorId(Guid id)
    {
        using var bd = new NotasBD();
        var result = bd.Notas.Find(id);
        return result ?? new Notas();
    }

    public void Modificar(Notas notasModificada)
    {
        using var bd = new NotasBD();
        bd.Notas.Update(notasModificada);
        bd.SaveChanges();
        
    }

    public void Eliminar(Notas notasEliminada)
    {
        using var bd = new NotasBD();
        
        bd.Notas.Remove(notasEliminada);
        
        bd.SaveChanges();
    }


}
