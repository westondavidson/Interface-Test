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
        //empty person constructor
        public Person() { }
        //person constructor with passed in values
        public Person(string FirstName, string LastName, uint Id)
        {
            this.FirstName = FirstName;
            this.LastName = LastName;
            this.Id = Id;
        }

        //returns a true or false if the given person matches another person.
        //used to compare two people.
        public override bool Equals(object obj)
        {
            var person = (Person)obj;

            if (person.FirstName.Equals(FirstName) && person.LastName.Equals(LastName) && person.Id.Equals(Id))
            {
                return true;
            }
            return false;
        }
        //override of tostring to output person class info
        public override string ToString()
        {
            return $"{FirstName} {LastName} {Id}";
        }
        //override of GetHashCode to output person ID
        public override int GetHashCode()
        {
            return (int)Id;
        }
    }
}
