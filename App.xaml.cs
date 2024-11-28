using System.Configuration;
using System.Data;
using System.Windows;
using Microsoft.Extensions.DependencyInjection;
using Notas_Unison_Core.BaseDeDatos;
using Notas_Unison_Core.Contratos.Servicios;
using Notas_Unison.Pages;
using Notas_Unison.Servicios;
using Notas_Unison.ViewModels;
using Wpf.Ui;


namespace Notas_Unison;

/// <summary>
/// Interaction logic for App.xaml
/// </summary>
public sealed partial class App : Application
{
    public App()
    {
        InitializeComponent();
        
        // Inicializar los servicios.
        Services = ConfigServices();
        
        // Asegurar que la base de datos existe.
        using var bd = new NotasBD();
        bd.Database.EnsureCreated();
    }
    
    /// <summary>
    /// Obtiene la referencia de la aplicación actual.
    /// </summary>
    public new static App Current => (App)Application.Current;
    
    /// <summary>
    /// Obtiene el proveedor para resolver los servicios de la aplicación.
    /// </summary>
    public IServiceProvider Services { get; }
    
    /// <summary>
    /// Configura los servicios de la aplicación.
    /// </summary>
    /// <returns></returns>
    private static IServiceProvider ConfigServices()
    {
        var services = new ServiceCollection();
        
        // Servicios.
        services.AddTransient<NotasBD>();
        services.AddTransient<IServicio<Nota>, ProductoServicio>();
        services.AddTransient<IRepositorio<Nota>, ProductoRepositorio>();
        services.AddSingleton<IPageService, PageService>();

        // MainWindow.
        services.AddSingleton<MainWindow>();
                
        // Views
        services.AddTransient<InformacionDeLaNota>();
        services.AddTransient<ListaDeNotas>();
        services.AddTransient<NuevaNota>();
        services.AddTransient<Title>();
        
        // ViewModels.
        services.AddTransient<NotaViewModel>();
        
        return services.BuildServiceProvider();
    }
    
    protected override void OnStartup(StartupEventArgs e)
    {
        base.OnStartup(e);
        
        var mainWindow = Services.GetRequiredService<MainWindow>();
        mainWindow.Show();
    }
}