using System;
using System.Collections;
using System.Diagnostics;
using System.Reflection;
using System.Security.Cryptography.X509Certificates;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.ComponentModel.Design.Serialization;
using System.Diagnostics.Eventing.Reader;

namespace GenericsConsoleApp
{
    public class CustomList<T> : ICustomList<T>
    {
        //https://referencesource.microsoft.com/#mscorlib/system/collections/generic/list.cs,aeb6ba6c11713802,references
        /*
         * Notes:
         * - To create a custom list, we'll use an internal array as our base
         * to store objects, and reallocate/recreate this array given the input.
         * 
         */
        private int DefaultCapacity { get; set; } = 0;
        private T[] items = new T[0];

        public override string ToString()
        {
            string output = "";
            for (int i=0; i < items.Length; i++)
            {
                if (i == items.Length - 1)
                {
                    output += items[i].ToString();
                }
                else output += items[i].ToString() + ", ";
            }
            return output;
        }

        public T this[int i]
        {
            get {
                //return internal array value

                    return items[i];



            }
            set {
                //set the provided index to the provided value.
                //items[i] = value;
                //this[Count + 1] = item;
                try
                {
                    items[i] = value;
                }
                catch (IndexOutOfRangeException)
                {
                    //if the provided index is out of range, create a new
                    //array with a length of index, copy old values over,
                    //and assign value to items.
                    T[] itemsUpdate = new T[Count + 1];
                    if (Count == 0)
                    {
                        itemsUpdate[0] = value;
                        items = itemsUpdate;
                    }
                    else
                    {
                        for (int j = 0; j <= Count - 1; j++)
                        {
                            itemsUpdate[j] = items[j];
                        }
                        itemsUpdate[Count] = value;
                        items = itemsUpdate;
                    }

                }

            }
        }

        public int Count
        {
            get { return items.Length; }
        }

        public void Add(T item)
        {
            this[Count] = item;
    /*        try
            {
                items[Count + 1] = item;
            }
            catch (IndexOutOfRangeException)
            {
                //if the provided index is out of range, create a new
                //array with a length of index, copy old values over,
                //and assign value to items.
                T[] itemsUpdate = new T[Count + 1];
                if (Count == 0)
                {
                    itemsUpdate[0] = item;
                    items = itemsUpdate;
                }
                else
                {
                    for (int i = 0; i <= Count - 1; i++)
                    {
                        itemsUpdate[i] = items[i];
                    }
                    itemsUpdate[Count] = item;
                    items = itemsUpdate;
                }

            }*/
        }

        public void AddRange(T[] array)
        {
            foreach (T item in array) this.Add(item);
        }

        public void Clear()
        {
            items = new T[0];
        }

        public bool Contains(T item)
        {
            bool ret = false;
            foreach(var thing in items)
            {
                if (thing.Equals(item)) ret = true;
            }
            return ret;
        }

        public T[] CopyTo(T[] array)
        {
            //we are copying the existing custom list INTO the provided array in params.
            for(int i = 0; i < Count; i++)
            {
                array[i] = this[i];
            }
            return array;
            
        }

        public T[] CopyTo(T[] array, int arrayIndex)
        {
            for(int i=0; i < Count; i++)
            {
                array[arrayIndex] = this[i];
                arrayIndex++;
            }
            return array;
        }

        public T[] CopyTo(int index, T[] array, int arrayIndex, int count)
        {

            for (int i = 0; i < count; i++)
            {
                array[arrayIndex] = this[index];
                arrayIndex++;
                index++;
            }
            return array;
        }

        public bool Exists(Predicate<T> match)
        {
            foreach(var thing in items)
            {
                if (match(thing) == true)
                {
                    return true;
                }
            }
            return false;
        }
#nullable enable
        public T? Find(Predicate<T> match)
        {
            foreach (var thing in items)
            {
                if (match(thing) == true)
                {
                    return thing;
                }
            }
            return default(T);
        }


#nullable disable
        public ICustomList<T> FindAll(Predicate<T> match)
        {
            CustomList<T> list = new CustomList<T>();
            foreach(T item in items)
            {
                if(match(item)){
                    list.Add(item);
                }
            }
            return list;

        }

        public int FindIndex(Predicate<T> match)
        {
            int i = 0;
            foreach(var thing in items)
            {
                if(match(thing) == true)
                {
                    return i;
                }
                i++;
            }
            return -1;
        }

        public int FindIndex(int startIndex, Predicate<T> match)
        {
            for (int i = startIndex; i < Count; i++)
            {
                if (match(items[i]) == true)
                {
                    return i;
                }
            }
            return -1;
        }

        public int FindIndex(int index, int count, Predicate<T> match)
        {
            //count, I think, is referring to the total number of indices to check.
            int i = 0;
            while(i < count)
            {
                if (match(items[index]))
                {
                    return index;
                }
                i++;
                index++;
            }
            return -1;
        }

        public T FindLast(Predicate<T> match)
        {
            T item = default(T);
            //I could probably search the list backwards to be faster, but for now
            //I'll just reassign the value until it isn't assigned any more lol.
            foreach (var thing in items)
            {
                if(match(thing) == true)
                {
                    item = thing;
                }
            }
            return item;
        }

        public int FindLastIndex(Predicate<T> match)
        {
            int index = 0;
            int indexStore = -1;
            //I could probably search the list backwards to be faster, but for now
            //I'll just reassign the value until it isn't assigned any more lol.
            foreach (var thing in items)
            {
                if (match(thing) == true)
                {
                    indexStore = index;
                }
                index++;
            }
            return indexStore;
        }

        public int FindLastIndex(int endIndex, Predicate<T> match)
        {
            int indexStore = -1;
            for (int i = 0; i <= endIndex; i++)
            {
                if (match(items[i]) == true)
                {
                    indexStore = i;
                }
            }
            return indexStore;
        }

        
        public int FindLastIndex(int endIndex, int count, Predicate<T> match)
        {
            int startIndex = endIndex - count + 1;
            int lastIndex = -1;

            if (startIndex < 0)
            {
                count = endIndex;
                startIndex = 0;
            }

            while (count > 0)
            {
 
                if (match(this[startIndex]))
                {
                    lastIndex = startIndex;
                }
                count--;
                startIndex++;
            }
            return lastIndex;
        }



        public void ForEach(Action<T> action)
        {
            foreach (var thing in items)
            {
                action(thing);
            }
        }
        //ask william about this - return type of the same class the method is in??
        public ICustomList<T> GetRange(int index, int count)
        {
            var list = new CustomList<T>();
            for(int i = 0; i<count; i++)
            {
                list.Add(items[index]);
                index++;
            }
            return list;
        }

        public int IndexOf(T item)
        {
            int index = 0;
            foreach (T thing in items)
            {
                if (thing.Equals(item))
                {
                    return index;
                }
                index++;
            }
            return -1;
        }

        public int IndexOf(T item, int index)
        {
            for(int i = index; i < Count; i++)
            {
                if (items[i].Equals(item))
                {
                    return i;
                }
            }
            return -1;
        }

        public int IndexOf(T item, int index, int count)
        {
            while(count > 0)
            {
                if (this[index].Equals(item))
                {
                    return index;
                }
                index++;
                count--;
            }
            return -1;
        }

        public void Insert(T item, int index)
        {
            T oldValueHolder;
            T newValueHolder = item;
            for(int i = index; i < Count; i++)
            {
                //store the current value of the index
                oldValueHolder = this[i];
                //assign the new value over this index position
                this[i] = newValueHolder;
                //assign the old value so it is reassigned next loop.
                newValueHolder = oldValueHolder;
            }
            //to avoid index out of bounds error, add the final value outside of loop (there is probably a better way to solve this)
            this[Count] = newValueHolder;
        }

        public void InsertRange(T[] inputArray, int startIndex)
        {
            //let's make a copy of our existing array so we don't have to rerun single inserts over and over.
            T[] listStored = new T[Count];
            this.CopyTo(listStored);
            //the start of the new array will be at the index provided and run for the total length of arg array
            int remainingLength = Count - startIndex;
            //take the start index, add on input array length to find where we will add in the following values from our original array.
            int indexTracker = startIndex;
            for(int i = 0; i < inputArray.Length; i++)
            {
                this[indexTracker] = inputArray[i];
                indexTracker++;
            }
            for(int i = 0; i < remainingLength; i++)
            {
                this[indexTracker] = listStored[startIndex];
                startIndex++;
                indexTracker++;
            }

        }

        public bool Remove(T item)
        {
            bool itemFound = false;
            int indexer = 0;
            foreach(var thing in items)
            {
                if (thing.Equals(item))
                {
                    T[] newList = new T[Count - 1];
                    itemFound = true;
                    //need an index tracker for two while loops? This approach is probably spaghetti
                    int indexAssignmentTracker = 0;
                    while(indexAssignmentTracker != indexer)
                    {
                        newList[indexAssignmentTracker] = this[indexAssignmentTracker];
                        indexAssignmentTracker++;
                    }
                    while(indexAssignmentTracker < Count - 1)
                    {
                        newList[indexAssignmentTracker] = this[indexAssignmentTracker + 1];
                        indexAssignmentTracker++;
                    }
                    if (indexer != Count - 1)
                    {
                        newList[newList.Length - 1] = this[indexAssignmentTracker];
                    }

                    items = newList;
                    return itemFound;
                }
                indexer++;
            }
            return itemFound;
        }

        public int RemoveAll(T item)
        {
            int itemsFound = 0;
            int indexer = 0;
            foreach (var thing in items)
            {
                if (thing.Equals(item))
                {
                    
                    T[] newList = new T[Count - 1];
                    itemsFound++;
                    //need an index tracker for two while loops? This approach is probably spaghetti
                    int indexAssignmentTracker = 0;
                    while (indexAssignmentTracker != indexer)
                    {
                        newList[indexAssignmentTracker] = this[indexAssignmentTracker];
                        indexAssignmentTracker++;
                    }
                    while (indexAssignmentTracker < Count - 1)
                    {
                        newList[indexAssignmentTracker] = this[indexAssignmentTracker + 1];
                        indexAssignmentTracker++;
                    }
                    if (indexer != Count - 1)
                    {
                        newList[newList.Length - 1] = this[indexAssignmentTracker];
                    }
                    indexer = indexer - 1;
                    items = newList;
                }
                indexer++;
            }
            return itemsFound;
        }

        public int RemoveAll(Predicate<T> match)
        {
            int itemsFound = 0;
            int indexer = 0;
            foreach (var thing in items)
            {
                if (match(thing))
                {

                    T[] newList = new T[Count - 1];
                    itemsFound++;
                    //need an index tracker for two while loops? This approach is probably spaghetti
                    int indexAssignmentTracker = 0;
                    while (indexAssignmentTracker != indexer)
                    {
                        newList[indexAssignmentTracker] = this[indexAssignmentTracker];
                        indexAssignmentTracker++;
                    }
                    while (indexAssignmentTracker < Count - 1)
                    {
                        newList[indexAssignmentTracker] = this[indexAssignmentTracker + 1];
                        indexAssignmentTracker++;
                    }
                    if (indexer != Count - 1)
                    {
                        newList[newList.Length - 1] = this[indexAssignmentTracker];
                    }
                    indexer = indexer - 1;
                    items = newList;
                }
                indexer++;
            }
            return itemsFound;

        }

        public void RemoveAt(int index)
        {

            int indexer = index;
            T[] newList = new T[Count - 1];

            int indexAssignmentTracker = 0;
            while (indexAssignmentTracker != indexer)
            {
                newList[indexAssignmentTracker] = this[indexAssignmentTracker];
                indexAssignmentTracker++;
            }
            while (indexAssignmentTracker < Count - 1)
            {
                newList[indexAssignmentTracker] = this[indexAssignmentTracker + 1];
                indexAssignmentTracker++;
            }
            if (indexer != Count - 1)
            {
                newList[newList.Length - 1] = this[indexAssignmentTracker];
            }

            items = newList;


        }

        public void RemoveFirst()
        {
            int indexer = 0;
            T[] newList = new T[Count - 1];

            int indexAssignmentTracker = 0;
            while (indexAssignmentTracker != indexer)
            {
                newList[indexAssignmentTracker] = this[indexAssignmentTracker];
                indexAssignmentTracker++;
            }
            while (indexAssignmentTracker < Count - 1)
            {
                newList[indexAssignmentTracker] = this[indexAssignmentTracker + 1];
                indexAssignmentTracker++;
            }
            if (indexer != Count - 1)
            {
                newList[newList.Length - 1] = this[indexAssignmentTracker];
            }

            items = newList;
        }

        public void RemoveLast()
        {
            int indexer = Count - 1;
            T[] newList = new T[Count - 1];

            int indexAssignmentTracker = 0;
            while (indexAssignmentTracker != indexer)
            {
                newList[indexAssignmentTracker] = this[indexAssignmentTracker];
                indexAssignmentTracker++;
            }
            while (indexAssignmentTracker < Count - 1)
            {
                newList[indexAssignmentTracker] = this[indexAssignmentTracker + 1];
                indexAssignmentTracker++;
            }
            if (indexer != Count - 1)
            {
                newList[newList.Length - 1] = this[indexAssignmentTracker];
            }

            items = newList;
        }

        public ICustomList<T> RemoveRange(int index)
        {

            while(Count > index)
            {
                this.RemoveAt(index);
            }
            return this;

           
        }

        public ICustomList<T> RemoveRange(int index, int count)
        {
            CustomList<T> newList = new CustomList<T>();
            while (Count > index && count > 0)
            {
                newList.Add(this[index]);
                this.RemoveAt(index);
                count--;
            }
            return newList;
        }

        public void Reverse()
        {
            CustomList<T> newList = new CustomList<T>();
            int countStore = Count;
            int indexer = 0;
            while(countStore > 0)
            {
                newList.Add(this[countStore - 1]);
                indexer++;
                countStore--;
            }
            for (int i = 0; i < Count; i++)
            {
                this[i] = newList[i];
            }

        }

        public void Reverse(int startIndex, int count)
        {
            CustomList<T> newList = new CustomList<T>();
            int indexer = 0;
            while (indexer < startIndex)
            {
                newList.Add(this[indexer]);
                indexer++;
            }
            while(count > 0)
            {
                newList.Add(this[startIndex + count -1]);
                count--;
                indexer++;
            }
            while(indexer < Count)
            {
                newList.Add(this[indexer]);
                indexer++;

            }
            for(int i = 0; i < Count; i++)
            {
                this[i] = newList[i];
            }
        }

        public bool TrueForAll(Predicate<T> match)
        {
            foreach(T t in items)
            {
                if (!match(t)) return false;
            }
            return true;
        }
    }
}