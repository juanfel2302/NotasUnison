using System.Configuration;
using System.Data;
using System.Windows;
using Microsoft.Extensions.DependencyInjection;
using Notas_Unison_Core.BaseDeDatos;
using Notas_Unison_Core.Contratos.Repositorios;
using Notas_Unison_Core.Contratos.Servicios;
using Notas_Unison_Core.Modelos;
using Notas_Unison_Core.Repositorios;
using Notas_Unison_Core.Servicios;
using Notas_Unison.Pages;
using Notas_Unison.ViewModel;
using Wpf.Ui;

namespace Notas_Unison;

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
    
    public new static App Current => (App)Application.Current;
    
    public IServiceProvider Services { get; }
    
    private static IServiceProvider ConfigServices()
    {
        var services = new ServiceCollection();
        
        try
        {
            // Registrar servicios de base de datos
            services.AddDbContext<NotasBD>(ServiceLifetime.Scoped);
            services.AddScoped<IRepositorio<Nota>, NotaRepositorio>();
            services.AddScoped<IServicio<Nota>, NotaServicio>();
            
            // Registrar el ViewModel como Singleton
            services.AddSingleton<NotaViewModel>();
            
            // Registrar las vistas
            services.AddTransient<MainWindow>();
            services.AddTransient<InformacionDeLaNota>();
            services.AddTransient<ListaDeNotas>();
            services.AddTransient<NuevaNota>();
            services.AddTransient<Title>();

            var serviceProvider = services.BuildServiceProvider();

            return serviceProvider;
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Error al configurar servicios: {ex.Message}", "Error", 
                MessageBoxButton.OK, MessageBoxImage.Error);
            throw;
        }
    }
}