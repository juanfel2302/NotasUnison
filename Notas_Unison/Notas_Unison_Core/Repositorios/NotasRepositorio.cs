using Notas_Unison_Core.Contratos.Repositorios;
using Notas_Unison_Core.BaseDeDatos;
using Notas_Unison_Core.Models;

namespace Notas_Unison_Core.Repositorios;

public class NotasRepositorio : IRepositorio<Nota>
{
    public void Agregar(Nota NotaNueva)
    {
        using var bd = new NotasDB();
        bd.Notas.Add(NotaNueva);
        bd.SaveChanges();
    }

    public List<Nota> Listar()
    {
        using var bd = new NotasDB();
        return bd.Notas.ToList();
    }

    public Nota ObtenerPorId(Guid id)
    {
        using var bd = new NotasDB();
        var resultado = bd.Notas.Find(id);
        return resultado ?? new Notas();
    }

    public void Modificar(Nota NotaNueva)
    {
        using var bd = new NotasDB();
        bd.Notas.Update(NotaModificada);
        bd.SaveChanges();
    }

    public void Eliminar(Producto productoAEliminar)
    {
        using var bd = new ProductoBD();
        bd.Productos.Remove(productoAEliminar);
        bd.SaveChanges();
    }
}