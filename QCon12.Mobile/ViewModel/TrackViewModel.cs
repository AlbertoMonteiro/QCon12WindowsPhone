using System;
using System.Collections.ObjectModel;
using System.Windows.Navigation;
using GalaSoft.MvvmLight;
using QCon12.Mobile.Models;
using QCon12.Mobile.Requests;
using NavigationService = AlbertoMonteiroWP7Tools.Navigation.NavigationService;

namespace QCon12.Mobile.ViewModel
{
    public class TrackViewModel : ViewModelBase
    {
        private readonly NavigationService navigationService;
        private int id;

        public TrackViewModel(bool isInDesignModeStatic, NavigationService navigationService)
        {
            this.navigationService = navigationService;

            Palestras = new ObservableCollection<Palestra>();

            if (!isInDesignModeStatic)
            {
                navigationService.Navigated += Ready;
                navigationService.Navigating += GoOut;
            }
        }

        public Track Track { get; set; }
        public ObservableCollection<Palestra> Palestras { get; set; }

        private void GoOut(object sender, NavigatingCancelEventArgs e)
        {
            if (e.NavigationMode == NavigationMode.Back)
                Palestras.Clear();
        }

        private void Ready(object sender, NavigationEventArgs args)
        {
            //Palestras.Clear();
            if (args.Uri.ToString().Contains("TrackView.xaml"))
            {
                id = Convert.ToInt32(navigationService.GetParameter("id", "0"));
                LoadTrack();
            }
        }

        private async void LoadTrack()
        {
            var trackService = new TracksRequest();
            var track = await trackService.Get(id);
            if (track != null)
            {
                Track = track;
                LoadPalestras();
            }
        }

        private async void LoadPalestras()
        {
            var palestrasRequest = new PalestrasRequest();
            var palestras = await palestrasRequest.FromTrack(Track.Id);
            if (palestras != null)
                foreach (var palestra in palestras)
                    Palestras.Add(palestra);
        }
    }
}