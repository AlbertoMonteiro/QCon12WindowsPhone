using QCon12.Phone.ViewModels;

namespace QCon12.Phone
{
    public partial class MainPage
    {
        public MainPage()
        {
            InitializeComponent();

            Loaded += (sender, args) => { DataContext = new MainPageViewModel(); };
        }
    }
}