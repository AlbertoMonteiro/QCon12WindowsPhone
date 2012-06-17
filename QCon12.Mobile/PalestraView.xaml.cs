using System;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using QCon12.Mobile.ViewModel;

namespace QCon12_Mobile
{
    public partial class PalestraView : PhoneApplicationPage
    {
        public PalestraView()
        {
            InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);

            if (!e.IsNavigationInitiator)
            {
                var palestraViewModel = new PalestraViewModel(false, null);
                var id = NavigationContext.QueryString["id"];
                palestraViewModel.LoadPalestra(Convert.ToInt32(id));
                DataContext = palestraViewModel;
            }
        }
    }
}