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
    
    private void AddSidebarItem_Click(object sender, RoutedEventArgs e)
    {
        // Pedir el nombre del nuevo elemento
        string newItem = PromptForItemName();

        // Verificar si el usuario ingresó un valor
        if (!string.IsNullOrWhiteSpace(newItem))
        {
            // Agregar el nuevo elemento al ListBox
            NotasListBox.Items.Add(newItem);
        }
        else
        {
            MessageBox.Show("No se agregó ningún elemento, el nombre no puede estar vacío.", "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
        }
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