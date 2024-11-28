using System.Windows;
using System.Windows.Controls;
using MessageBox = Wpf.Ui.Controls.MessageBox;
using MessageBoxButton = Wpf.Ui.Controls.MessageBoxButton;

namespace Notas_Unison.Pages;

public partial class ListaDeNotas : Page
{
    public ListaDeNotas()
    {
        InitializeComponent();
    }

    private void GoToNuevaNota(object sender, RoutedEventArgs e)
    {
        ((MainWindow)Application.Current.MainWindow).MainFrame.Navigate(new NuevaNota());
    }

    private void ImportarNota(object sender, RoutedEventArgs e)
    {
        
    }

    private void ExportarNota(object sender, RoutedEventArgs e)
    {
        
    }
    
    private string PromptForItemName()
    {
        // Mostrar un cuadro de diálogo simple para ingresar el nombre
        string input = Microsoft.VisualBasic.Interaction.InputBox(
            "Por favor, ingresa el nombre del nuevo elemento:",
            "Añadir elemento",
            "Nota1");

        return input;
    }
    
    private void SidebarListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        if (NotasListBox.SelectedItem != null)
        {
            string selectedItem = NotasListBox.SelectedItem.ToString();
            
            switch (selectedItem)
            {
                default:
                    ((MainWindow)Application.Current.MainWindow).MainFrame.Navigate(new InformacionDeLaNota());
                    break;
            }
        }
    }
}