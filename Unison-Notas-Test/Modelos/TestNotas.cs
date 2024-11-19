using Unison_Almacen_Core.Modelos;

namespace Unison_Almacen_Test.Modelos;

public class TestNotas
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void PruebaNotasId()
    {
        // 1. Crear un notas.
        var notas = new Notas();

        // 2. Asignarle un Id.
        var notasId = Guid.NewGuid();
        notas.Id = notasId;

        // 3. Comprobar que el Id asignado es el mismo
        //    que devuelve.
        Assert.That(notas.Id, Is.EqualTo(notasId));
    }

    [Test]
    public void PruebaNotasNombre()
    {
        /*
         * 1. Crear un notas.
         * 2. Asignarle un nombre.
         * 3. Comprobar que el nombre asignado es el
         *    mismo que devuelve.
         */

        // 1. Crear un notas.
        var notas = new Notas();

        // 2. Asignarle un nombre.
        const string tituloNotas = "MAtematicas";
        notas.Titulo = tituloNotas;

        // 3. Comprobar que el nombre asignado es el
        //    mismo que devuelve.
        Assert.That(notas.Titulo, Is.EqualTo(tituloNotas));
    }

    [Test]
    public void PruebaNotasDescripcion()
    {
        // 1. Crear un notas.
        var notas = new Notas();

        // 2. Asignar la descripción.
        const string descripcion = "Tarea de matematicas";
        notas.Descripcion = descripcion;

        // 3. Comprobar que la descripción asignada es la
        //    misma que devuelve.
        Assert.That(notas.Descripcion, Is.EqualTo(descripcion));
    }
}