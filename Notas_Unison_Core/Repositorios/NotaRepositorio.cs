using Notas_Unison_Core.BaseDeDatos;
using Notas_Unison_Core.Modelos;
using Notas_Unison_Core.Contratos.Repositorios;

namespace Notas_Unison_Core.Repositorios;

public class NotaRepositorio : IRepositorio<Nota>
{
    public void Agregar(Nota notaNueva)
    {
        // 1. Crear la conexión a la basse de datos.
        using var bd = new NotasBD();
        
        // 2. Agregar el producto a la base de datos.
        bd.Notas.Add(notaNueva);
        
        // 3. Guardar los cambios en la base de datos.
        bd.SaveChanges();
    }

    public List<Nota> Listar()
    {
        // 1. Crear una conexión a la base de datos.
        using var bd = new NotasBD();

        // 2. Devolver una lista con todas las notas.
        return bd.Notas.ToList();
    }

    public Nota ObtenerPorId(Guid id)
    {
        // 1. Obtener la conexión con la base de datos.
        using var bd = new NotasBD();
        
        // 2. Buscar la nota.
        var resultado = bd.Notas.Find(id);
         
        // 3. Devolver la nota.
        return resultado ?? new Nota();
    }

    public void Modificar(Nota notaModificada)
    {
        // 1. Crear conexión con la base de datos.
        using var bd = new NotasBD();
        
        // 2. Modificar la nota.
        bd.Notas.Update(notaModificada);
        
        // 3. Guardar los cambios en la base de datos.
        bd.SaveChanges();
    }

    public void Eliminar(Nota notaAEliminar)
    {
        // 1. Crear conexión con la base de datos.
        using var bd = new NotasBD();
        
        // 2. Eliminar la nota.
        bd.Notas.Remove(notaAEliminar);
        
        // 3. Actualizar la base de datos.
        bd.SaveChanges();
    }
}