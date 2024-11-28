using System.Collections.ObjectModel;
using System.Windows.Input;
using System.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Notas_Unison_Core.Modelos;
using Wpf.Ui.Input;

namespace Notas_Unison.ViewModels;


public class NotaViewModel : INotifyPropertyChanged
{
    public ObservableCollection<Nota> Notas { get; set; }
    private Nota _selectedNote;

    public Nota SelectedNote
    {
        get { return _selectedNote; }
        set
        {
            _selectedNote = value;
            OnPropertyChanged(nameof(SelectedNote));
        }
    }

    public ICommand AddNotaCommand { get; set; }
    public ICommand SaveNotaCommand { get; set; }

    public NotaViewModel()
    {
        Notas = new ObservableCollection<Nota>();
        AddNotaCommand = new RelayCommand(AddNota);
        SaveNotaCommand = new RelayCommand(GuardarNota);
    }

    private void AddNota()
    {
        var newNota = new Nota { Titulo = "Nueva Nota", Contenido = "Contenido...", Colorin = "#F0C1E1"};
        Notas.Add(newNota);
        SelectedNote = newNota; // Seleccionar la nueva nota
    }

    private void GuardarNota()
    {
        // Aquí se implementaría la lógica para guardar las notas en el backend
        // Puedes llamar a un servicio que maneje la persistencia
    }

    public event PropertyChangedEventHandler PropertyChanged;

    protected void OnPropertyChanged(string propertyName)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
