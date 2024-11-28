using System.Windows;
using System.Windows.Controls;
using Notas_Unison.ViewModels;

namespace Notas_Unison.Pages;

public partial class InformacionDeLaNota : Page
{
    public InformacionDeLaNota(NotaViewModel notaViewModel)
    {
        InitializeComponent();
        DataContext = notaViewModel;
    }

    private void ModificarNota(object sender, RoutedEventArgs e)
    {
        
    }

    private void Cancelar(object sender, RoutedEventArgs e)
    {
        
    }
}