using Roster.Client.ViewModels;
using Xamarin.Forms;

namespace Roster.Client.Views
{
    [System.ComponentModel.DesignTimeVisible(false)]
    public partial class HomeView : ContentPage
    {
        public HomeView()
        {
            InitializeComponent();

            BindingContext = new HomeViewModel();

        }
    }
}