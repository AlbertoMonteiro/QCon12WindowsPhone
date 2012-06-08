using System.Collections.ObjectModel;
using GalaSoft.MvvmLight;
using QCon12.Phone.Models;
using QCon12.Phone.Requests;

namespace QCon12.Phone.ViewModels
{
    public class MainPageViewModel : ViewModelBase
    {
        public MainPageViewModel(bool b)
        {
            Tracks = new ObservableCollection<Track>();
            Palestrantes = new ObservableCollection<Palestrante>();

            if (b) LoadData();
            else
            {
                Tracks.Add(new Track("Cloud", ""));
                Tracks.Add(new Track("Mobile", ""));
                Tracks.Add(new Track("Start-up", ""));
            }
        }

        public ObservableCollection<Track> Tracks { get; set; }
        public ObservableCollection<Palestra> Palestras { get; set; }
        public ObservableCollection<Palestrante> Palestrantes { get; set; }

        public async void LoadData()
        {
            var tracksAzureRequest = new TracksAzureRequest();
            var tracks = await tracksAzureRequest.List();
            foreach (var item in tracks)
                Tracks.Add(item);

            Palestrantes.Add(new Palestrante("Elemar Jr", "http://qconsp.com/images/palestrantes/elemar-junior.jpg?1339080693"));
            Palestrantes.Add(new Palestrante("Maurício Aniche", "http://qconsp.com/images/palestrantes/mauricio-aniche.jpg?1339080693"));
        }
    }
}