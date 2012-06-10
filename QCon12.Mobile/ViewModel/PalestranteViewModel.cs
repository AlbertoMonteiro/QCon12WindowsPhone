using System;
using System.Windows.Navigation;
using GalaSoft.MvvmLight;
using QCon12.Mobile.Models;
using QCon12.Mobile.Requests;
using NavigationService = AlbertoMonteiroWP7Tools.Navigation.NavigationService;

namespace QCon12.Mobile.ViewModel
{
    public class PalestranteViewModel : ViewModelBase
    {
        private readonly NavigationService navigationService;
        private int id;

        public PalestranteViewModel(bool isInDesignModeStatic, NavigationService navigationService)
        {
            this.navigationService = navigationService;

            if (isInDesignModeStatic)
                LoadDesignData();
            else
                navigationService.Navigated += Ready;
        }

        public Palestrante Palestrante { get; set; }

        private void Ready(object sender, NavigationEventArgs args)
        {
            if (args.Uri.ToString().Contains("PalestranteView.xaml"))
            {
                id = Convert.ToInt32(navigationService.GetParameter("id", "0"));
                LoadPalestrante();
            }
        }

        private async void LoadPalestrante()
        {
            var palestrantesAzureRequest = new PalestrantesAzureRequest();
            var palestrante = await palestrantesAzureRequest.Get(id);
            Palestrante = palestrante;
        }

        private void LoadDesignData()
        {
            Palestrante = new Palestrante("Elemar Jr", "http://qconsp.com/images/palestrantes/elemar-junior.jpg?1339080693");
        }
    }
}