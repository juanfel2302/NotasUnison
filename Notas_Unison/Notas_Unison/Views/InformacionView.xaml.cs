using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace Notas_Unison.Views
{
    public partial class InformacionView : Page
    {
        public InformacionView()
        {
            InitializeComponent();
        }

        private void ColorButton_Click(object sender, RoutedEventArgs e)
        {
            if (sender is Button clickedButton)
            {
                MainGrid.Background = clickedButton.Background;
            }
        }
    }
}