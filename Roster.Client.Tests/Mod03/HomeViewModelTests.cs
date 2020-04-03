using Xamarin.Forms.Mocks;
using Xunit;

namespace Roster.Client.Tests
{
    public class HomeViewModelTests
    {
        [Fact(DisplayName = "Checking if this works. @check")]
        public void FailTest()
        {
            MockForms.Init();
            Assert.True(false);
        }
    }
}