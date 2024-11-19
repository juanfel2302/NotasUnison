using System.Windows.Controls;
using CommunityToolkit.Mvvm.ComponentModel;
using Unison_Almacen_App.ViewModel;
using Unison_Almacen_Core.Modelos;

namespace Unison_Almacen_App.Views;

public partial class NotasView : Page
{
    public NotasView(NotasViewModel viewModel)
    {
        InitializeComponent();
        
        // Inicializar el DataContext.
        DataContext = viewModel;
    }
}