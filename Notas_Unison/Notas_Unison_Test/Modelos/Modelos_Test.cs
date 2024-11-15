using Notas_Unison_Core.BaseDeDatos;
using Notas_Unison_Core.Models;
using NUnit.Framework;

namespace Notas_Unison_Test.Modelos;

public class Modelos_Test
{
    [Test]
    public void PruebaAgregarNota()
    {
        using var db = new NotasDB(); 
        db.Database.EnsureDeleted();
        db.Database.EnsureCreated();
       var id = Guid.NewGuid();
       Notas nota = new()
       {
           Id = id,
           Titulo = "Nota 1",
           Descripcion = "Nota 1",
       };
       db.Notas.Add(nota);
       db.SaveChanges();
       var resultado = db.Notas.Find(id);
        
       Assert.That(resultado, Is.Not.Null, "No se agregó la nota.");
       Assert.That(resultado.Id, Is.EqualTo(id), "Nota con Id incorrecta.");
    }
    
    [Test]
    public void PruebaModificarNota()
    {
        using var db = new NotasDB(); 
        db.Database.EnsureDeleted();
        db.Database.EnsureCreated();
        var id = Guid.NewGuid();
        Notas nota = new()
        {
            Id = id,
            Titulo = "Nota 1",
            Descripcion = "Descripcion 1",
        };
        db.Notas.Add(nota);
        db.SaveChanges();
        var nuevoTitulo = "Nota 1 modificada";
        nota.Titulo = nuevoTitulo;
        db.Notas.Update(nota);
        db.SaveChanges();
        var resultado = db.Notas.Find(id);
        
        Assert.That(resultado, Is.Not.Null, "No se agregó la nota.");
        Assert.That(resultado.Id, Is.EqualTo(id), "Nota con Id incorrecto.");
        Assert.That(resultado.Titulo, Is.EqualTo(nuevoTitulo), "El titulo es incorrecto.");
    }
    
    [Test]
    public void PruebaEliminarNota()
    {
        using var db = new NotasDB(); 
        db.Database.EnsureDeleted();
        db.Database.EnsureCreated();
        var id = Guid.NewGuid();
        Notas nota = new()
        {
            Id = id,
            Titulo = "Producto 1",
            Descripcion = "Descripcion 1",
        };
        db.Notas.Add(nota);
        db.SaveChanges();
        var resultado = db.Notas.Find(id);
        Assert.That(resultado, Is.Not.Null, "No se pudo agregar la nota.");
        Assert.That(resultado.Id, Is.EqualTo(id), "Nota con Id incorrecto.");
        db.Notas.Remove(nota);
        db.SaveChanges();
        Assert.That(db.Notas.Find(id), Is.Null, "La nota aún existe.");
    }
}