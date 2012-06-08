using System.Diagnostics.CodeAnalysis;
using GalaSoft.MvvmLight;
using QCon12.Phone.Models;
using QCon12.Phone.ViewModels;

namespace QCon12.Phone.ViewModel
{
    /// <summary>
    ///   This class contains static references to all the view models in the application and provides an entry point for the bindings.
    /// </summary>
    public class ViewModelLocator
    {
        private static MainPageViewModel _main;

        /// <summary>
        ///   Initializes a new instance of the ViewModelLocator class.
        /// </summary>
        public ViewModelLocator()
        {
            if (ViewModelBase.IsInDesignModeStatic)
            {
                _main = new MainPageViewModel(false);
            }
            else
            {
                _main = new MainPageViewModel(true);
            }

            
        }

        /// <summary>
        ///   Gets the Main property which defines the main viewmodel.
        /// </summary>
        [SuppressMessage("Microsoft.Performance", "CA1822:MarkMembersAsStatic", Justification = "This non-static member is needed for data binding purposes.")]
        public MainPageViewModel Main
        {
            get { return _main; }
        }
    }
}