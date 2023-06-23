using System;
using System.Collections;

namespace GenericsConsoleApp
{
    public class CustomList : ICustomList
    {
        //define variables contained in class
        public var personList = new ArrayList();

        public int Count(personList)
        {
            int total;
            total = personList.count();
            return total;
        }
    }

}