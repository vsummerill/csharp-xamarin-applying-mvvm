using System;
using System.ComponentModel;
using System.Reflection;
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
            Assembly assembly = typeof(App).Assembly;
            Type target = assembly.GetType("Roster.Client.ViewModels.HomeViewModel");
            var actual = Activator.CreateInstance(target);
            Assert.NotNull(actual);
        }

        [Fact(DisplayName = "Your \"HomeViewModel\" class should implement the \"System.ComponentModel.INotifyPropertyChanged\" interface. @class-implements-inotifypropertychanged-interface")]
        public void ClassImplementsInterfaceTest()
        {
            MockForms.Init();
            Assembly assembly = typeof(App).Assembly;
            Type target = assembly.GetType("Roster.Client.ViewModels.HomeViewModel");
            var actual = Activator.CreateInstance(target);
            Assert.NotNull(actual);
            Assert.IsAssignableFrom<INotifyPropertyChanged>(actual);
        }
    }
}