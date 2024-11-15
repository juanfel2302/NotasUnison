using System.Windows;
using System.Windows.Controls;
using Notas_Unison.ViewModels;

namespace Notas_Unison.Views;

public partial class InicioView : Page
{
    public InicioView()
    {
        InitializeComponent();
    }
    
    private void IrAgregarView(object sender, RoutedEventArgs e)
    {
        var agregarView = new AgregarView();
        agregarView.Show();
    }
}