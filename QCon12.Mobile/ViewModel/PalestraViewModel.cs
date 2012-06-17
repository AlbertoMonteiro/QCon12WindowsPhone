using System;
using System.Windows.Navigation;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using Microsoft.Phone.Scheduler;
using QCon12.Mobile.Models;
using QCon12.Mobile.Requests;
using NavigationService = AlbertoMonteiroWP7Tools.Navigation.NavigationService;

namespace QCon12.Mobile.ViewModel
{
    public class PalestraViewModel : ViewModelBase
    {
        private readonly NavigationService navigationService;
        private int id;

        public PalestraViewModel(bool isInDesignModeStatic, NavigationService navigationService)
        {
            this.navigationService = navigationService;

            if (isInDesignModeStatic)
                LoadDesignData();
            else
                navigationService.Navigated += Ready;

            Agendar = new RelayCommand(() =>
            {
                var uri = new Uri(string.Format("/PalestraView.xaml?id={0}", id), UriKind.Relative);
                var reminder = new Reminder(Palestra.Nome)
                {
                    Title = Palestra.Nome,
                    Content = "Se liga que a palestra jaja vai começar",
                    BeginTime = Palestra.Horario.Subtract(TimeSpan.FromMinutes(10)),
                    RecurrenceType = RecurrenceInterval.None,
                    NavigationUri = uri
                };
                ScheduledActionService.Add(reminder);
            });
        }

        public Palestra Palestra { get; set; }
        public RelayCommand Agendar { get; set; }

        private void LoadDesignData()
        {
            Palestra = new Palestra()
            {
                Nome = "Software Design no século 21",
                Descricao = @"In the last decade or so we've seen a number of new ideas added to the mix to help us effectively design our software. Patterns help us capture the solutions and rationale for using them. Refactoring allows us to alter the design of a system after the code is written. Agile methods, in particular Extreme Programming, give us a highly iterative and evolutionary approach which is particularly well suited to changing requirements and environments. Martin Fowler has been a leading voice in these techniques and will give a suite of short talks featuring various aspects about his recent thinking about how these and other developments affect our software development.",
                Horario = DateTime.Parse("8/4/2012 9:00 AM"),
                Id = 1
            };
        }

        public void Ready(object sender, NavigationEventArgs args)
        {
            if (args.Uri.ToString().Contains("PalestraView.xaml"))
            {
                id = Convert.ToInt32(navigationService.GetParameter("id", "0"));
                LoadPalestra(id);
            }
        }

        public async void LoadPalestra(int tempId)
        {
            var request = new PalestrasRequest();
            Palestra = await request.Get(tempId);
        }
    }
}