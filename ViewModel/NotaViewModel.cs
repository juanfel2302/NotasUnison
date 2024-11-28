using System;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;
using System.Collections.Generic;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Notas_Unison_Core.Contratos.Servicios;
using Notas_Unison_Core.Modelos;
using Notas_Unison_Core.Servicios;
using Notas_Unison.Pages;

namespace Notas_Unison.ViewModel;

public partial class NotaViewModel : ObservableObject
{
    [ObservableProperty] private Nota _nota = new();
    [ObservableProperty] private ObservableCollection<Nota> _notas;
    [ObservableProperty] private string _colorSeleccionado;

    [ObservableProperty] private string _txtBotonFormulario;
    private const string TXT_AGREGAR = "Agregar";
    private const string TXT_MODIFICAR = "Modificar";
    
    private readonly IServicio<Nota> _servicio;

    public Dictionary<string, string> ColoresDisponibles { get; } = new()
    {
        { "Amarillo", "#FFF4B0" },
        { "Rosa", "#FFD6E0" },
        { "Verde Claro", "#D4FFCC" },
        { "Azul Claro", "#CCE6FF" },
        { "Lavanda", "#E6CCFF" }
    };

    public NotaViewModel(IServicio<Nota> servicio)
    {
        if (servicio == null)
        {
            throw new ArgumentNullException(nameof(servicio), "El servicio de notas no puede ser nulo");
        }
        
        try
        {
            _servicio = servicio;
            _notas = new ObservableCollection<Nota>();
            ActualizarListaDeNotas();
            _txtBotonFormulario = TXT_AGREGAR;
            ColorSeleccionado = ColoresDisponibles["Amarillo"];
            Nota = new Nota { Id = Guid.NewGuid(), Colorin = ColorSeleccionado };

            AgregarNotaCommand = new RelayCommand(AgregarNota);
            EliminarNotaCommand = new RelayCommand<Nota>(EliminarNota);
            EditarNotaCommand = new RelayCommand<Nota>(EditarNota);
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Error al inicializar el sistema de notas: {ex.Message}", 
                "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            throw;
        }
    }
    
    public ICommand AgregarNotaCommand { get; }
    public ICommand EliminarNotaCommand { get; }
    public ICommand EditarNotaCommand { get; }

    private void ActualizarListaDeNotas()
    {
        var notasActuales = _servicio.Listar();
        Notas.Clear();
        foreach (var nota in notasActuales)
        {
            Notas.Add(nota);
        }
    }

    private void AgregarNota()
    {
        try
        {
            if (Nota == null)
            {
                MessageBox.Show("Error: La nota es nula", 
                    "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if (string.IsNullOrWhiteSpace(Nota.Titulo) || string.IsNullOrWhiteSpace(Nota.Contenido)) 
            {
                MessageBox.Show("El título y el contenido son obligatorios", 
                    "Validación", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            if (Nota.Id == Guid.Empty)
            {
                Nota.Id = Guid.NewGuid();
            }

            var notaExistente = _servicio.ObtenerPorId(Nota.Id);
            if (notaExistente.Id == Guid.Empty)
            {
                _servicio.Agregar(Nota);
                MessageBox.Show("Nota guardada correctamente", 
                    "Éxito", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                _servicio.Modificar(Nota);
                MessageBox.Show("Nota actualizada correctamente", 
                    "Éxito", MessageBoxButton.OK, MessageBoxImage.Information);
            }

            ActualizarListaDeNotas();
            Nota = new Nota { Id = Guid.NewGuid(), Colorin = ColorSeleccionado };

            var mainWindow = Application.Current.MainWindow as MainWindow;
            if (mainWindow?.MainFrame != null)
            {
                mainWindow.MainFrame.Navigate(new ListaDeNotas());
            }
            else
            {
                MessageBox.Show("Error: No se pudo navegar a la lista de notas", 
                    "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        catch(Exception ex)
        {
            MessageBox.Show($"Error al guardar la nota: {ex.Message}", 
                "Error", MessageBoxButton.OK, MessageBoxImage.Error);
        }
    }
    
    private void EliminarNota(Nota? nota)
    {
        try
        {
            if (nota == null)
            {
                MessageBox.Show("Error: No se puede eliminar una nota nula", 
                    "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            var resultado = MessageBox.Show("¿Está seguro de que desea eliminar esta nota?", 
                "Confirmar eliminación", MessageBoxButton.YesNo, MessageBoxImage.Question);
            
            if (resultado == MessageBoxResult.Yes)
            {
                _servicio.Eliminar(nota);
                ActualizarListaDeNotas();
                MessageBox.Show("Nota eliminada correctamente", 
                    "Éxito", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Error al eliminar la nota: {ex.Message}", 
                "Error", MessageBoxButton.OK, MessageBoxImage.Error);
        }
    }

    private void EditarNota(Nota? nota)
    {
        try
        {
            if (nota == null)
            {
                MessageBox.Show("Error: No se puede editar una nota nula", 
                    "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            Nota = nota;
            var mainWindow = Application.Current.MainWindow as MainWindow;
            if (mainWindow?.MainFrame != null)
            {
                mainWindow.MainFrame.Navigate(new NuevaNota(this));
            }
            else
            {
                MessageBox.Show("Error: No se pudo navegar a la pantalla de edición", 
                    "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Error al editar la nota: {ex.Message}", 
                "Error", MessageBoxButton.OK, MessageBoxImage.Error);
        }
    }

    partial void OnNotaChanged(Nota? oldValue, Nota newValue)
    {
        if (newValue != null)
        {
            TxtBotonFormulario = newValue.Id != Guid.Empty ? TXT_MODIFICAR : TXT_AGREGAR;
        }
    }
}