using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Microsoft.Extensions.DependencyInjection;
using Notas_Unison.Services;
using Notas_Unison.ViewModels;
using Notas_Unison.Views;
using Wpf.Ui;
using Wpf.Ui.Appearance;
using Wpf.Ui.Controls;

namespace Notas_Unison;

public partial class MainWindow : FluentWindow
{
    public MainWindow(MainWindowViewModel viewModel, IPageService pageService)
    {
        // Inicializamos el contexto de datos.
        DataContext = viewModel;
        
        // Inicializamos los componentes de la ventana.
        InitializeComponent();

        // Inicializa el tema de la aplicación.
        ApplicationThemeManager.Apply(this);

        // Establece la página de inicio.
        RootNavigation.SetPageService(pageService);
        
        // Iniciamos la aplicación en la vista de inicio.
        Loaded += (_, _) => RootNavigation.Navigate(typeof(Main));
    }
    
}