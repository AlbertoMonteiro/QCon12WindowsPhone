using System;
using Microsoft.Phone.Controls;
using QCon12.Mobile.Cache;

namespace QCon12.Mobile
{
    public partial class MainPage : PhoneApplicationPage
    {
        public MainPage()
        {
            InitializeComponent();
            var cacheContext = new CacheContext();
            foreach (var palestra in cacheContext.Tracks)
            {
                Console.WriteLine(palestra);
            }
        }
    }
}