using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Windows.Input;
using Notas_Unison_Core.Contratos.Servicios;
using Notas_Unison_Core.Models;

namespace Notas_Unison.ViewModels;

public partial class AgregarViewModel : ObservableObject
{
    [ObservableProperty] private Notas _nota = new Notas();
    [ObservableProperty] private ObservableCollection<Notas> _notas;
    [ObservableProperty] private string errorMensaje;
    
    private readonly IServicio<Notas> _notasService;

    public AgregarViewModel(IServicio<Notas> notasService)
    {
        AggregateNotaCommand = new RelayCommand(AggregateNota);
        _notasService = notasService;
        _notas = new ObservableCollection<Notas>(_notasService.Listar() ?? new List<Notas>());
    }
    public ICommand AggregateNotaCommand { get; }

    private void AggregateNota()
    {
        
        Console.WriteLine("AggregateNota llamado");
        Console.WriteLine("Agregar nota");
        Console.WriteLine(Nota.Titulo);
        Console.WriteLine(Nota.Descripcion);
        if (string.IsNullOrWhiteSpace(Nota.Titulo) || string.IsNullOrWhiteSpace(Nota.Descripcion))
        {
            ErrorMensaje = "Todos los campos deben estar llenos";
            return;
        }
        Console.WriteLine("Agregar nota 2");
        Console.WriteLine(Nota.Titulo);
        Console.WriteLine(Nota.Descripcion);
        bool NotaExistente = Notas.Any(n => n.Titulo == Nota.Titulo && n.Descripcion == Nota.Descripcion);
        if (NotaExistente)
        {
            ErrorMensaje = "Esta nota ya existe";
            return;
        }

        Console.WriteLine("Agregar nota 3");
        Console.WriteLine(Nota.Titulo);
        Console.WriteLine(Nota.Descripcion);
        
        Notas.Add(new Notas
        {
            Titulo = Nota.Titulo, 
            Descripcion = Nota.Descripcion
        });
        Nota = new Notas();
        ErrorMensaje = string.Empty;
    }

}