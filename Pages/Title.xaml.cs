using System.Windows;
using System.Windows.Controls;

namespace Notas_Unison.Pages;

public partial class Title : Page
{
    public Title()
    {
        InitializeComponent();
    }
    
    private void GoToNotas(object sender, RoutedEventArgs e)
    {
        // Cargar el contenido de SecondWindow en el Frame
        ((MainWindow)Application.Current.MainWindow).MainFrame.Navigate(new ListaDeNotas());
    }
    
}