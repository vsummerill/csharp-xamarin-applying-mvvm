using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reflection;
using Xunit;

namespace Roster.Client.Tests.Mod05
{
    public class HomeViewModelTests
    {
        private Type GetPersonType()
        {
            Assembly assembly = typeof(App).Assembly;
            return assembly.GetType("Roster.Client.Models.Person");
        }

        private dynamic GetPerson()
        {
            Type type = GetPersonType();
            dynamic instance = type != null ? Activator.CreateInstance(type) : default;
            return instance;
        }

        private dynamic GetHomeViewModel()
        {
            Assembly assembly = typeof(App).Assembly;
            Type type = assembly.GetType("Roster.Client.ViewModels.HomeViewModel");
            dynamic instance = type != null ? Activator.CreateInstance(type) : default;
            return instance;
        }

        [Fact(DisplayName = "1. Create a Person Class - @person-class-exists")]
        public void PersonClassExistsTest()
        {
            dynamic actual = GetPerson();
            Assert.True(
                actual != null,
                "You need to create a public class named `Person` in the `Roster.Client.Models` namespace."
            );
        }

        [Fact(DisplayName = "2. Add Name Property to the Person Class - @person-name-property")]
        public void PersonClassNameStringPropertyTest()
        {
            dynamic target = GetPerson();
            Assert.True(
                target != null,
                "You need to create a public class named `Person` in the `Roster.Client.Models` namespace."
            );
            Type actual = target.GetType();
            Assert.True(
                actual.GetProperties().Any(p => p.Name == "Name" && p.PropertyType == typeof(string)),
                "Your `Person` class must include a public property of type `string` exactly named `Name`."
            );
        }

        [Fact(DisplayName = "3. Add Company Property to the Person Class - @person-company-property")]
        public void PersonClassCompanyStringPropertyTest()
        {
            dynamic target = GetPerson();
            Assert.True(
                target != null,
                "You need to create a public class named `Person` in the `Roster.Client.Models` namespace."
            );
            Type actual = target.GetType();
            Assert.True(
                actual.GetProperties().Any(p => p.Name == "Company" && p.PropertyType == typeof(string)),
                "Your `Person` class must include a public property of type `string` exactly named `Company`."
            );
        }

        [Fact(DisplayName = "4. Add an ObservableCollection of Person Objects to the HomeViewModel Class - @homeviewmodel-observablecollection-property")]
        public void HomeViewModelPeopleObservableCollectionPropertyTest()
        {
            dynamic target = GetHomeViewModel();
            Assert.True(
                target != null,
                "You need to create a public class named `HomeViewModel` in the `Roster.Client.ViewModels` namespace."
            );
            Type actual = target.GetType();
            var expected = typeof(ObservableCollection<>).MakeGenericType(GetPersonType());
            Assert.True(
                actual.GetProperties().Any(p => p.Name == "People" && p.PropertyType == expected),
                "Your `HomeViewModel` class must include a public property of type `ObservableCollection<Person>` exactly named `People`."
            );
        }

        [Fact(DisplayName = "5. Populate the ObservableCollection with Sample People - @homeviewmodel-observablecollection-sampledata")]
        public void HomeViewModelPeopleObservableCollectionSampleDataTest()
        {
            dynamic target = GetHomeViewModel();
            Assert.True(
                target != null,
                "You need to create a public class named `HomeViewModel` in the `Roster.Client.ViewModels` namespace."
            );
            List<dynamic> actual = new List<dynamic>();
            foreach(dynamic person in target.People) { actual.Add(person); }
            Assert.True(
                actual.Any(),
                "Populate the `People` property of the `HomeViewModel` class with the sample data specified."
            );
            Assert.True(
                actual.Any(a => a.Name == "Delores Feil" && a.Company == "Legros Group"),
                "Ensure the `People` property of the `HomeViewModel` class has at least one `Person` object with a `Name` of `\"Delores Feil\"` and a `Company` of `\"Legros Group\"`."
            );
            Assert.True(
                actual.Any(a => a.Name == "Ann Zboncak" && a.Company == "Ledner - Ferry"),
                "Ensure the `People` property of the `HomeViewModel` class has at least one `Person` object with a `Name` of `\"Ann Zboncak\"` and a `Company` of `\"Ledner - Ferry\"`."
            );
            Assert.True(
                actual.Any(a => a.Name == "Jaime Lesch" && a.Company == "Herzog and Sons"),
                "Ensure the `People` property of the `HomeViewModel` class has at least one `Person` object with a `Name` of `\"Jaime Lesch\"` and a `Company` of `\"Herzog and Sons\"`."
            );
        }
    }
}