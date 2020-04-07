using System;
using System.Reflection;
using Xamarin.Forms;
using Xunit;

namespace Roster.Client.Tests.Mod04
{
    public class HomeViewModelTests
    {
        private dynamic GetHomeViewModel()
        {
            Assembly assembly = typeof(App).Assembly;
            Type type = assembly.GetType("Roster.Client.ViewModels.HomeViewModel");
            dynamic instance = type != null ? Activator.CreateInstance(type) : default;
            return instance;
        }

        [Fact(DisplayName = "1. Create a new Command and store it in the UpdateApplicationCommand property - @command-new")]
        public void ClassExistsTest()
        {
            dynamic target = GetHomeViewModel();
            Command actual = target.UpdateApplicationCommand;
            Assert.True(
                actual != null,
                "You should use the `HomeViewModel` constructor to create a new instance of the `Command` class, assign an action and save it in the `UpdateApplicationCommand` property."
            );
        }
    }
}