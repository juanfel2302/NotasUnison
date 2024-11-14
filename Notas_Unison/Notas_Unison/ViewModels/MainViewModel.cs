using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Notas_Unison.Services;
using Notas_Unison.Views;
using System.Windows.Controls;
using Wpf.Ui;

namespace Notas_Unison.ViewModels
{
    public partial class MainViewModel : ObservableObject
    {
        private readonly IPageService _pageService;
        private readonly Frame _navigationFrame;

        public MainViewModel(IPageService pageService, Frame navigationFrame)
        {
            _pageService = pageService;
            _navigationFrame = navigationFrame;
            NavigateToInicioCommand = new RelayCommand(NavigateToInicio);
        }

        public IRelayCommand NavigateToInicioCommand { get; }

        private void NavigateToInicio()
        {
            // Obtener la página InicioView usando el servicio
            var inicioPage = _pageService.GetPage<InicioView>();
            if (inicioPage != null)
            {
                // Navegar a InicioView en el frame de navegación
                _navigationFrame.Navigate(inicioPage);
            }
        }
    }
}