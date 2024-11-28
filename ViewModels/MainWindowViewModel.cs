using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using Notas_Unison.Pages;
using Wpf.Ui.Controls;
using System.Configuration.Provider;


namespace Notas_Unison.ViewModels;

public partial class MainWindowViewModel : ObservableObject
{
    [ObservableProperty] private ObservableCollection<NavigationViewItem> _navigationItems = [];

    public MainWindowViewModel()
    {
        NavigationItems =
        [
            new NavigationView()
            {
                Content = "Lista de Notas",
                TargetPageType = typeof(ListaDeNotas)
            },

        ];
    }
}