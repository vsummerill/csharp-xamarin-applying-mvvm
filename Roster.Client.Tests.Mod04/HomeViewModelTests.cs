using Roster.Client.ViewModels;
using System.ComponentModel;
using Xamarin.Forms.Mocks;
using Xunit;

namespace Roster.Client.Tests.Mod04
{
    public class HomeViewModelTests
    {
        [Fact(DisplayName = "You need to create a public class named \"HomeViewModel\" in the \"Roster.Client.ViewModels\" namespace. @class-exists")]
        public void ClassExistsTest()
        {
            MockForms.Init();
            HomeViewModel actual = new HomeViewModel();
            Assert.NotNull(actual);
        }

        [Fact(DisplayName = "Your \"HomeViewModel\" class should implement the \"System.ComponentModel.INotifyPropertyChanged\" interface. @class-implements-inotifypropertychanged-interface")]
        public void ClassImplementsInterfaceTest()
        {

            MockForms.Init();
            HomeViewModel actual = new HomeViewModel();
            Assert.NotNull(actual);
            Assert.IsAssignableFrom<INotifyPropertyChanged>(actual);
        }
    }
}