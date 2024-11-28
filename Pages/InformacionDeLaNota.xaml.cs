using System.Windows;
using System.Windows.Controls;
using Microsoft.Extensions.DependencyInjection;
using Notas_Unison.ViewModels;

namespace Notas_Unison.Pages;

public partial class InformacionDeLaNota : Page
{
    public InformacionDeLaNota()
    {
        InitializeComponent();
        var viewModel = App.Current.Services.GetService<NotaViewModel>();
        DataContext = viewModel;
    }

    private void Cancelar(object sender, RoutedEventArgs e)
    {
        
    }
}