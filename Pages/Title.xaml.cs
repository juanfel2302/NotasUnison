using System.Windows;
using System.Windows.Controls;
using Notas_Unison.ViewModels;

namespace Notas_Unison.Pages;

public partial class Title : Page
{
    public Title()
    {
        InitializeComponent();
    }


    private void GoToNotas(object sender, RoutedEventArgs e)
    {
        // Cargar contenido en el frame jeje
        ((MainWindow)Application.Current.MainWindow).MainFrame.Navigate(new ListaDeNotas());
    }
    
}