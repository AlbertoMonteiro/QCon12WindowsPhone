using System;
using System.Collections.ObjectModel;
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
            UltimosTweets = new ObservableCollection<Tweet>();
            this.navigationService = navigationService;

            if (isInDesignModeStatic)
                LoadDesignData();
            else
                navigationService.Navigated += Ready;
        }

        public Palestrante Palestrante { get; set; }
        public ObservableCollection<Tweet> UltimosTweets { get; set; }

        private void Ready(object sender, NavigationEventArgs args)
        {
            if (args.Uri.ToString().Contains("ViewPalestrante.xaml"))
            {
                id = Convert.ToInt32(navigationService.GetParameter("id", "0"));
                LoadPalestrante();
            }
        }

        private async void LoadTweets()
        {
            var tweetRequest = new TweetRequest(Palestrante.Twitter);
            var tweets = await tweetRequest.List();
            if (tweets != null)
            {
                UltimosTweets.Clear();
                foreach (var tweet in tweets)
                    UltimosTweets.Add(tweet);
            }
        }

        private async void LoadPalestrante()
        {
            var palestrantesRequest = new PalestrantesRequest();
            var palestrante = await palestrantesRequest.Get(id);
            if (palestrante != null)
            {
                Palestrante = palestrante;
                LoadTweets();
            }
        }

        private void LoadDesignData()
        {
            Palestrante = new Palestrante("Elemar Jr", "http://qconsp.com/images/palestrantes/elemar-junior.jpg?1339080693")
            {
                Bio = @"Elemar Júnior. Gerente de Pesquisa e Desenvolvimento na Promob. Na empresa há 14 anos. Desenvolve usando tecnologias Microsoft desde sua infância. Utiliza .net desde sua primeira versão. Em 2012, foi reconhecido como Microsoft MVP em C#. Especialista em computação gráfica, CAD e CAM.",
                Twitter = "elemarjr",
                Id = 1
            };

            UltimosTweets.Add(new Tweet()
            {
                created_at = DateTime.Now,
                source = "here",
                text = "Passamos de 100.000 downloads na google play com o app Dieta e Saúde… no itunnes já passamos de 700.00 #rocks"
            });
        }
    }
}