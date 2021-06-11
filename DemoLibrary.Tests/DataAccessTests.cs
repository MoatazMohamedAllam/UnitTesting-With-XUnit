using DemoLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace DemoLibrary.Tests
{
    public class DataAccessTests
    {
        [Fact]
        public void Add_PersonToPeopleList_ShouldWork()
        {
            var newPerson = new PersonModel { FirstName = "moataz", LastName = "allam" };
            var people = new List<PersonModel>();

            DataAccess.AddPersonToPeopleList(people, newPerson);

            Assert.True(people.Count == 1);
            Assert.Contains<PersonModel>(newPerson, people);
        }

        [Theory]
        [InlineData("Sayed","", "LastName")]
        [InlineData("","Ahmed", "FirstName")]
        public void Add_PersonToPeopleList_ShouldFail(string FirstName, string LastName ,string param)
        {
            var newPerson = new PersonModel { FirstName = FirstName, LastName = LastName };
            var people = new List<PersonModel>();

            Assert.Throws<ArgumentException>(param, () => DataAccess.AddPersonToPeopleList(people, newPerson));
            
        }

        [Fact]
        public void Convert_ModelsToCSV_ShouldWork()
        {
            var expected = new List<string>
            {
                "ahmed,mohamed",
                "hager,ibrahim"
            };

            var people = new List<PersonModel>
            {
                new PersonModel{FirstName="ahmed",LastName="mohamed"},
                new PersonModel{FirstName="hager",LastName="ibrahim"},
            };

            var actual = DataAccess.ConvertModelsToCSV(people);

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Convert_CSVToModels_ShouldWork()
        {
            var expected = new List<PersonModel>
            {
                new PersonModel{ FirstName = "Ahmed", LastName = "Ali" },
            };

            var content = new string[]
            {
                "Ahmed,Ali"
            };

            var actual = DataAccess.ConvertCSVToModels(content);

            Assert.Equal(expected, actual);
        }
    }
}
