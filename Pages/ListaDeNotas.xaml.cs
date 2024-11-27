using System.Windows.Controls;

namespace Notas_Unison.Pages;

public partial class ListaDeNotas : Page
{
    public ListaDeNotas()
    {
        InitializeComponent();
    }
    
    private void AddSidebarItem_Click(object sender, RoutedEventArgs e)
    {
        // Pedir el nombre del nuevo elemento
        string newItem = PromptForItemName();

        // Verificar si el usuario ingresó un valor
        if (!string.IsNullOrWhiteSpace(newItem))
        {
            // Agregar el nuevo elemento al ListBox
            SidebarListBox.Items.Add(newItem);
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
        if (SidebarListBox.SelectedItem != null)
        {
            string selectedItem = SidebarListBox.SelectedItem.ToString();

            // Cambiar el contenido del Frame según el elemento seleccionado
            switch (selectedItem)
            {
                case "Elemento 1":
                    MainBoard.Navigate(new Page1());
                    break;
                case "Elemento 2":
                    MainBoard.Navigate(new Page2());
                    break;
                default:
                    // Cargar una página genérica
                    MainBoard.Navigate(new GenericPage(selectedItem));
                    break;
            }
        }
    }
}