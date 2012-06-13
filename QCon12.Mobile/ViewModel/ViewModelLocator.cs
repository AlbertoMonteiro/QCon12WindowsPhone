using System.Diagnostics.CodeAnalysis;
using AlbertoMonteiroWP7Tools.Navigation;
using GalaSoft.MvvmLight;

namespace QCon12.Mobile.ViewModel
{
    public class ViewModelLocator
    {
        private static readonly NavigationService navigationService;
        private static MainViewModel main;
        private static TrackViewModel track;
        private static PalestranteViewModel palestrante;

        static ViewModelLocator()
        {
            navigationService = new NavigationService();
            main = new MainViewModel(ViewModelBase.IsInDesignModeStatic, navigationService);
            track = new TrackViewModel(ViewModelBase.IsInDesignModeStatic, navigationService);
            palestrante = new PalestranteViewModel(ViewModelBase.IsInDesignModeStatic, navigationService);
        }

        [SuppressMessage("Microsoft.Performance", "CA1822:MarkMembersAsStatic", Justification = "This non-static member is needed for data binding purposes.")]
        public MainViewModel Main { get { return main; } }

        [SuppressMessage("Microsoft.Performance", "CA1822:MarkMembersAsStatic", Justification = "This non-static member is needed for data binding purposes.")]
        public TrackViewModel Track { get { return track; } }

        [SuppressMessage("Microsoft.Performance", "CA1822:MarkMembersAsStatic", Justification = "This non-static member is needed for data binding purposes.")]
        public PalestranteViewModel Palestrante { get { return palestrante; } }
    }
}