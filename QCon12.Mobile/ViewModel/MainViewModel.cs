using System.Collections.ObjectModel;
using GalaSoft.MvvmLight;
using QCon12.Mobile.Models;
using QCon12.Mobile.Requests;

namespace QCon12.Mobile.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        public ObservableCollection<Track> Tracks { get; set; }
        public ObservableCollection<Palestra> Palestras { get; set; }
        public ObservableCollection<Palestrante> Palestrantes { get; set; }

        public MainViewModel(bool isInDesignModeStatic)
        {
            Tracks = new ObservableCollection<Track>();
            Palestrantes = new ObservableCollection<Palestrante>();
            Palestras = new ObservableCollection<Palestra>();

            if (isInDesignModeStatic)
            {
                Tracks.Add(new Track("O que eu sempre quiz fazer mas nunca fiz", "Teste 2"));
                Tracks.Add(new Track("Teste", "Teste"));
                Tracks.Add(new Track("Arquitetura na cloud", "Teste 1"));
            } else
            {
                LoadData();
            }
        }

        private async void LoadData()
        {
            var tracksRequest = new TracksAzureRequest();
            var tracks = await tracksRequest.List();
            foreach (var track in tracks)
                Tracks.Add(track);
        }
    }
}