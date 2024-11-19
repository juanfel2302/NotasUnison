using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using Notas_Unison.Views;
using Wpf.Ui.Controls;

namespace Notas_Unison.ViewModels;

public partial class MainWindowViewModel : ObservableObject
{
    [ObservableProperty] private ObservableCollection<NavigationViewItem> _navigationItems = [];

    public MainWindowViewModel() {
        NavigationItems =
        [
            new NavigationViewItem()
            {
                Content = "Inicio",
                TargetPageType = typeof(Main)
            },
            new NavigationViewItem()
            {
                Content = "Notas",
                TargetPageType = typeof(InicioView)
            },
            
            new NavigationViewItem()
            {
                Content = "Agregar Nota",
                TargetPageType = typeof(AgregarView)
            },
            
            new NavigationViewItem()
            {
                Content = "Editar Nota",
                TargetPageType = typeof(InformacionView)
            }
        ];
    }
}


