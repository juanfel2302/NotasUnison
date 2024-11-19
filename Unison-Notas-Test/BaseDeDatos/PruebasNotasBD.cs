using Unison_Almacen_Core.BaseDeDatos;
using Unison_Almacen_Core.Modelos;

namespace Unison_Almacen_Test.BaseDeDatos;

public class PruebasNotasBD
{
    [Test]
    public void PruebaAgregarNotas()
    {
        // 1. Crear la conexión con la base de datos.
        using var db = new NotasDB(); 
        
        // 2. Eliminar el contenido de la base de datos.
        db.Database.EnsureDeleted();
        
        // 3. Asegurar que la base de datos exista.
        db.Database.EnsureCreated();
       
       // 4. Crear id del notas.
       var id = Guid.NewGuid();
        
       // 5. Crear un notas.
       Notas notas = new()
       {
           Id = id,
           Titulo = "Notas 1",
           Descripcion = "Descripcion 1"
       };

       // 6. Añadir el notas a la base de datos.
       db.Notas.Add(notas);
       db.SaveChanges();
        
       // 7. Consultar los productos para comprobar que se añadió el notas.
       var resultado = db.Notas.Find(id);
        
       Assert.That(resultado, Is.Not.Null, "No se agregó la nota.");
       Assert.That(resultado.Id, Is.EqualTo(id), "Notas con Id incorrecto.");
    }
    
    [Test]
    public void PruebaModificarNotas()
    {
        // 1. Crear la conexión con la base de datos.
        using var db = new NotasDB(); 
        
        // 2. Eliminar el contenido de la base de datos.
        db.Database.EnsureDeleted();
        
        // 3. Asegurar que la base de datos exista.
        db.Database.EnsureCreated();
       
        // 4. Crear id del notas.
        var id = Guid.NewGuid();
        
        // 5. Crear un notas.
        Notas notas = new()
        {
            Id = id,
            Titulo = "Notas 1",
            Descripcion = "Descripcion nota"
        };

        // 6. Añadir el notas a la base de datos.
        db.Notas.Add(notas);
        db.SaveChanges();
        
        // 7. Modificar el notas.
        var nuevoNombre = "Notas 2";
        notas.Titulo = nuevoNombre;
        
        // 8. Guardar cambios en la bd.
        db.Notas.Update(notas);
        db.SaveChanges();
        
        // 7. Consultar los productos para comprobar que se añadió el notas.
        var resultado = db.Notas.Find(id);
        
        Assert.That(resultado, Is.Not.Null, "No se agregó la notas.");
        Assert.That(resultado.Id, Is.EqualTo(id), "Notas con Id incorrecto.");
        Assert.That(resultado.Titulo, Is.EqualTo(nuevoNombre), "Notas con Nombre incorrecto.");
    }
    
    [Test]
    public void PruebaEliminarNotas()
    {
        // 1. Crear la conexión con la base de datos.
        using var db = new NotasDB(); 
        
        // 2. Eliminar el contenido de la base de datos.
        db.Database.EnsureDeleted();
        
        // 3. Asegurar que la base de datos exista.
        db.Database.EnsureCreated();
       
        // 4. Crear id del notas.
        var id = Guid.NewGuid();
        
        // 5. Crear un notas.
        Notas notas = new()
        {
            Id = id,
            Titulo = "Notas 1",
            Descripcion = "Descripcion nota"
           
        };

        // 6. Añadir el notas a la base de datos.
        db.Notas.Add(notas);
        db.SaveChanges();
        
        // 7. Consultar los productos para comprobar que se añadió el notas.
        var resultado = db.Notas.Find(id);
        
        // 8. Comprobar que el notas se añadió correctamente.
        Assert.That(resultado, Is.Not.Null, "No se agregó la notaa.");
        Assert.That(resultado.Id, Is.EqualTo(id), "Notas con Id incorrecto.");
        
        // 9. Eliminar el notas de la base de datos.
        db.Notas.Remove(notas);
        db.SaveChanges();
        
        // 10. Comprobar que el notas se eliminó de la base de datos.
        Assert.That(db.Notas.Find(id), Is.Null, "Notas aún existe.");
    }
}