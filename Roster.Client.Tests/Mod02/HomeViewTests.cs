using Xunit;
using Roster.Client.Views;
using Xamarin.Forms;
using Xamarin.Forms.Mocks;
using System.Reflection;

namespace Roster.Client.Tests
{
    public class HomeViewTests
    {
        [Fact(DisplayName = "The value of the \"FontSize\" property in the \"TitleLabel\" control should be set to \"Header\". @titlelabel-fontsize-header")]
        public void TitleLabelTextPropertyTest()
        {
            MockForms.Init();
            var actual = new HomeView().TitleLabel.GetValue(Label.FontSizeProperty);
            Assert.NotNull(actual);
            Assert.IsType<double>(actual);
            Assert.Equal(Device.GetNamedSize(NamedSize.Header, typeof(Label)), actual);
        }

        [Fact(DisplayName = "The value of the Title property in the \"TitleLabel\" control should be bound to the \"Title\" property of the BindingContext. @titlelabel-text-bind-title")]
        public void TitleLabelBoundPropertyTest()
        {
            MockForms.Init();
            var target = new HomeView().TitleLabel as BindableObject;
            var actual = target.GetBinding(Label.TextProperty);
            Assert.NotNull(actual);
            Assert.IsType<Binding>(actual);
            Assert.Equal("Title", actual.Path);
        }

        [Fact(DisplayName = "The binding for the Title property in the \"TitleLabel\" control should have it's \"FallbackValue\" set to \"Header\". @titlelabel-text-fallbackvalue")]
        public void TitleLabelFallbackValueTest()
        {
            MockForms.Init();
            var target = new HomeView().TitleLabel as BindableObject;
            var actual = target.GetBinding(Label.TextProperty);
            Assert.NotNull(actual);
            Assert.IsType<Binding>(actual);
            Assert.Equal("Title", actual.Path);
            Assert.Equal("Header", actual.FallbackValue);
        }

        [Fact(DisplayName = "The value of the BindingContext property of the \"HomeView\" control should be bound to an object with a property named \"Title\" and the property set to a value of \"Demo Header\". @bindingcontext-title")]
        public void HomeViewBindingContextTest()
        {
            MockForms.Init();
            var target = new HomeView();
            var actual = target.BindingContext;
            Assert.NotNull(actual);
            Assert.Equal("Roster App", actual.GetType().GetRuntimeProperty("Title")?.GetValue(actual));
        }
        
        [Fact(DisplayName = "The binding for the Title property in the \"TitleLabel\" control should have it's \"Mode\" set to \"OneTime\". @titlelabel-text-mode")]
        public void TitleLabelModeTest()
        {
            MockForms.Init();
            var target = new HomeView().TitleLabel as BindableObject;
            var actual = target.GetBinding(Label.TextProperty);
            Assert.NotNull(actual);
            Assert.IsType<Binding>(actual);
            Assert.Equal("Title", actual.Path);
            Assert.Equal("Header", actual.FallbackValue);
            Assert.Equal(BindingMode.OneTime, actual.Mode);
        }
    }
}