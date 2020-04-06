using System;
using System.ComponentModel;
using System.Reflection;
using Xamarin.Forms.Mocks;
using Xunit;

namespace Roster.Client.Tests.Mod04
{
    public class HomeViewModelTests
    {
        [Fact(DisplayName = "1. Create a HomeViewModel class - @class-exists")]
        public void ClassExistsTest()
        {
            MockForms.Init();
            Assembly assembly = typeof(App).Assembly;
            Type target = assembly.GetType("Roster.Client.ViewModels.HomeViewModel");
            var actual = target != null ? Activator.CreateInstance(target) : default;
            Assert.True(
                actual != null,
                "You need to create a public class named \"HomeViewModel\" in the \"Roster.Client.ViewModels\" namespace."
            );
        }

        [Fact(DisplayName = "2. Implement the INotifyPropertyChanged interface - @class-implements-inotifypropertychanged-interface")]
        public void ClassImplementsInterfaceTest()
        {
            MockForms.Init();
            Assembly assembly = typeof(App).Assembly;
            Type target = assembly.GetType("Roster.Client.ViewModels.HomeViewModel");
            var actual = target != null ? Activator.CreateInstance(target) : default;
            Assert.True(
                actual is INotifyPropertyChanged,
                "Your \"HomeViewModel\" class should implement the \"System.ComponentModel.INotifyPropertyChanged\" interface."
            );
        }
    }
}