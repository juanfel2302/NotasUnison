using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using Notas_Unison_Core.BaseDeDatos;
using Notas_Unison_Core.Models;

namespace Notas_Unison.ViewModels
{
    public partial class InicioViewModel : ObservableObject
    {
        public ObservableCollection<Notas> Notas { get; } = new();

        public InicioViewModel()
        {
            CargarNotas();
        }

        private void CargarNotas()
        {
            // Ejemplo de carga inicial. Aquí deberías consultar la base de datos para obtener las notas.
            Notas.Add(new Notas { Titulo = "Nota 1", Descripcion = "Descripción de la nota 1" });
            Notas.Add(new Notas { Titulo = "Nota 2", Descripcion = "Descripción de la nota 2" });
        }

        public void AgregarNota(Notas nota)
        {
            Notas.Add(nota);
        }
    }
}