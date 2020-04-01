using Roster.Client.Views;
using Xamarin.Forms;

namespace Roster.Client
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            MainPage = new HomeView();
        }
    }
}