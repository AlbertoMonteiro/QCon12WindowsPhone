using System.Diagnostics.CodeAnalysis;
using GalaSoft.MvvmLight;

namespace QCon12.Mobile.ViewModel
{
    /// <summary>
    ///   This class contains static references to all the view models in the application and provides an entry point for the bindings.
    /// </summary>
    public class ViewModelLocator
    {
        private static MainViewModel _main;

        /// <summary>
        ///   Initializes a new instance of the ViewModelLocator class.
        /// </summary>
        public ViewModelLocator()
        {
            _main = new MainViewModel(ViewModelBase.IsInDesignModeStatic);
        }

        /// <summary>
        ///   Gets the Main property which defines the main viewmodel.
        /// </summary>
        [SuppressMessage("Microsoft.Performance", "CA1822:MarkMembersAsStatic", Justification = "This non-static member is needed for data binding purposes.")]
        public MainViewModel Main
        {
            get { return _main; }
        }
    }
}