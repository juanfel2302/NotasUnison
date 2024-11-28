using System.Windows;
using System.Windows.Controls;
using Microsoft.Extensions.DependencyInjection;
using Notas_Unison.ViewModel;

namespace Notas_Unison.Pages;

public partial class NuevaNota : Page
{
    public NuevaNota()
    {
        InitializeComponent();
        var viewModel = App.Current.Services.GetService<NotaViewModel>();
        DataContext = viewModel;
    }

    private void Cancelar(object sender, RoutedEventArgs e)
    {
        
    }
}