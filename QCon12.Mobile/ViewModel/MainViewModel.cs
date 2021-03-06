using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading;
using System.Windows.Controls;
using AlbertoMonteiroWP7Tools.Navigation;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using Microsoft.Phone.Controls;
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
                LoadTracks();

            TrackSelected = new RelayCommand<Track>(track => navigationService.NavigateTo(string.Format("/TrackView.xaml?id={0}", track.Id)));
            PalestranteSelected = new RelayCommand<Palestrante>(palestrante => navigationService.NavigateTo(string.Format("/ViewPalestrante.xaml?id={0}", palestrante.Id)));
            PalestraSelected = new RelayCommand<Palestra>(palestra => navigationService.NavigateTo(string.Format("/PalestraView.xaml?id={0}", palestra.Id)));
            MaisPalestrante = new RelayCommand(LoadPalestrantes);
            PanoramaChangedCommand = new RelayCommand<SelectionChangedEventArgs>(PanoramaChanged);
        }

        public ObservableCollection<Track> Tracks { get; set; }
        public ObservableCollection<Palestra> Palestras { get; set; }
        public ObservableCollection<Palestrante> Palestrantes { get; set; }
        public RelayCommand<Track> TrackSelected { get; set; }
        public RelayCommand<Palestrante> PalestranteSelected { get; set; }
        public RelayCommand<Palestra> PalestraSelected { get; set; }
        public RelayCommand MaisPalestrante { get; set; }
        public RelayCommand<SelectionChangedEventArgs> PanoramaChangedCommand { get; set; }

        private void LoadDesignData()
        {
            Tracks.Add(new Track("O que eu sempre quiz fazer mas nunca fiz", "Teste 2 Teste 2 Teste 2 Teste 2 Teste 2\n Teste 2 Teste 2 Teste 2 Teste 2  Teste 2 Teste 2 Teste 2 Teste 2  Teste 2 Teste 2 Teste 2 Teste 2 "));
            Tracks.Add(new Track("Teste", "Teste"));
            Tracks.Add(new Track("Arquitetura na cloud", "Teste 1"));

            Palestrantes.Add(new Palestrante("Elemar Jr", "http://qconsp.com/images/palestrantes/elemar-junior.jpg?1339080693"));

            Palestras.Add(new Palestra
            {
                Descricao = "Conteudo da palestra 1 que fala sobre alguma coisa que eu n�o sei mais o que escrever aqui",
                Horario = new DateTime(2012, 08, 4, 12, 00, 00),
                Nome = "Palestra 1",
                Track = Tracks.First()
            });

            Palestras.Add(new Palestra
            {
                Descricao = "Conteudo da palestra 2 que fala sobre alguma coisa que eu n�o sei mais o que escrever aqui",
                Horario = new DateTime(2012, 8, 5, 15, 00, 00),
                Nome = "Palestra 2",
                Track = Tracks.Last()
            });
        }

        private async void LoadTracks()
        {
            var tracksRequest = new TracksRequest();
            var tracks = await tracksRequest.List();
            if (tracks != null)
                foreach (var track in tracks)
                    Tracks.Add(track);
        }

        private async void LoadPalestrantes()
        {
            if (!canLoadPalestrantes) return;

            canLoadPalestrantes = false;
            var palestrantesRequest = new PalestrantesRequest();
            var palestrantes = await palestrantesRequest.List(Palestrantes.Count);
            if (palestrantes != null)
                foreach (var palestrante in palestrantes)
                    Palestrantes.Add(palestrante);
            canLoadPalestrantes = true;
        }

        private async void LoadPalestras()
        {
            var palestrasRequest = new PalestrasRequest();
            var palestras = await palestrasRequest.List();
            SynchronizationContext.Current.Post(state =>
            {
                if (palestras != null)
                    foreach (var palestra in palestras)
                        Palestras.Add(palestra);
            }, null);
        }

        private void PanoramaChanged(SelectionChangedEventArgs args)
        {
            var header = ((PanoramaItem) args.AddedItems[0]).Header.ToString();
            switch (header)
            {
            case "Tracks":
                if (!Tracks.Any()) LoadTracks();
                break;
            case "Palestrantes":
                if (!Palestrantes.Any()) LoadPalestrantes();
                break;
            case "Palestras":
                if (!Palestras.Any()) LoadPalestras();
                break;
            }
        }
    }
}