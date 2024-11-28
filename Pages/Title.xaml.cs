using System.Windows;
using System.Windows.Controls;
using Notas_Unison.ViewModels;

namespace Notas_Unison.Pages;

public partial class Title : Page
{
    public Title(NotaViewModel notaViewModel)
    {
        InitializeComponent();
        DataContext = notaViewModel;
    }


    private void GoToNotas(object sender, RoutedEventArgs e)
    {
        // Cargar el contenido de SecondWindow en el Frame
        ((MainWindow)Application.Current.MainWindow).MainFrame.Navigate(new ListaDeNotas());
    }
    
}