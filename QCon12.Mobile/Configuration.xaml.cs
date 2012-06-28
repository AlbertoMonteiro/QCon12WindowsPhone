using System.Windows;
using Microsoft.Phone.Controls;
using QCon12.Mobile.Cache;

namespace QCon12.Mobile
{
    public partial class Configuration : PhoneApplicationPage
    {
        public Configuration()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var cacheContext = new CacheContext();

            cacheContext.DeleteDatabase();
            cacheContext.CreateDatabase();
        }
    }
}