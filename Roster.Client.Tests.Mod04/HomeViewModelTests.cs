using Roster.Client.ViewModels;
using Xamarin.Forms.Mocks;
using Xunit;

namespace Roster.Client.Tests.Mod04
{
    public class HomeViewModelTests
    {
        [Fact(DisplayName = "1. Create a new Command and store it in the UpdateApplicationCommand property - @command-new")]
        public void ClassExistsTest()
        {
            MockForms.Init();
            HomeViewModel target = new HomeViewModel();
            var actual = target.UpdateApplicationCommand;
            Assert.True(
                actual != null,
                "You should use the \"HomeViewModel\" constructor to create a new instance of the \"Command\" class, assign an action and save it in the \"UpdateApplicationCommand\" property."
            );
        }
    }
}