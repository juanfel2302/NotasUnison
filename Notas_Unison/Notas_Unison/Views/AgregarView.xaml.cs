using System.Windows.Controls;
using System.Windows;
using System.Windows.Media;
using Notas_Unison.ViewModels;

namespace Notas_Unison.Views;

public partial class AgregarView : Page
{
    public AgregarView(AgregarViewModel viewModel)
    {
        InitializeComponent();
        DataContext = viewModel;
    }
    
    private void ColorButton_Click(object sender, RoutedEventArgs e)
    {
        if (sender is Button clickedButton)
        {
            MainGrid.Background = clickedButton.Background;
        }
    }
}