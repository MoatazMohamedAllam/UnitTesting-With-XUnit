using DemoLibrary;
using DemoLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter firstname ---------------");
            string Firstname = Console.ReadLine();
            
            Console.WriteLine("Enter lastname----------------");
            string Lastname = Console.ReadLine();

            DataAccess.AddNewPerson(new PersonModel { FirstName = Firstname, LastName = Lastname });


            Console.WriteLine("All People ========================");
            foreach (var item in DataAccess.GetPeople())
            {
                Console.WriteLine(item.FirstName + "," + item.LastName);
            }
        }
    }
}
