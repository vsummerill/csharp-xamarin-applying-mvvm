using Roster.Client.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using Xamarin.Forms;
using Xamarin.Forms.Mocks;
using Xunit;

namespace Roster.Client.Tests.Mod06
{
    public class HomeViewTests
    {
        [Fact(DisplayName = "1. Set the ItemsSource of PeopleListView to People - @peoplelistview-itemssource")]
        public void PeopleListViewItemsSourceBindingPathTest()
        {
            MockForms.Init();
            var target = new HomeView().PeopleListView as BindableObject;
            var actual = target.GetBinding(ListView.ItemsSourceProperty);
            Assert.True(
                actual is Binding,
                "The value of the `ItemsSource` property in the `PeopleListView` control should be data-bound."
            );
            Assert.True(
                (actual as Binding).Path == "People",
                "The value of the `ItemsSource` property in the `PeopleListView` control should be data-bound to the `People` property of the ViewModel (BindingContext)."
            );
        }

        [Fact(DisplayName = "2. Change the PeopleListView's ItemsSource Binding to be a One-way Binding - @peoplelistview-itemssource-binding-mode")]
        public void PeopleListViewItemsSourceBindingModeTest()
        {
            MockForms.Init();
            var target = new HomeView().PeopleListView as BindableObject;
            var actual = target.GetBinding(ListView.ItemsSourceProperty);
            Assert.True(
                actual is Binding,
                "The value of the `ItemsSource` property in the `PeopleListView` control should be data-bound."
            );
            Assert.True(
                (actual as Binding).Mode == BindingMode.OneWay,
                "The binding for the `ItemsSource` property in the `PeopleListView` control should have it's `Mode` set to `OneWay`."
            );
        }

        [Fact(DisplayName = "3. Add a TextCell to the DataTemplate - @datatemplate-textcell")]
        public void DataTemplateTextCellTest()
        {
            MockForms.Init();
            var target = new HomeView().PeopleListView.GetValue(ListView.ItemTemplateProperty);
            Assert.True(
                target != null,
                "You must have a property named `ItemTemplate` in the `PeopleListView` control."
            );
            Assert.True(
                target is DataTemplate,
                "The `ItemTemplate` property of the `PeopleListView` control must be set to a `DataTemplate`."
            );
            List<Cell> cells = new List<Cell>();
            try
            {
                cells = new HomeView().PeopleListView?.TemplatedItems.ToList<Cell>();
            }
            catch (InvalidOperationException)
            {
                Assert.True(
                    false,
                    "The `DataTemplate` property of the `PeopleListView` control should contain a single `TextCell` control."
                );
            }
            catch (InvalidCastException)
            {
                Assert.True(
                    false,
                    "The `DataTemplate` property of the `PeopleListView` control should contain a single `TextCell` control."
                );
            }
            Assert.True(
                cells.Any() && cells.All(i => i is TextCell),
                "The `DataTemplate` property of the `PeopleListView` control should contain a single `TextCell` control."
            );
        }

        [Fact(DisplayName = "4. Bind the TextCell's Text Property to the Context's Name - @datatemplate-textcell-text-binding")]
        public void DataTemplateTextCellTextBindingTest()
        {
            MockForms.Init();
            var target = new HomeView().PeopleListView.GetValue(ListView.ItemTemplateProperty);
            Assert.True(
                target != null,
                "You must have a property named `ItemTemplate` in the `PeopleListView` control."
            );
            Assert.True(
                target is DataTemplate,
                "The `ItemTemplate` property of the `PeopleListView` control must be set to a `DataTemplate`."
            );
            List<Cell> cells = new List<Cell>();
            try
            {
                cells = new HomeView().PeopleListView?.TemplatedItems.ToList<Cell>();
            }
            catch (InvalidOperationException)
            {
                Assert.True(
                    false,
                    "The `DataTemplate` property of the `PeopleListView` control should contain a single `TextCell` control."
                );
            }
            catch (InvalidCastException)
            {
                Assert.True(
                    false,
                    "The `DataTemplate` property of the `PeopleListView` control should only contain a single `TextCell` control and no other type of control."
                );
            }
            Assert.True(
                cells.Any() && cells.All(i => i is TextCell),
                "The `DataTemplate` property of the `PeopleListView` control should contain a single `TextCell` control."
            );
            Assert.True(
                cells.OfType<TextCell>().All(t => t.GetBinding(TextCell.TextProperty)?.Path == "Name"),
                "The `TextCell` control within the `DataTemplate` property of the `PeopleListView` control should have it's `Text` property data-bound to the context's `Name` property."
            );
        }

        [Fact(DisplayName = "5. Bind the TextCell's Detail Property to the Context's Company - @datatemplate-textcell-detail-binding")]
        public void DataTemplateTextCellDetailPropertyTest()
        {
            MockForms.Init();
            var target = new HomeView().PeopleListView.GetValue(ListView.ItemTemplateProperty);
            Assert.True(
                target != null,
                "You must have a property named `ItemTemplate` in the `PeopleListView` control."
            );
            Assert.True(
                target is DataTemplate,
                "The `ItemTemplate` property of the `PeopleListView` control must be set to a `DataTemplate`."
            );
            List<Cell> cells = new List<Cell>();
            try
            {
                cells = new HomeView().PeopleListView?.TemplatedItems.ToList<Cell>();
            }
            catch (InvalidOperationException)
            {
                Assert.True(
                    false,
                    "The `DataTemplate` property of the `PeopleListView` control should contain a single `TextCell` control."
                );
            }
            catch(InvalidCastException)
            {
                Assert.True(
                    false,
                    "The `DataTemplate` property of the `PeopleListView` control should only contain a single `TextCell` control and no other type of control."
                );
            }
            Assert.True(
                cells.Any() && cells.All(i => i is TextCell),
                "The `DataTemplate` property of the `PeopleListView` control should contain a single `TextCell` control."
            );
            Assert.True(
                cells.OfType<TextCell>().All(t => t.GetBinding(TextCell.TextProperty)?.Path == "Name"),
                "The `TextCell` control within the `DataTemplate` property of the `PeopleListView` control should have it's `Text` property data-bound to the context's `Name` property."
            );
            Assert.True(
                cells.OfType<TextCell>().All(t => t.GetBinding(TextCell.DetailProperty)?.Path == "Company"),
                "The `TextCell` control within the `DataTemplate` property of the `PeopleListView` control should have it's `Detail` property data-bound to the context's `Company` property."
            );
        }
    }
}