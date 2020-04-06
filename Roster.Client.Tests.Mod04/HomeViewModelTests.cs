using System;
using System.Reflection;
using Xamarin.Forms;
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
            Assembly assembly = typeof(App).Assembly;
            Type target = assembly.GetType("Roster.Client.ViewModels.HomeViewModel");
            dynamic subtarget = target != null ? Activator.CreateInstance(target) : default;
            Command actual = subtarget.UpdateApplicationCommand;
            Assert.True(
                actual != null,
                "You should use the \"HomeViewModel\" constructor to create a new instance of the \"Command\" class, assign an action and save it in the \"UpdateApplicationCommand\" property."
            );
        }
    }
}