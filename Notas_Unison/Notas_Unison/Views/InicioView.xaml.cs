using System.Windows;
using System.Windows.Controls;
using Notas_Unison.ViewModels;

namespace Notas_Unison.Views;

public partial class InicioView : Page
{
    private readonly InicioViewModel _inicioViewModel;

    public InicioView(InicioViewModel viewModel)
    {
        InitializeComponent();
        DataContext = viewModel;
    }
}