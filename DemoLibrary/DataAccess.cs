using DemoLibrary.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoLibrary
{
    public static class DataAccess
    {
        private static string PersonTextFile = "PersonText.txt";

        public static void AddNewPerson(PersonModel person)
        {
            List<PersonModel> people = GetPeople();

            AddPersonToPeopleList(people, person);

            List<string> lines = ConvertModelsToCSV(people);

            File.WriteAllLines(PersonTextFile, lines);
        }

        public static void AddPersonToPeopleList(List<PersonModel> people,PersonModel person)
        {
            if (string.IsNullOrWhiteSpace(person.FirstName))
            {
                throw new ArgumentException("you passed invalid firstname", "FirstName");
            }

            if (string.IsNullOrWhiteSpace(person.LastName))
            {
                throw new ArgumentException("you passed invalid firstname", "LastName");
            }

            people.Add(person);
        }

        public static List<string> ConvertModelsToCSV(List<PersonModel> people)
        {
            List<string> lines = new List<string>();
            foreach (var user in people)
            {
                lines.Add($"{user.FirstName},{user.LastName}");
            }

            return lines;
        }


        public static List<PersonModel> GetPeople()
        {
            var content = File.ReadAllLines(PersonTextFile);

            return ConvertCSVToModels(content);
        }
        
        public static List<PersonModel> ConvertCSVToModels(string[] content)
        {
            var output = new List<PersonModel>();
            foreach (var item in content)
            {
                string[] data = item.Split(',');
                output.Add(new PersonModel { FirstName = data[0], LastName = data[1] });
            }

            return output;
        }



    }
}
