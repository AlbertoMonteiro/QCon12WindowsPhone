using System.Diagnostics.CodeAnalysis;
using AlbertoMonteiroWP7Tools.Navigation;
using GalaSoft.MvvmLight;

namespace QCon12.Mobile.ViewModel
{
    public class ViewModelLocator
    {
        private static readonly NavigationService navigationService;

        static ViewModelLocator()
        {
            navigationService = new NavigationService();
            Main = new MainViewModel(ViewModelBase.IsInDesignModeStatic, navigationService);
            Track = new TrackViewModel(ViewModelBase.IsInDesignModeStatic, navigationService);
            Palestrante = new PalestranteViewModel(ViewModelBase.IsInDesignModeStatic, navigationService);
            Palestra = new PalestraViewModel(ViewModelBase.IsInDesignModeStatic, navigationService);
        }

        [SuppressMessage("Microsoft.Performance", "CA1822:MarkMembersAsStatic", Justification = "This non-static member is needed for data binding purposes.")]
        public static MainViewModel Main { get; private set; }

        [SuppressMessage("Microsoft.Performance", "CA1822:MarkMembersAsStatic", Justification = "This non-static member is needed for data binding purposes.")]
        public static TrackViewModel Track { get; private set; }

        [SuppressMessage("Microsoft.Performance", "CA1822:MarkMembersAsStatic", Justification = "This non-static member is needed for data binding purposes.")]
        public static PalestranteViewModel Palestrante { get; private set; }

        [SuppressMessage("Microsoft.Performance", "CA1822:MarkMembersAsStatic", Justification = "This non-static member is needed for data binding purposes.")]
        public static PalestraViewModel Palestra { get; private set; }
    }
}