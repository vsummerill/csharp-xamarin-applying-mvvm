using System.ComponentModel;
using Xamarin.Forms;

namespace Roster.Client.ViewModels
{
    public class HomeViewModel : INotifyPropertyChanged
    {
        private string _title = "Roster App";

        public event PropertyChangedEventHandler PropertyChanged;

        public string Title
        {
            get => _title;
            set
            {
                _title = value;
                PropertyChanged(this, new PropertyChangedEventArgs("title"));
            }
        }

        public Command UpdateApplicationCommand { get; }

        public HomeViewModel()
        {
            UpdateApplicationCommand = new Command(UpdateApplicationCommandExecute);
        }

        private void UpdateApplicationCommandExecute()
        {
            Title = "Roster App (v2.0)";
        }
    }
}
