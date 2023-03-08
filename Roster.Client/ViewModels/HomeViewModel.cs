using System.ComponentModel;
using Xamarin.Forms;

namespace Roster.Client.ViewModels
{
    public class HomeViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public string Title { get; set; } = "Roster App";

        public Command UpdateApplicationCommand { get; }

    }
}
