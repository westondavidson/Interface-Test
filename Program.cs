using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericsConsoleApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CustomList<Person> listTests = new CustomList<Person>();

            listTests.Add(new Person("weston", "Davidson", 657));
            listTests.Add(new Person("cool", "guy", 555));
            Person person = listTests[0];
            Person[] people = { new Person("Dude", "one", 303), new Person("Guy", "Two", 465) };

            CustomList<Person> listTestsAddRange = new CustomList<Person>();

            listTestsAddRange.AddRange(people);

            
            Console.WriteLine(person.FirstName);
            
        }
    }
}
