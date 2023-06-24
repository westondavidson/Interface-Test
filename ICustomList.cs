using System;

namespace GenericsConsoleApp
{
    public interface ICustomList<T>
    {
        //Gets the number of items contained in the ICustomList<T>.
        public int Count { get; }

        //Gets or sets an item at the specified index.
        public T this[int i] { get; set; }

        //Adds an object to the end of the ICustomList<T>.
        public void Add(T item);

        //Adds the elements of the specified collection to the end of the ICustomList<T>.
        public void AddRange(T[] array);

        //Removes all elements from the ICustomList<T>.
        public void Clear();

        //Determines whether an element is in the ICustomList<T>.
        public bool Contains(T item);

        //Copies the entire ICustomList<T> to a compatible one-dimensional array, starting at the beginning of the target array.
        public T[] CopyTo(T[] array);

        //Copies the entire ICustomList<T> to a compatible one-dimensional array, starting at the specified
        //index of the target array.
        public T[] CopyTo(T[] array, int arrayIndex);

        /*Copies a range of items from the ICustomList<T> to a compatible one-dimensional array, 
         *starting at the specified index of the target array.
         */
        public T[] CopyTo(int index, T[] array, int arrayIndex, int count);

        //Determines whether the ICustomList<T> contains elements that match the conditions defined by the specified predicate.
        public bool Exists(Predicate<T> match);

        /*Searches for an item that matches the conditions defined by the specified predicate,
         *and returns the first occurrence within the entire ICustomList<T>.
         */
        public T? Find(Predicate<T> match);

        //Retrieves all the elements that match the conditions defined by the specified predicate.
        public ICustomList<T> FindAll(Predicate<T> match);

        /*Searches for an element that matches the conditions defined by the specified predicate, 
         * and returns the zero-based index of the first occurrence within the entire ICustomList<T>.
         */
        public int FindIndex(Predicate<T> match);

        /*Searches for an element that matches the conditions defined by the specified predicate, 
         * and returns the zero-based index of the first occurrence within the range of elements 
         * in the ICustomList<T> that extends from the specified index to the last element.
         */
        public int FindIndex(int startIndex, Predicate<T> match);

        /*Searches for an element that matches the conditions defined by the specified predicate, 
         * and returns the zero-based index of the first occurrence within the range of items
         * in the ICustomList<T> that starts at the specified index and contains the specified number of items.
         */
        public int FindIndex(int index, int count, Predicate<T> match);

        /*Searches for an element that matches the conditions defined by the specified predicate,
         *and returns the last occurrence within the entire ICustomList<T>.
         */
        public T FindLast(Predicate<T> match);

        /*Searches for an item that matches the conditions defined by the specified predicate, 
         * and returns the zero-based index of the last occurrence within the entire ICustomList<T>.
         */
        public int FindLastIndex(Predicate<T> match);

        /*Searches for an element that matches the conditions defined by the specified predicate,
         * and returns the zero-based index of the last occurrence within the range of items in the ICustomList<T> 
         * that extends from the first element to the specified index.
         */
        public int FindLastIndex(int endIndex, Predicate<T> match);

        /*Searches for an item that matches the conditions defined by the specified predicate, 
         * and returns the zero-based index of the last occurrence within the range of items in the ICustomList<T> 
         * that contains the specified number of items and ends at the specified index.
         */
        public int FindLastIndex(int endIndex, int count, Predicate<T> match);

        //Performs the specified action on each item of the ICustomList<T>.
        public void ForEach(Action<T> action);

        //Creates a shallow copy of a range of elements in the source ICustomList<T>.
        public ICustomList<T> GetRange(int index, int count);

        //Inserts an element into the ICustomList<T> at the specified index.
        public void Insert(T item, int index);

        //Inserts the elements of an aaray into the ICustomList<T> at the specified index.
        public void InsertRange(T[] inputArray, int startIndex);

        /*Searches for the specified object and returns the zero-based index of the first
         *occurrence within the entire ICustomList<T>.
         */
        public int IndexOf(T item);

        /*Searches for the specified object and returns the zero-based index of 
         * the first occurrence within the range of elements in the ICustomList<T> 
         * that extends from the specified index to the last element.
         */
        public int IndexOf(T item, int index);

        /// <summary>
        /// Searches for the specified object and returns the zero-based index of the first 
        /// occurrence within the range of elements in the ICustomList<T> that starts at the 
        /// specified index and contains thr number of items indicated by the count variable.
        /// </summary>
        /// <param name="item"></param>
        /// <param name="index"></param>
        /// <param name="count"></param>
        /// <returns></returns>
        public int IndexOf(T item, int index, int count);

        /// <summary>
        /// Removes the first occurrence of a specified item from the ICustomList<T>.
        /// It returns a boolean to indicate whether an occurrence of the specified item was found.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public bool Remove(T item);

        //Removes all the elements that match the specified item. Returns a count of how items were removed.
        public int RemoveAll(T item);

        /*Removes all the elements that match the conditions defined by the specified predicate.
         *It returns a boolean to indicate whether an occurrence of the specified item was found. 
         */
        public int RemoveAll(Predicate<T> match);

        //Removes the item at the specified index of the ICustomList<T>.
        public void RemoveAt(int index);

        //Removes the first item from the ICustomList<T>.
        public void RemoveFirst();

        /// <summary>
        /// Removes the last item from the ICustomList<T>.
        /// </summary>
        public void RemoveLast();

        /// <summary>
        /// Removes items from the specified index to the end of the list
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>        
        public ICustomList<T> RemoveRange(int index);

        /// <summary>
        /// Removes items from the list in the specified range.
        /// </summary>
        /// <param name="index"></param>
        /// <param name="count"></param>
        /// <returns></returns>
        public ICustomList<T> RemoveRange(int index, int count);

        /// <summary>
        /// Reverses the order of the items in the entire ICustomList<T>.
        /// </summary>
        public void Reverse();

        /// <summary>
        /// Reverses the order of the items in the specified range.
        /// </summary>
        /// <param name="startIndex"></param>
        /// <param name="count"></param>
        public void Reverse(int startIndex, int count);

        /// <summary>
        /// Determines whether every element in the ICustomList<T> matches the conditions defined by the specified predicate.
        /// </summary>
        /// <param name="match"></param>
        /// <returns></returns>
        public bool TrueForAll(Predicate<T> match);
    }
}