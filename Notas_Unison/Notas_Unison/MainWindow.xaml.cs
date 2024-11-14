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
using Wpf.Ui.Controls;

namespace Notas_Unison;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();

        var serviceProvider = new ServiceCollection()
            .AddSingleton<IPageService, PageService>()
            .BuildServiceProvider();

        var pageService = serviceProvider.GetService<IPageService>();

        DataContext = new MainViewModel(pageService, NavigationFrame);
    }
}