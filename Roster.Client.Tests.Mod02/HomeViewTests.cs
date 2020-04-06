using Roster.Client.Views;
using System.Reflection;
using Xamarin.Forms;
using Xamarin.Forms.Mocks;
using Xunit;

namespace Roster.Client.Tests.Mod02
{
    public class HomeViewTests
    {
        [Fact(DisplayName = "1. Set the TitleLabel's FontSize property to Header - @titlelabel-fontsize-header")]
        public void TitleLabelTextPropertyTest()
        {
            MockForms.Init();
            var actual = new HomeView().TitleLabel.GetValue(Label.FontSizeProperty);
            Assert.True(
                actual != null,
                "You must have a property named \"FontSize\" in the \"TitleLabel\" control."
            );
            Assert.True(
                (double)actual == Device.GetNamedSize(NamedSize.Header, typeof(Label)),
                "The value of the \"FontSize\" property in the \"TitleLabel\" control should be set to \"Header\"."
            );
        }

        [Fact(DisplayName = "2. Bind the TitleLabel's Text property to the context's Title property - @titlelabel-text-bind-title")]
        public void TitleLabelBoundPropertyTest()
        {
            MockForms.Init();
            var target = new HomeView().TitleLabel as BindableObject;
            var actual = target.GetBinding(Label.TextProperty);
            Assert.True(
                actual != null,
                "You must have a property named \"Text\" in the \"TitleLabel\" control."
            );
            Assert.True(
                actual is Binding,
                "The value of the \"Text\" property in the \"TitleLabel\" control should be data-bound."
            );
            Assert.True(
                (actual as Binding).Path == "Title",
                "The value of the \"Text\" property in the \"TitleLabel\" control should be data-bound to the \"Title\" property of the BindingContext."
            );
        }

        [Fact(DisplayName = "3. Change the TitleLabel's Text property's binding to have a fallback value of \"Header\" - @titlelabel-text-fallbackvalue")]
        public void TitleLabelFallbackValueTest()
        {
            MockForms.Init();
            var target = new HomeView().TitleLabel as BindableObject;
            var actual = target.GetBinding(Label.TextProperty);
            Assert.True(
                actual != null,
                "You must have a property named \"Text\" in the \"TitleLabel\" control."
            );
            Assert.True(
                actual is Binding,
                "The value of the \"Text\" property in the \"TitleLabel\" control should be data-bound."
            );
            Assert.True(
                ((actual as Binding).FallbackValue as string) == "Header",
                "The binding for the \"Text\" property in the \"TitleLabel\" control should have it's \"FallbackValue\" set to \"Header\"."
            );
        }

        [Fact(DisplayName = "4. Add a simple data context with a Title property set to \"Roster App\" - @bindingcontext-title")]
        public void HomeViewBindingContextTest()
        {
            MockForms.Init();
            var target = new HomeView();
            var actual = target.BindingContext;
            Assert.True(
                actual != null,
                "You \"HomeView\" control must have some value set as it's \"BindingContext\" in the class file (code-behind)."
            );
            Assert.True(
                (actual.GetType().GetRuntimeProperty("Title")?.GetValue(actual) as string) == "Roster App",
                "The value of the \"BindingContext\" property of the \"HomeView\" control should be bound to an object with a property named \"Title\" and the property set to a value of \"Roster App\"."
            );
        }
        
        [Fact(DisplayName = "5. Change the TitleLabel's Text property's binding to be a one-time binding - @titlelabel-text-mode")]
        public void TitleLabelModeTest()
        {
            MockForms.Init();
            var target = new HomeView().TitleLabel as BindableObject;
            var actual = target.GetBinding(Label.TextProperty);
            Assert.True(
                actual != null,
                "You must have a property named \"Text\" in the \"TitleLabel\" control."
            );
            Assert.True(
                actual is Binding,
                "The value of the \"Text\" property in the \"TitleLabel\" control should be data-bound."
            );
            Assert.True(
                (actual as Binding).Mode == BindingMode.OneTime,
                "The binding for the \"Text\" property in the \"TitleLabel\" control should have it's \"Mode\" set to \"OneTime\"."
            );
        }
    }
}