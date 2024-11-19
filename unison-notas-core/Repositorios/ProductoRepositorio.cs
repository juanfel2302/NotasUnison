using Unison_Almacen_Core.BaseDeDatos;
using Unison_Almacen_Core.Contratos.Repositorios;
using Unison_Almacen_Core.Modelos;

namespace Unison_Almacen_Core.Repositorios;

public class NotasRepositorio : IRepositorio<Notas>
{
    public void Agregar(Notas notaNuevo)
    {
        // 1. Crear la conexión a la basse de datos.
        using var bd = new NotasDB();
        
        // 2. Agregar el notas a la base de datos.
        bd.Notas.Add(notaNuevo);
        
        // 3. Guardar los cambios en la base de datos.
        bd.SaveChanges();
    }

    public List<Notas> Listar()
    {
        // 1. Crear una conexión a la base de datos.
        using var bd = new NotasDB();

        // 2. Devolver una lista con todos los productos.
        return bd.Notas.ToList();
    }

    public Notas ObtenerPorId(Guid id)
    {
        // 1. Obtener la conexión con la base de datos.
        using var bd = new NotasDB();
        
        // 2. Buscar el producto.
         var resultado = bd.Notas.Find(id);
         
        // 3. Devolver el producto.
        return resultado ?? new Notas();
    }

    public void Modificar(Notas notaModificado)
    {
        // 1. Crear conexión con la base de datos.
        using var bd = new NotasDB();
        
        // 2. Modificar el notas.
        bd.Notas.Update(notaModificado);
        
        // 3. Guardar los cambios en la base de datos.
        bd.SaveChanges();
    }

    public void Eliminar(Notas notaAEliminar)
    {
        // 1. Crear conexión con la base de datos.
        using var bd = new NotasDB();
        
        // 2. Eliminar el notas.
        bd.Notas.Remove(notaAEliminar);
        
        // 3. Actualizar la base de datos.
        bd.SaveChanges();
    }
}