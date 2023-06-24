using System;
using System.Collections;

namespace GenericsConsoleApp
{
    public class CustomList<T> : ICustomList<T>
    {
        public ArrayList List = new ArrayList();

        public int Count
        {
            get
            {
                return List.Count;
            }
        }

        public T this[int i]
        {
            get { return (T)List[i]; }
            set { List[i] = value; }

        }

        public void Add(T person) {
        List.Add(person);
        }

        public void AddRange(T[] array)
        {
            foreach (T item in array)
            {
                List.Add(item);
            }
        }

        public void Clear()
        {
            List.Clear();
        }

        public bool Contains(T item)
        {
            return List.Contains(item);
        }

        public T[] CopyTo(T[] array)
        {
            return array = (T[])List.Clone();
        }

        public T[] CopyTo(T[] array, int arrayIndex)
        {
            foreach(T person in List)
            {
                array[arrayIndex++] = person;
            }
            return array;
        }


    }
}