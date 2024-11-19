using System.Windows.Input;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.EntityFrameworkCore;
using Unison_Almacen_Core.Contratos.Servicios;
using Unison_Almacen_Core.Modelos;
using Unison_Almacen_Core.Servicios;
namespace Unison_Almacen_App.ViewModel;

public partial class NotasViewModel : ObservableObject
{
    [ObservableProperty] private Notas _nota = new Notas();
    [ObservableProperty] private List<Notas> _notas;

    [ObservableProperty] private string _txtBotonFormulario;
    private const string TXT_AGREGAR = "Agregar";
    private const string TXT_MODIFICAR = "Modificar";
    
    private IServicio<Notas> _servicio;

    public NotasViewModel(IServicio<Notas> servicio)
    {
        // Definir el comando.
        AgregarNotasCommand = new RelayCommand(AgregarNotas);
        EliminarNotasCommand = new RelayCommand<Notas>(EliminarNotas);
        
        // Guardar la referencia del servicio.
        _servicio = servicio;
        
        // Obtener los productos de la base de datos.
        _notas = _servicio.Listar();
        
        // Texto del formulario.
        _txtBotonFormulario = TXT_AGREGAR;
    }
    
    public ICommand AgregarNotasCommand { get; }
    public ICommand EliminarNotasCommand { get; }

    private void AgregarNotas()
    {
        var n = Nota;
        if (string.IsNullOrWhiteSpace(n.Titulo) || string.IsNullOrWhiteSpace(n.Descripcion)) return;
        
        // Comprobar si el elemento existe.
        var producto = _servicio.ObtenerPorId(n.Id);
        
        // Si el notas no existe se agrega
        if (producto.Id == Guid.Empty)
        {
            // Agregar el notas.
            _servicio.Agregar(n);
        }
        // Si el notas existe se modifica.
        else
        {
            // Modificar el notas.
            _servicio.Modificar(n);
        }
            
        // Borramos los datos del formulario.
        Nota.Id = Guid.Empty;
        Nota.Titulo = string.Empty;
        Nota.Descripcion = string.Empty;

        // Actualizar la tabla.
        Notas = _servicio.Listar();

    }
    
    private void EliminarNotas(Notas? producto)
    {
        if (producto == null) return;
        
        _servicio.Eliminar(producto);
        Notas = _servicio.Listar();
    }

    partial void OnNotaChanged(Notas? oldValue, Notas newValue)
    {
        TxtBotonFormulario = newValue.Id != Guid.Empty ? TXT_MODIFICAR : TXT_AGREGAR;
        Nota = newValue; // 
    }

}