using System;
using Microsoft.Phone.Controls;

namespace QCon12.Mobile
{
    public partial class MainPage : PhoneApplicationPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void ApplicationBarMenuItem_Click(object sender, EventArgs e)
        {
            NavigationService.Navigate(new Uri("/Configuration.xaml", UriKind.RelativeOrAbsolute));
        }
    }
}