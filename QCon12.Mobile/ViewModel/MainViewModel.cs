using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using AlbertoMonteiroWP7Tools.Navigation;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using QCon12.Mobile.Models;
using QCon12.Mobile.Requests;

namespace QCon12.Mobile.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        private bool canLoadPalestrantes = true;

        public MainViewModel(bool isInDesignModeStatic, NavigationService navigationService)
        {
            Tracks = new ObservableCollection<Track>();
            Palestrantes = new ObservableCollection<Palestrante>();
            Palestras = new ObservableCollection<Palestra>();

            if (isInDesignModeStatic)
                LoadDesignData();
            else
            {
                LoadTracks().Wait();
                LoadPalestrantes().Wait();
                LoadPalestras();
            }

            TrackSelected = new RelayCommand<Track>(track => navigationService.NavigateTo(string.Format("/TrackView.xaml?id={0}", track.Id)));
            PalestranteSelected = new RelayCommand<Palestrante>(palestrante => navigationService.NavigateTo(string.Format("/ViewPalestrante.xaml?id={0}", palestrante.Id)));
            MaisPalestrante = new RelayCommand(() => LoadPalestrantes());
        }

        public ObservableCollection<Track> Tracks { get; set; }
        public ObservableCollection<Palestra> Palestras { get; set; }
        public ObservableCollection<Palestrante> Palestrantes { get; set; }
        public RelayCommand<Track> TrackSelected { get; set; }
        public RelayCommand<Palestrante> PalestranteSelected { get; set; }
        public RelayCommand MaisPalestrante { get; set; }

        private void LoadDesignData()
        {
            Tracks.Add(new Track("O que eu sempre quiz fazer mas nunca fiz", "Teste 2 Teste 2 Teste 2 Teste 2 Teste 2\n Teste 2 Teste 2 Teste 2 Teste 2  Teste 2 Teste 2 Teste 2 Teste 2  Teste 2 Teste 2 Teste 2 Teste 2 "));
            Tracks.Add(new Track("Teste", "Teste"));
            Tracks.Add(new Track("Arquitetura na cloud", "Teste 1"));

            Palestrantes.Add(new Palestrante("Elemar Jr", "http://qconsp.com/images/palestrantes/elemar-junior.jpg?1339080693"));

            Palestras.Add(new Palestra
            {
                Descricao = "Conteudo da palestra 1 que fala sobre alguma coisa que eu não sei mais o que escrever aqui",
                Horario = new DateTime(2012, 08, 4, 12, 00, 00),
                Nome = "Palestra 1",
                Track = Tracks.First()
            });

            Palestras.Add(new Palestra
            {
                Descricao = "Conteudo da palestra 2 que fala sobre alguma coisa que eu não sei mais o que escrever aqui",
                Horario = new DateTime(2012, 8, 5, 15, 00, 00),
                Nome = "Palestra 2",
                Track = Tracks.Last()
            });
        }

        private Task LoadTracks()
        {
            var tracksRequest = new TracksRequest();
            return tracksRequest.List().ContinueWith(task =>
            {
                if (task.Result != null)
                    foreach (var track in task.Result)
                        Tracks.Add(track);    
            });
            
        }

        private Task LoadPalestrantes()
        {
            if (canLoadPalestrantes)
            {
                canLoadPalestrantes = false;
                var palestrantesRequest = new PalestrantesRequest();
                return palestrantesRequest.List(Palestrantes.Count).ContinueWith(task =>
                {
                    if (task.Result != null)
                        foreach (var palestrante in task.Result)
                            Palestrantes.Add(palestrante);
                    canLoadPalestrantes = true;    
                });
            }
            return null;
        }

        private Task LoadPalestras()
        {
            var palestrasAzureRequest = new PalestrasRequest();
            return palestrasAzureRequest.List().ContinueWith(task =>
            {
                if (task.Result != null)
                    foreach (var palestra in task.Result)
                        Palestras.Add(palestra);
            });
        }
    }
}