using System;
using System.Windows;
using System.Windows.Controls;
using Notas_Unison.ViewModel;

namespace Notas_Unison.Pages;

public partial class NuevaNota : Page
{
    private readonly NotaViewModel? _viewModel;

    public NuevaNota(NotaViewModel viewModel)
    {
        InitializeComponent();
        _viewModel = viewModel;
        DataContext = _viewModel;
    }

    private void Cancelar(object sender, RoutedEventArgs e)
    {
        try
        {
            ((MainWindow)Application.Current.MainWindow)?.MainFrame.Navigate(new ListaDeNotas());
        }
        catch (Exception ex)
        {
            System.Windows.MessageBox.Show($"Error al navegar a ListaDeNotas: {ex.Message}", 
                "Error", MessageBoxButton.OK, MessageBoxImage.Error);
        }
    }

    private void TestCommand(object sender, RoutedEventArgs e)
    {
        try
        {
            if (_viewModel == null)
            {
                System.Windows.MessageBox.Show("Error: ViewModel es null", 
                    "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            var estado = $"Estado del ViewModel:\n" +
                        $"- Comando AgregarNota existe: {_viewModel.AgregarNotaCommand != null}\n" +
                        $"- Nota actual: {(_viewModel.Nota != null ? "existe" : "null")}\n" +
                        $"- Título: {_viewModel.Nota?.Titulo}\n" +
                        $"- Contenido: {_viewModel.Nota?.Contenido}";
            
            System.Windows.MessageBox.Show(estado, "Estado del ViewModel", 
                MessageBoxButton.OK, MessageBoxImage.Information);
            
            if (_viewModel.AgregarNotaCommand?.CanExecute(null) == true)
            {
                _viewModel.AgregarNotaCommand.Execute(null);
                System.Windows.MessageBox.Show("Comando ejecutado", 
                    "Éxito", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                System.Windows.MessageBox.Show("El comando no se puede ejecutar", 
                    "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        catch (Exception ex)
        {
            System.Windows.MessageBox.Show($"Error al ejecutar el comando de prueba: {ex.Message}", 
                "Error", MessageBoxButton.OK, MessageBoxImage.Error);
        }
    }

    private void GuardarNota(object sender, RoutedEventArgs e)
    {
        try
        {
            // Asignar el color seleccionado a la nota
            _viewModel.Nota.Colorin = _viewModel.ColorSeleccionado;
            
            // Ejecutar el comando de agregar nota
            if (_viewModel.AgregarNotaCommand.CanExecute(null))
            {
                _viewModel.AgregarNotaCommand.Execute(null);
            }
        }
        catch (System.Exception ex)
        {
            MessageBox.Show($"Error al guardar la nota: {ex.Message}", 
                "Error", MessageBoxButton.OK, MessageBoxImage.Error);
        }
    }
}