using System.Collections.ObjectModel;
using Caliburn.Micro;
using QCon12.Phone.Models;

namespace QCon12.Phone.ViewModels
{
    public class MainPageViewModel : Screen
    {
        public MainPageViewModel()
        {
            Tracks = new ObservableCollection<Track>();
            Palestrantes = new ObservableCollection<Palestrante>();
            LoadData();
        }

        public ObservableCollection<Track> Tracks { get; set; }
        public ObservableCollection<Palestra> Palestras { get; set; }
        public ObservableCollection<Palestrante> Palestrantes { get; set; }

        public string SampleProperty { get; set; }

        public void LoadData()
        {
            Tracks.Add(new Track("Cloud", ""));
            Tracks.Add(new Track("Mobile", ""));
            Tracks.Add(new Track("Start-up", ""));


            Palestrantes.Add(new Palestrante("Elemar Jr", "http://qconsp.com/images/palestrantes/elemar-junior.jpg?1339080693"));
            Palestrantes.Add(new Palestrante("Maurício Aniche", "http://qconsp.com/images/palestrantes/mauricio-aniche.jpg?1339080693"));
        }
    }
}