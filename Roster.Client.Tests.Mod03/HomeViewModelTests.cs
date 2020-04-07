using Roster.Client.Views;
using System;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using Xamarin.Forms;
using Xamarin.Forms.Mocks;
using Xunit;

namespace Roster.Client.Tests.Mod03
{
    public class HomeViewModelTests
    {
        private Type GetHomeViewModelType()
        {
            Assembly assembly = typeof(App).Assembly;
            return assembly.GetType("Roster.Client.ViewModels.HomeViewModel");
        }

        private dynamic GetHomeViewModel()
        {
            Type type = GetHomeViewModelType();
            dynamic instance = type != null ? Activator.CreateInstance(type) : default;
            return instance;
        }

        [Fact(DisplayName = "1. Create a HomeViewModel Class - @class-exists")]
        public void ClassExistsTest()
        {
            dynamic actual = GetHomeViewModel();
            Assert.True(
                actual != null,
                "You need to create a public class named `HomeViewModel` in the `Roster.Client.ViewModels` namespace."
            );
        }

        [Fact(DisplayName = "2. Implement the INotifyPropertyChanged Interface - @class-implements-inotifypropertychanged-interface")]
        public void ClassImplementsInterfaceTest()
        {
            dynamic actual = GetHomeViewModel();
            Assert.True(
                actual != null,
                "You need to create a public class named `HomeViewModel` in the `Roster.Client.ViewModels` namespace."
            );
            Assert.True(
                actual is INotifyPropertyChanged,
                "Your `HomeViewModel` class should implement the `System.ComponentModel.INotifyPropertyChanged` interface."
            );
        }

        [Fact(DisplayName = "3. Add a New Title String Property - @title-string-property")]
        public void ClassTitleStringPropertyTest()
        {
            dynamic target = GetHomeViewModel();
            Assert.True(
                target != null,
                "You need to create a public class named `HomeViewModel` in the `Roster.Client.ViewModels` namespace."
            );
            Type actual = target.GetType();
            Assert.True(
                actual.GetProperties().Any(p => p.Name == "Title" && p.PropertyType == typeof(string)),
                "Your `HomeViewModel` class must include a public property of type `string` exactly named `Title`."
            );
        }

        [Fact(DisplayName = "4. Update the Title String Property's Default Value - @title-default-value")]
        public void ClassTitleDefaultValueTest()
        {
            dynamic target = GetHomeViewModel();
            Assert.True(
                target != null,
                "You need to create a public class named `HomeViewModel` in the `Roster.Client.ViewModels` namespace."
            );
            Type actual = target.GetType();
            Assert.True(
                actual.GetProperties().Any(p => p.Name == "Title" && p.PropertyType == typeof(string)),
                "Your `HomeViewModel` class must include a public property of type `string` exactly named `Title`."
            );
            Assert.True(
                target.Title == "Roster App",
                "The `Title` property of your `HomeViewModel` class must have it's default value set to `\"Roster App\"`"
            );
        }

        [Fact(DisplayName = "5. Add a New Command - @new-command")]
        public void ClassAddNewCommand()
        {
            dynamic target = GetHomeViewModel();
            Assert.True(
                target != null,
                "You need to create a public class named `HomeViewModel` in the `Roster.Client.ViewModels` namespace."
            );
            Type actual = target.GetType();
            Assert.True(
                actual.GetProperties().Any(p => p.Name == "UpdateApplicationCommand" && p.PropertyType == typeof(Command)),
                "Your `HomeViewModel` class must include a public property of type `Command` exactly named `UpdateApplicationCommand`."
            );
        }

        [Fact(DisplayName = "6. Set the ViewModel as the Context of the View - @bindingcontext-viewmodel")]
        public void HomeViewBindingContextTest()
        {
            MockForms.Init();
            var target = new HomeView();
            var actual = target.BindingContext;
            Assert.True(
                actual != null,
                "You `HomeView` control must have some value set as it's `BindingContext` in the class file (code-behind)."
            );
            Assert.True(
                actual.GetType().IsAssignableFrom(GetHomeViewModelType()),
                "The value of the `BindingContext` property of the `HomeView` control should be bound to an instance of the `HomeViewModel` class."
            );
        }
    }
}