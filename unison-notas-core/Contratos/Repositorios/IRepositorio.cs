
using notas_unison_core.BaseDeDatos;
using notas_unison_core.modelos;

namespace unison_notas_core.Repositorios;

public class NotasRepositorio : IRepositorio<Notas>
{
    public void Agregar(Notas notaNueva)
    {
        using var bd = new NotasBD();
        
        bd.Notas.Add(notaNueva);
        
        bd.SaveChanges();
    }

    public List<Notas> Listar()
    {
        using var bd = new NotasBD();
        
        return bd.Notas.ToList();
    }

    public Notas ObtenerPorId(Guid id)
    {
        using var bd = new NotasBD();
        
        return bd.Notas.Find(id);
    }

    public void Modificar(Notas notaModificacion)
    {
        using var bd = new NotasBD();
        
        bd.Notas.Update(notaModificacion);

        bd.SaveChanges();
    }

    public void Eliminar(Notas notaAeliminar)
    {
        using var bd = new NotasBD();

        bd.Notas.Remove(notaAeliminar);

        bd.SaveChanges();
    }
}

