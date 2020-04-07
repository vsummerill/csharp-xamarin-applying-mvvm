using Roster.Client.Views;
using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Forms.Mocks;
using Xunit;

namespace Roster.Client.Tests.Mod04
{
    public class HomeViewModelTests
    {
        [Fact(DisplayName = "1. Set the UpdateApplicationCommand Property's Value - @command-new")]
        public void CommandPropertyValueTest()
        {
            Xamarin.Forms.Mocks.MockForms.Init();
            dynamic target = new Views.HomeView()?.BindingContext;
            Command actual = target.UpdateApplicationCommand;
            Assert.True(
                actual != null,
                "You should use the `HomeViewModel` constructor to create a new instance of the `Command` class, assign an action and save it in the `UpdateApplicationCommand` property."
            );
        }

        [Fact(DisplayName = "2. Add Execute Behavior to the UpdateApplicationCommand - @command-execute")]
        public void CommandExecuteBehaviorTest()
        {
            MockForms.Init();
            dynamic target = new HomeView()?.BindingContext;
            Command subtarget = target.UpdateApplicationCommand;
            Assert.True(
                subtarget != null,
                "You should use the `HomeViewModel` constructor to create a new instance of the `Command` class, assign an action and save it in the `UpdateApplicationCommand` property."
            );
            Assert.True(
                target.Title == "Roster App",
                "Before the `UpdateApplicationCommand` is executed, the value of the `Title` property should be set to `Roster App`."
            );
            subtarget.Execute(default);
            Assert.True(
                target.Title == "Roster App (v2.0)",
                "When the `UpdateApplicationCommand` is executed, the value of the `Title` property should be set to `Roster App (v2.0)`."
            );
        }

        [Fact(DisplayName = "3. Bind the UpdateApplicationCommand to the Command Property of AddPersonButton - @view-button-command-binding")]
        public void ViewBindButtonCommandTest()
        {
            MockForms.Init();
            var target = new HomeView().AddPersonButton as BindableObject;
            var actual = target.GetBinding(Button.CommandProperty);
            Assert.True(
                actual is Binding,
                "The value of the `Command` property in the `AddPersonButton` control should be data-bound."
            );
            Assert.True(
                (actual as Binding).Path == "UpdateApplicationCommand",
                "The value of the `Command` property in the `AddPersonButton` control should be data-bound to the `UpdateApplicationCommand` property of the ViewModel (BindingContext)."
            );
        }

        [Fact(DisplayName = "4. Change the AddPersonButton's Command Binding to be a One-time Binding - @view-button-command-mode")]
        public void ViewBindButtonCommandModeTest()
        {
            MockForms.Init();
            var target = new HomeView().AddPersonButton as BindableObject;
            var actual = target.GetBinding(Button.CommandProperty);
            Assert.True(
                actual is Binding,
                "The value of the `Command` property in the `AddPersonButton` control should be data-bound."
            );
            Assert.True(
                (actual as Binding).Mode == BindingMode.OneTime,
                "The binding for the `Command` property in the `AddPersonButton` control should have it's `Mode` set to `OneTime`."
            );
        }

        [Fact(DisplayName = "5. Raise the PropertyChanged Event When the Title is Changed - @raise-propertychanged-title")]
        public void RaisePropertyChangedTitleTest()
        {
            MockForms.Init();
            dynamic target = new HomeView()?.BindingContext;
            bool actual = false;
            target.PropertyChanged += new PropertyChangedEventHandler((sender, e) => { actual = true; });
            target.Title = "Roster App - Changed";
            Assert.True(
                actual,
                "Any change to the `Title` property should raise the `PropertyChanged` event of the `HomeViewModel` class."
            );
        }
    }
}