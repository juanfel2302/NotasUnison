using System.Windows.Controls;

namespace Notas_Unison.Pages;

public partial class GenericPage : Page
{
    public GenericPage(string content)
    {
        InitializeComponent();
        DynamicText.Text = $"Contenido dinámico: {content}";
    }
}