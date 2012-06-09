using System;
using System.Collections.ObjectModel;
using GalaSoft.MvvmLight;
using QCon12.Mobile.Models;
using QCon12.Mobile.Requests;
using System.Linq;

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
                Tracks.Add(new Track("O que eu sempre quiz fazer mas nunca fiz", "Teste 2 Teste 2 Teste 2 Teste 2 Teste 2\n Teste 2 Teste 2 Teste 2 Teste 2  Teste 2 Teste 2 Teste 2 Teste 2  Teste 2 Teste 2 Teste 2 Teste 2 "));
                Tracks.Add(new Track("Teste", "Teste"));
                Tracks.Add(new Track("Arquitetura na cloud", "Teste 1"));

                Palestrantes.Add(new Palestrante("Elemar Jr", "http://qconsp.com/images/palestrantes/elemar-junior.jpg?1339080693"));

                Palestras.Add(new Palestra
                {
                    Descricao = "Conteudo da palestra 1 que fala sobre alguma coisa que eu n�o sei mais o que escrever aqui",
                    Horario = new DateTime(2012,08,4,12,00,00),
                    Nome = "Palestra 1",
                    Palestrante = Palestrantes.First(),
                    Track = Tracks.First()
                });
                
                Palestras.Add(new Palestra
                {
                    Descricao = "Conteudo da palestra 2 que fala sobre alguma coisa que eu n�o sei mais o que escrever aqui",
                    Horario = new DateTime(2012,8,5,15,00,00),
                    Nome = "Palestra 2",
                    Palestrante = Palestrantes.First(),
                    Track = Tracks.Last()
                });
            } else
            {
                LoadTracks();
                LoadPalestrantes();
            }
        }

        private async void LoadTracks()
        {
            var tracksRequest = new TracksAzureRequest();
            var tracks = await tracksRequest.List();
            foreach (var track in tracks)
                Tracks.Add(track);
        }

        private async void LoadPalestrantes()
        {
            var palestrantesRequest = new PalestrantesAzureRequest();
            var palestrantes = await palestrantesRequest.List();
            foreach (var palestrante in palestrantes)
                Palestrantes.Add(palestrante);
        }
    }
}