using Roster.Client.ViewModels;
using Xamarin.Forms.Mocks;
using Xunit;

namespace Roster.Client.Tests.Mod04
{
    public class HomeViewModelTests
    {
        [Fact(DisplayName = "You need to create a public class named \"HomeViewModel\" in the \"Roster.Client.ViewModels\" namespace. @class-exists")]
        public void ClassExistsTests()
        {
            MockForms.Init();
            HomeViewModel actual = new HomeViewModel();
            Assert.NotNull(actual);
        }
    }
}