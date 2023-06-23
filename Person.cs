using System;
using System.Collections.Generic;
using System.Text;

namespace GenericsConsoleApp
{
    public class Person
    {
        public string FirstName { set; get; }
        public string LastName { set; get; }
        public uint Id { set; get; }

        public Person() { }

        public Person(string FirstName, string LastName, uint Id)
        {
            this.FirstName = FirstName;
            this.LastName = LastName;
            this.Id = Id;
        }

        public override bool Equals(object obj)
        {
            var person = (Person)obj;

            if (person.FirstName.Equals(FirstName) && person.LastName.Equals(LastName) && person.Id.Equals(Id))
            {
                return true;
            }
            return false;
        }

        public override string ToString()
        {
            return $"{FirstName} {LastName} {Id}";
        }

        public override int GetHashCode()
        {
            return (int)Id;
        }
    }
}
