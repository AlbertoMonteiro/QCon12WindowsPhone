using System.Diagnostics.CodeAnalysis;
using AlbertoMonteiroWP7Tools.Navigation;
using GalaSoft.MvvmLight;

namespace QCon12.Mobile.ViewModel
{
    public class ViewModelLocator
    {
        private static MainViewModel _main;
        private static TrackViewModel _track;
        private static readonly NavigationService navigationService;
        private static PalestranteViewModel _palestrante;

        static ViewModelLocator()
        {
            navigationService = new NavigationService();
        }

        public ViewModelLocator()
        {
            _main = new MainViewModel(ViewModelBase.IsInDesignModeStatic, navigationService);
            _track = new TrackViewModel(ViewModelBase.IsInDesignModeStatic, navigationService);
            _palestrante = new PalestranteViewModel(ViewModelBase.IsInDesignModeStatic, navigationService);
        }

        [SuppressMessage("Microsoft.Performance", "CA1822:MarkMembersAsStatic", Justification = "This non-static member is needed for data binding purposes.")]
        public MainViewModel Main
        {
            get { return _main; }
        }

        [SuppressMessage("Microsoft.Performance", "CA1822:MarkMembersAsStatic", Justification = "This non-static member is needed for data binding purposes.")]
        public TrackViewModel Track
        {
            get { return _track; }
        }

        [SuppressMessage("Microsoft.Performance", "CA1822:MarkMembersAsStatic", Justification = "This non-static member is needed for data binding purposes.")]
        public PalestranteViewModel Palestrante
        {
            get { return _palestrante; }
        }
    }
}