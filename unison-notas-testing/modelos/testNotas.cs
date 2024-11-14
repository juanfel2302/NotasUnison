using notas_unison_core.modelos;
namespace unison_notas_testing.modelos;

public class testNotas
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void testNotasId()
    {
        var notas = new Notas();

        var notasId = Guid.NewGuid();
        notas.Id = notasId;
        
        Assert.That(notas.Id, Is.EqualTo(notasId));
    }

    [Test]
    public void testNotasTitulos()
    {
        var notas = new Notas();
        
        const string tituloNota = "Tareas";
        notas.titulo = tituloNota;
        
        Assert.That(notas.titulo, Is.EqualTo(tituloNota));
    }

    [Test]
    public void testNotasDescripcion()
    {
        var notas = new Notas();
        const string descripcionNota = "Ingles tarea";
        notas.descripcion = descripcionNota;
        
        Assert.That(notas.descripcion, Is.EqualTo(descripcionNota));
    }

}