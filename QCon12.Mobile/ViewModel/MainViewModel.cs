using System;
using System.Collections.ObjectModel;
using System.Linq;
using AlbertoMonteiroWP7Tools.Navigation;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using QCon12.Mobile.Models;
using QCon12.Mobile.Requests;

namespace QCon12.Mobile.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        public MainViewModel(bool isInDesignModeStatic, NavigationService navigationService)
        {
            Tracks = new ObservableCollection<Track>();
            Palestrantes = new ObservableCollection<Palestrante>();
            Palestras = new ObservableCollection<Palestra>();

            if (isInDesignModeStatic)
                LoadDesignData();
            else
            {
                LoadTracks();
                LoadPalestrantes();
                LoadPalestras();
            }

            TrackSelected = new RelayCommand<Track>(track => navigationService.NavigateTo(string.Format("/TrackView.xaml?id={0}", track.Id)));
            PalestranteSelected = new RelayCommand<Palestrante>(palestrante => navigationService.NavigateTo(string.Format("/PalestranteView.xaml?id={0}", palestrante.Id)));
        }

        public ObservableCollection<Track> Tracks { get; set; }
        public ObservableCollection<Palestra> Palestras { get; set; }
        public ObservableCollection<Palestrante> Palestrantes { get; set; }
        public RelayCommand<Track> TrackSelected { get; set; }
        public RelayCommand<Palestrante> PalestranteSelected { get; set; }

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
                Palestrante = Palestrantes.First(),
                Track = Tracks.First()
            });

            Palestras.Add(new Palestra
            {
                Descricao = "Conteudo da palestra 2 que fala sobre alguma coisa que eu não sei mais o que escrever aqui",
                Horario = new DateTime(2012, 8, 5, 15, 00, 00),
                Nome = "Palestra 2",
                Palestrante = Palestrantes.First(),
                Track = Tracks.Last()
            });
        }

        private async void LoadTracks()
        {
            var tracksRequest = new TracksRequest();
            var tracks = await tracksRequest.List();
            foreach (var track in tracks)
                Tracks.Add(track);
        }

        private async void LoadPalestrantes()
        {
            var palestrantesRequest = new PalestrantesRequest();
            var palestrantes = await palestrantesRequest.List();
            foreach (var palestrante in palestrantes)
                Palestrantes.Add(palestrante);
        }

        private async void LoadPalestras()
        {
            var palestrasAzureRequest = new PalestrasRequest();
            var palestras = await palestrasAzureRequest.List();
            foreach (var palestra in palestras)
                Palestras.Add(palestra);
        }
    }
}