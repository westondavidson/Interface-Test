using Microsoft.VisualStudio.TestTools.UnitTesting;
using GenericsConsoleApp;

namespace GenericConsoleApp.UnitTests
{
    [TestClass]
    public class CustomListTest
    {
        string ArrayToString<T>(T[] t) where T : struct
        {
            string arrayAsString = "";
            for (int i = 0; i < t.Length; i++)
            {
                arrayAsString += $"{t[i]}";
                if (i < t.Length - 1)
                {
                    arrayAsString += ", ";
                }
            }
            return arrayAsString;
        }

        public bool TheyAreEqual(Person p1, Person p2)
        {
            if (p1.FirstName.Equals(p2.FirstName) && p1.LastName.Equals(p2.LastName) && p1.Id.Equals(p2.Id))
            {
                return true;
            }
            return false;
        }

        [TestMethod]
        public void Add_210_Expect210()
        {
            //Arrange
            var customList = new CustomList<int>();
            string actual, expected = "210";

            //Act
            customList.Add(210);
            actual = customList.ToString();

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Add_220After210_Expect220then210()
        {
            //Arrange
            var customList = new CustomList<int>();
            string actual, expected = "210, 220";

            //Act
            customList.Add(210);
            customList.Add(220);
            actual = customList.ToString();

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Add_220then210then230_ExpectCount3()
        {
            //Arrange
            var customList = new CustomList<int>();
            int actual, expected = 3;

            //Act
            customList.Add(210);
            customList.Add(220);
            customList.Add(230);
            actual = customList.Count;

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void AddRange_ExpectCorrectString()
        {
            //Arrange
            CustomList<int> customList = new CustomList<int>();
            customList.Add(21);
            customList.Add(35);
            customList.Add(20);
            customList.Add(19);
            customList.Add(44);
            string actual, expected = "21, 35, 20, 19, 44, 25, 28, 79";

            //Act
            customList.AddRange(new int[] { 25, 28, 79 });
            actual = customList.ToString();

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void AddRange_ExpectCorrectCount()
        {
            //Arrange
            CustomList<int> customList = new CustomList<int>();
            customList.Add(21);
            customList.Add(35);
            customList.Add(20);
            customList.Add(19);
            customList.Add(44);
            int actual, expected = 8;

            //Act
            customList.AddRange(new int[] { 25, 28, 79 });
            actual = customList.Count;

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Clear_ExpectCorrectToString()
        {
            //Arrange
            CustomList<int> customList = new CustomList<int>();
            customList.AddRange(new int[] { 2, 4, 3, 5, 6, 54, 56, 76, 77, 87, 88, 98, 890 });
            string actual, expected = "";

            //Act
            customList.Clear();
            actual = customList.ToString();

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Clear_ExpectCorrectCount()
        {
            //Arrange
            CustomList<int> customList = new CustomList<int>();
            customList.AddRange(new int[] { 2, 4, 3, 5, 6, 54, 56, 76, 77, 87, 88, 98, 890 });
            int actual, expected = 0;

            //Act
            customList.Clear();
            actual = customList.Count;

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Contains_2_ExpectTrue()
        {
            //Arrange
            var customList = new CustomList<int>();
            customList.AddRange(new int[] { 2, 4, 3, 5, 6, 5, 8, 7, 5, 4, 9, 0, 2, 4, 5, 6, 6, 5, 3, 7, 8, 9, 12, 34, 54, 56, 76, 77, 87, 88, 98, 890 });
            bool actual, expected = true;

            //Act
            actual = customList.Contains(2);

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Contains_890_ExpectTrue()
        {
            //Arrange
            var customList = new CustomList<int>();
            customList.AddRange(new int[] { 2, 4, 3, 5, 6, 5, 8, 7, 5, 4, 9, 0, 2, 4, 5, 6, 6, 5, 3, 7, 8, 9, 12, 34, 54, 56, 76, 77, 87, 88, 98, 890 });
            bool actual, expected = true;

            //Act
            actual = customList.Contains(890);

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Contains_6_ExpectTrue()
        {
            //Arrange
            var customList = new CustomList<int>();
            customList.AddRange(new int[] { 2, 4, 3, 5, 6, 5, 8, 7, 5, 4, 9, 0, 2, 4, 5, 6, 6, 5, 3, 7, 8, 9, 12, 34, 54, 56, 76, 77, 87, 88, 98, 890 });
            bool actual, expected = true;
            //Act

            actual = customList.Contains(6);

            //Assert

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Contains_210_ExpectFalse()
        {
            //Arrange
            var customList = new CustomList<int>();
            customList.AddRange(new int[] { 2, 4, 3, 5, 6, 5, 8, 7, 5, 4, 9, 0, 2, 4, 5, 6, 6, 5, 3, 7, 8, 9, 12, 34, 54, 56, 76, 77, 87, 88, 98, 890 });
            bool actual, expected = false;
            
            //Act
            actual = customList.Contains(210);

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Contains_21_ExpectFalse()
        {
            //Arrange
            var customList = new CustomList<int>();
            customList.AddRange(new int[] { 2, 4, 3, 5, 6, 5, 8, 7, 5, 4, 9, 0, 2, 4, 5, 6, 6, 5, 3, 7, 8, 9, 12, 34, 54, 56, 76, 77, 87, 88, 98, 890 });
            bool actual, expected = false;

            //Act
            actual = customList.Contains(21);

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Contains_JohnDoe_ExpectTrue()
        {
            //Arrange
            var customList = new CustomList<Person>();
            customList.IsEqualDelegate = TheyAreEqual;
            customList.AddRange(new Person[] { new Person("John", "Doe", 89), new Person("Paul", "Wang", 54), new Person("Eric", "Faulk", 19), new Person("John", "Doe", 112), new Person("Jane", "Katz", 73) });
            bool actual, expected = true;

            //Act
            actual = customList.Contains(new Person("John", "Doe", 89));

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Contains_PaulWang_ExpectTrue()
        {
            //Arrange
            var customList = new CustomList<Person>();
            customList.IsEqualDelegate = TheyAreEqual;
            customList.AddRange(new Person[] { new Person("John", "Doe", 89), new Person("Paul", "Wang", 54), new Person("Eric", "Faulk", 19), new Person("John", "Doe", 112), new Person("Jane", "Katz", 73) });
            bool actual, expected = true;
            
            //Act
            actual = customList.Contains(new Person("Paul", "Wang", 54));

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Contains_JanetLin_ExpectFalse()
        {
            //Arrange
            var customList = new CustomList<Person>();
            customList.AddRange(new Person[] { new Person("John", "Doe", 89), new Person("Paul", "Wang", 54), 
                                               new Person("Eric", "Faulk", 19), new Person("John", "Doe", 112), 
                                               new Person("Jane", "Katz", 73) });
            bool actual, expected = false;

            //Act
            actual = customList.Contains(new Person("Janet", "Lin", 64));

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Contains_MikaDoe_ExpectFalse()
        {
            //Arrange
            var customList = new CustomList<Person>();
            customList.AddRange(new Person[] { new Person("John", "Doe", 89), new Person("Paul", "Wang", 54), new Person("Eric", "Faulk", 19), new Person("John", "Doe", 112), new Person("Jane", "Katz", 73) });
            bool actual, expected = false;

            //Act
            actual = customList.Contains(new Person("Mika", "Doe", 64));

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void CopyTo_WithoutIndexOrCount__ExpectCorrectString()
        {
            //Arrange
            CustomList<int> customList = new CustomList<int>();
            customList.AddRange(new int[] { 2, 4, 3, 5, 6, 5, 8, 7, 5, 4, 9, 0, 2, 4, 5, 6, 6, 5, 3 });
            string actual, expected = "2, 4, 3, 5, 6, 5, 8, 7, 5, 4, 9, 0, 2, 4, 5, 6, 6, 5, 3";

            //Act
            var array = customList.CopyTo(new int[19]);
            actual = ArrayToString(array);

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void CopyTo_WithArrayIndex0__ExpectCorrectString()
        {
            //Arrange
            CustomList<int> customList = new CustomList<int>();
            customList.AddRange(new int[] { 2, 4, 3, 5, 6, 5, 8, 7, 5, 4, 9, 0, 2, 4, 5, 6, 6, 5, 3 });
            string actual, expected = "2, 4, 3, 5, 6, 5, 8, 7, 5, 4, 9, 0, 2, 4, 5, 6, 6, 5, 3, 0, 0, 0, 0, 0, 0";

            //Act
            var array = customList.CopyTo(new int[25], 0);
            actual = ArrayToString(array);

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void CopyTo_WithArrayIndex6__ExpectCorrectString()
        {
            //Arrange
            CustomList<int> customList = new CustomList<int>();
            customList.AddRange(new int[] { 2, 4, 3, 5, 6, 5, 8, 7, 5, 4, 9, 0, 2, 4, 5, 6, 6, 5, 3 });
            string actual, expected = "0, 0, 0, 0, 0, 0, 2, 4, 3, 5, 6, 5, 8, 7, 5, 4, 9, 0, 2, 4, 5, 6, 6, 5, 3";

            //Act
            var array = customList.CopyTo(new int[25], 6);
            actual = ArrayToString(array);

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void CopyTo_WithArrayIndex2__ExpectCorrectString()
        {
            //Arrange
            CustomList<int> customList = new CustomList<int>();
            customList.AddRange(new int[] { 2, 4, 3, 5, 6, 5, 8, 7, 5, 4, 9, 0, 2, 4, 5, 6, 6, 5, 3 });
            string actual, expected = "0, 0, 2, 4, 3, 5, 6, 5, 8, 7, 5, 4, 9, 0, 2, 4, 5, 6, 6, 5, 3, 0, 0, 0, 0";

            //Act
            var array = customList.CopyTo(new int[25], 2);
            actual = ArrayToString(array);

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void CopyTo_WithListIndex2ArrayIndex2Count5__ExpectCorrectString()
        {
            //Arrange
            CustomList<int> customList = new CustomList<int>();
            customList.AddRange(new int[] { 2, 4, 3, 5, 6, 5, 8, 7, 5, 4, 9, 0, 2, 4, 5, 6, 6, 5, 3 });
            string actual, expected = "0, 0, 3, 5, 6, 5, 8, 0, 0, 0, 0";

            //Act
            var array = customList.CopyTo(2, new int[11], 2, 5);
            actual = ArrayToString(array);

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void CopyTo_WithListIndex0ArrayIndex5Count6__ExpectCorrectString()
        {
            //Arrange
            CustomList<int> customList = new CustomList<int>();
            customList.AddRange(new int[] { 2, 4, 3, 5, 6, 5, 8, 7, 5, 4, 9, 0, 2, 4, 5, 6, 6, 5, 3 });
            string actual, expected = "0, 0, 0, 0, 0, 2, 4, 3, 5, 6, 5";

            //Act
            var array = customList.CopyTo(0, new int[11], 5, 6);
            actual = ArrayToString(array);

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void CopyTo_WithListIndex10ArrayIndex0Count9__ExpectCorrectString()
        {
            //Arrange
            CustomList<int> customList = new CustomList<int>();
            customList.AddRange(new int[] { 2, 4, 3, 5, 6, 5, 8, 7, 5, 4, 9, 0, 2, 4, 5, 6, 6, 5, 3 });
            string actual, expected = "9, 0, 2, 4, 5, 6, 6, 5, 3, 0, 0";

            //Act
            var array = customList.CopyTo(10, new int[11], 0, 9);
            actual = ArrayToString(array);

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Exists_LastNameIsSchultzExpectTrue()
        {
            //Arrange
            var customList = new CustomList<Person>();
            customList.AddRange(new Person[] { new Person("John", "Doe", 19), new Person("Paul", "Wang", 54),
                                new Person("Eric", "Faulk", 19), new Person("John", "Doe", 112),
                                new Person("Jane", "Katz", 73),  new Person("Eric", "Faulk", 19),
                                new Person("Jason", "Bourne", 42),  new Person("Eric", "Faulk", 19),
                                new Person("Kate", "Chen", 55), new Person("Eric", "Bates", 39),
                                new Person("Laura", "Schultz", 132)});

            bool actual, expected = true;

            //Act
            actual = customList.Exists(p=>p.LastName=="Schultz");

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Exists_FirstNameIsJackExpectFalse()
        {
            //Arrange
            var customList = new CustomList<Person>();
            customList.AddRange(new Person[] { new Person("John", "Doe", 19), new Person("Paul", "Wang", 54),
                                new Person("Eric", "Faulk", 19), new Person("John", "Doe", 112),
                                new Person("Jane", "Katz", 73),  new Person("Eric", "Faulk", 19),
                                new Person("Jason", "Bourne", 42),  new Person("Eric", "Faulk", 19),
                                new Person("Kate", "Chen", 55), new Person("Eric", "Bates", 39),
                                new Person("Laura", "Schultz", 132)});

            bool actual, expected = false;

            //Act
            actual = customList.Exists(p => p.FirstName == "Jack");

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Find_JanetLin_ExpectNull()
        {
            //Arrange
            var customList = new CustomList<Person>();
            customList.AddRange(new Person[] { new Person("John", "Doe", 19), new Person("Paul", "Wang", 54),
                                new Person("Eric", "Faulk", 19), new Person("John", "Doe", 112),
                                new Person("Jane", "Katz", 73),  new Person("Eric", "Faulk", 19),
                                new Person("Jason", "Bourne", 42),  new Person("Eric", "Faulk", 19),
                                new Person("Kate", "Chen", 55), new Person("Eric", "Bates", 39),
                                new Person("Laura", "Schultz", 132)});
            Person actual, expected = null;

            //Act
            actual = customList.Find(p => (p.FirstName == "Janet" && p.LastName == "Lin"));

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Find_LauraShultz_ExpectLauraSchultz()
        {
            //Arrange
            var customList = new CustomList<Person>();
            customList.AddRange(new Person[] { new Person("John", "Doe", 19), new Person("Paul", "Wang", 54),
                                new Person("Eric", "Faulk", 19), new Person("John", "Doe", 112),
                                new Person("Jane", "Katz", 73),  new Person("Eric", "Faulk", 19),
                                new Person("Jason", "Bourne", 42),  new Person("Eric", "Faulk", 19),
                                new Person("Kate", "Chen", 55), new Person("Eric", "Bates", 39),
                                new Person("Laura", "Schultz", 132)});
            string actual, expected = "Laura Schultz 132";
            actual = customList.Find(p => (p.FirstName == "Laura" && p.LastName == "Schultz")).ToString();

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Find_Id19_ExpectJohnDoe()
        {
            //Arrange
            var customList = new CustomList<Person>();
            customList.AddRange(new Person[] { new Person("John", "Doe", 19), new Person("Paul", "Wang", 54),
                                new Person("Eric", "Faulk", 19), new Person("John", "Doe", 112),
                                new Person("Jane", "Katz", 73),  new Person("Eric", "Faulk", 19),
                                new Person("Jason", "Bourne", 42),  new Person("Eric", "Faulk", 19),
                                new Person("Kate", "Chen", 55), new Person("Eric", "Bates", 39),
                                new Person("Laura", "Schultz", 132)});
            string actual, expected = "John Doe 19";

            //Act
            actual = customList.Find(p => (p.Id == 19)).ToString();

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void FindIndex_JanetLin_ExpectNegativeOne()
        {
            //Arrange
            var customList = new CustomList<Person>();
            customList.AddRange(new Person[] { new Person("John", "Doe", 19), new Person("Paul", "Wang", 54), 
                                new Person("Eric", "Faulk", 19), new Person("John", "Doe", 112), 
                                new Person("Jane", "Katz", 73),  new Person("Eric", "Faulk", 19), 
                                new Person("Jason", "Bourne", 42),  new Person("Eric", "Faulk", 19), 
                                new Person("Kate", "Chen", 55), new Person("Eric", "Bates", 39), 
                                new Person("Laura", "Schultz", 132)});
            int actual, expected = -1;

            //Act
            actual = customList.FindIndex(p=>(p.FirstName=="Janet" && p.LastName=="Lin"));

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void FindIndex_EricFaulk_ExpectTwo()
        {
            //Arrange
            var customList = new CustomList<Person>();
            customList.AddRange(new Person[] { new Person("John", "Doe", 19), new Person("Paul", "Wang", 54),
                                new Person("Eric", "Faulk", 19), new Person("John", "Doe", 112),
                                new Person("Jane", "Katz", 73),  new Person("Eric", "Faulk", 19),
                                new Person("Jason", "Bourne", 42),  new Person("Eric", "Faulk", 19),
                                new Person("Kate", "Chen", 55), new Person("Eric", "Bates", 39),
                                new Person("Laura", "Schultz", 132)});
            int actual, expected = 2;

            //Act
            actual = customList.FindIndex(p => (p.FirstName == "Eric" && p.LastName == "Faulk"));

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void FindIndex_EricFaulkStartAt3_ExpectFive()
        {
            //Arrange
            var customList = new CustomList<Person>();
            customList.AddRange(new Person[] { new Person("John", "Doe", 19), new Person("Paul", "Wang", 54),
                                new Person("Eric", "Faulk", 19), new Person("John", "Doe", 112),
                                new Person("Jane", "Katz", 73),  new Person("Eric", "Faulk", 19),
                                new Person("Jason", "Bourne", 42),  new Person("Eric", "Faulk", 19),
                                new Person("Kate", "Chen", 55), new Person("Eric", "Bates", 39),
                                new Person("Laura", "Schultz", 132)});
            int actual, expected = 5;

            //Act
            actual = customList.FindIndex(3, p => (p.FirstName == "Eric" && p.LastName == "Faulk"));

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void FindAll_IdIs19OrLastNameIsShultz_ExpectCorrectString()
        {
            //Arrange
            var customList = new CustomList<Person>();
            customList.AddRange(new Person[] { new Person("John", "Doe", 19), new Person("Paul", "Wang", 54),
                                new Person("Eric", "Faulk", 19), new Person("John", "Doe", 112),
                                new Person("Jane", "Katz", 73),  new Person("Eric", "Faulk", 19),
                                new Person("Jason", "Bourne", 42),  new Person("Eric", "Faulk", 19),
                                new Person("Kate", "Chen", 55), new Person("Eric", "Bates", 39),
                                new Person("Laura", "Schultz", 132)});

            string actual, expected = "John Doe 19, Eric Faulk 19, Eric Faulk 19, Eric Faulk 19, Laura Schultz 132";

            //Act
            var returnedList = customList.FindAll(p => (p.Id == 19 || p.LastName == "Schultz"));
            actual = returnedList.ToString();

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void FindIndex_JasonBourneStartAt1Count6_ExpectSix()
        {
            //Arrange
            var customList = new CustomList<Person>();
            customList.AddRange(new Person[] { new Person("John", "Doe", 19), new Person("Paul", "Wang", 54),
                                new Person("Eric", "Faulk", 19), new Person("John", "Doe", 112),
                                new Person("Jane", "Katz", 73),  new Person("Eric", "Faulk", 19),
                                new Person("Jason", "Bourne", 42),  new Person("Eric", "Faulk", 19),
                                new Person("Kate", "Chen", 55), new Person("Eric", "Bates", 39),
                                new Person("Laura", "Schultz", 132)});
            int actual, expected = 6;

            //Act
            actual = customList.FindIndex(1, 6, p => (p.FirstName == "Jason" && p.LastName == "Bourne"));

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void FindIndex_JasonBourneStartAt1Count5_ExpectNegativeOne()
        {
            //Arrange
            var customList = new CustomList<Person>();
            customList.AddRange(new Person[] { new Person("John", "Doe", 19), new Person("Paul", "Wang", 54),
                                new Person("Eric", "Faulk", 19), new Person("John", "Doe", 112),
                                new Person("Jane", "Katz", 73),  new Person("Eric", "Faulk", 19),
                                new Person("Jason", "Bourne", 42),  new Person("Eric", "Faulk", 19),
                                new Person("Kate", "Chen", 55), new Person("Eric", "Bates", 39),
                                new Person("Laura", "Schultz", 132)});
            int actual, expected = -1;

            //Act
            actual = customList.FindIndex(1, 5, p => (p.FirstName == "Jason" && p.LastName == "Bourne"));

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void FindIndex_LauraSchultzStartAt6Count5_ExpectSix()
        {
            //Arrange
            var customList = new CustomList<Person>();
            customList.AddRange(new Person[] { new Person("John", "Doe", 19), new Person("Paul", "Wang", 54),
                                new Person("Eric", "Faulk", 19), new Person("John", "Doe", 112),
                                new Person("Jane", "Katz", 73),  new Person("Eric", "Faulk", 19),
                                new Person("Jason", "Bourne", 42),  new Person("Eric", "Faulk", 19),
                                new Person("Kate", "Chen", 55), new Person("Eric", "Bates", 39),
                                new Person("Laura", "Schultz", 132)});
            int actual, expected = 10;

            //Act
            actual = customList.FindIndex(6, 5, p => (p.FirstName == "Laura"));

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void FindIndex_LauraSchultzStartAt6Count4_ExpectNegativeOne()
        {
            //Arrange
            var customList = new CustomList<Person>();
            customList.AddRange(new Person[] { new Person("John", "Doe", 19), new Person("Paul", "Wang", 54),
                                new Person("Eric", "Faulk", 19), new Person("John", "Doe", 112),
                                new Person("Jane", "Katz", 73),  new Person("Eric", "Faulk", 19),
                                new Person("Jason", "Bourne", 42),  new Person("Eric", "Faulk", 19),
                                new Person("Kate", "Chen", 55), new Person("Eric", "Bates", 39),
                                new Person("Laura", "Schultz", 132)});
            int actual, expected = -1;

            //Act
            actual = customList.FindIndex(6, 4, p => (p.Id == 132));

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void FindLast_LastIsAtTheBeginning_ExpectCorrectString()
        {
            //Arrange
            var customList = new CustomList<Person>();
            customList.AddRange(new Person[] { new Person("John", "Doe", 34), new Person("Paul", "Wang", 54),
                                new Person("Eric", "Faulk", 19), new Person("John", "Doe", 112),
                                new Person("Jane", "Katz", 73),  new Person("Eric", "Faulk", 19),
                                new Person("Jason", "Bourne", 42),  new Person("Abigail", "Faulk", 19),
                                new Person("Kate", "Chen", 55), new Person("Eric", "Bates", 39),
                                new Person("Laura", "Schultz", 132)});

            string actual, expected = "John Doe 34";

            //Act
            var returnedItem = customList.FindLast(p => (p.Id == 34));
            actual = returnedItem.ToString();

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void FindLast_LastIsInTheMiddle_ExpectCorrectString()
        {
            //Arrange
            var customList = new CustomList<Person>();
            customList.AddRange(new Person[] { new Person("John", "Doe", 19), new Person("Paul", "Wang", 54),
                                new Person("Eric", "Faulk", 19), new Person("John", "Doe", 112),
                                new Person("Jane", "Katz", 73),  new Person("Eric", "Faulk", 19),
                                new Person("Jason", "Bourne", 42),  new Person("Abigail", "Faulk", 19),
                                new Person("Kate", "Chen", 55), new Person("Eric", "Bates", 39),
                                new Person("Laura", "Schultz", 132)});

            string actual, expected = "Abigail Faulk 19";

            //Act
            var returnedItem = customList.FindLast(p => (p.Id == 19 || p.LastName == "Abigail"));
            actual = returnedItem.ToString();

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void FindLast_LastIsAtTheEnd_ExpectCorrecString()
        {
            //Arrange
            var customList = new CustomList<Person>();
            customList.AddRange(new Person[] { new Person("John", "Doe", 19), new Person("Paul", "Wang", 54),
                                new Person("Eric", "Faulk", 19), new Person("John", "Doe", 112),
                                new Person("Jane", "Katz", 73),  new Person("Eric", "Faulk", 19),
                                new Person("Jason", "Bourne", 42),  new Person("Eric", "Faulk", 19),
                                new Person("Kate", "Chen", 55), new Person("Eric", "Bates", 39),
                                new Person("Laura", "Schultz", 132)});

            string actual, expected = "Laura Schultz 132";

            //Act
            var returnedItem = customList.FindLast(p => (p.Id == 19 || p.FirstName == "Laura"));
            actual = returnedItem.ToString();

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void FindLastIndex_WithoutIndexOrCountJanetLin_ExpectNegativeOne()
        {
            //Arrange
            var customList = new CustomList<Person>();
            customList.AddRange(new Person[] { new Person("John", "Doe", 19), new Person("Paul", "Wang", 54),
                                new Person("Eric", "Faulk", 19), new Person("John", "Doe", 112),
                                new Person("Jane", "Katz", 73),  new Person("Eric", "Faulk", 19),
                                new Person("Jason", "Bourne", 42),  new Person("Eric", "Faulk", 19),
                                new Person("Kate", "Chen", 55), new Person("Eric", "Bates", 39),
                                new Person("Laura", "Schultz", 132)});
            int actual, expected = -1;

            //Act
            actual = customList.FindLastIndex(p => (p.FirstName == "Janet" && p.LastName == "Lin"));

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void FindLastIndex_WithoutIndexOrCountLauraSchultz_Expect10()
        {
            //Arrange
            var customList = new CustomList<Person>();
            customList.AddRange(new Person[] { new Person("John", "Doe", 19), new Person("Paul", "Wang", 54),
                                new Person("Eric", "Faulk", 19), new Person("John", "Doe", 112),
                                new Person("Jane", "Katz", 73),  new Person("Eric", "Faulk", 19),
                                new Person("Jason", "Bourne", 42),  new Person("Eric", "Faulk", 19),
                                new Person("Kate", "Chen", 55), new Person("Eric", "Bates", 39),
                                new Person("Laura", "Schultz", 132)});
            int actual, expected = 10;

            //Act
            actual = customList.FindLastIndex(p => (p.LastName == "Schultz" || p.FirstName == "Laura"));

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void FindLastIndex_WithoutIndexOrCountEric19_Expect7()
        {
            //Arrange
            var customList = new CustomList<Person>();
            customList.AddRange(new Person[] { new Person("John", "Doe", 19), new Person("Paul", "Wang", 54),
                                new Person("Eric", "Faulk", 19), new Person("John", "Doe", 112),
                                new Person("Jane", "Katz", 73),  new Person("Eric", "Faulk", 19),
                                new Person("Jason", "Bourne", 42),  new Person("Eric", "Faulk", 19),
                                new Person("Kate", "Chen", 55), new Person("Eric", "Bates", 39),
                                new Person("Laura", "Schultz", 132)});
            int actual, expected = 9;

            //Act
            actual = customList.FindLastIndex(p => (p.Id == 19 || p.FirstName == "Eric"));

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void FindLastIndex_WithIndex4JanetLin_ExpectNegativeOne()
        {
            //Arrange
            var customList = new CustomList<Person>();
            customList.AddRange(new Person[] { new Person("John", "Doe", 19), new Person("Paul", "Wang", 54),
                                new Person("Eric", "Faulk", 19), new Person("John", "Doe", 112),
                                new Person("Jane", "Katz", 73),  new Person("Eric", "Faulk", 19),
                                new Person("Jason", "Bourne", 42),  new Person("Eric", "Faulk", 19),
                                new Person("Kate", "Chen", 55), new Person("Eric", "Bates", 39),
                                new Person("Laura", "Schultz", 132)});
            int actual, expected = -1;

            //Act
            actual = customList.FindLastIndex(4, p => (p.FirstName == "Janet" && p.LastName == "Lin"));

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void FindLastIndex_WithIndex10LauraSchultz_Expect10()
        {
            //Arrange
            var customList = new CustomList<Person>();
            customList.AddRange(new Person[] { new Person("John", "Doe", 19), new Person("Paul", "Wang", 54),
                                new Person("Eric", "Faulk", 19), new Person("John", "Doe", 112),
                                new Person("Jane", "Katz", 73),  new Person("Eric", "Faulk", 19),
                                new Person("Jason", "Bourne", 42),  new Person("Eric", "Faulk", 19),
                                new Person("Kate", "Chen", 55), new Person("Eric", "Bates", 39),
                                new Person("Laura", "Schultz", 132)});
            int actual, expected = 10;

            //Act
            actual = customList.FindLastIndex(10, p => (p.LastName == "Schultz" || p.FirstName == "Laura"));

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void FindLastIndex_WithIndex6Faulk_Expect5()
        {
            //Arrange
            var customList = new CustomList<Person>();
            customList.AddRange(new Person[] { new Person("John", "Doe", 19), new Person("Paul", "Wang", 54),
                                new Person("Eric", "Faulk", 19), new Person("John", "Doe", 112),
                                new Person("Jane", "Katz", 73),  new Person("Eric", "Faulk", 19),
                                new Person("Jason", "Bourne", 42),  new Person("Eric", "Faulk", 19),
                                new Person("Kate", "Chen", 55), new Person("Eric", "Bates", 39),
                                new Person("Laura", "Schultz", 132)});
            int actual, expected = 5;

            //Act
            actual = customList.FindLastIndex(6, p => p.LastName == "Faulk");

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void FindLastIndex_WithIndex11Count7_Expect9()
        {
            //Arrange
            CustomList<int> customList = new CustomList<int>();
            customList.AddRange(new int[] { 2, 4, 3, 5, 6, 5, 8, 7, 5, 4, 9, 0, 2, 4, 5, 6, 6, 5, 3 });
            int actual, expected = 9;

            //Act
            actual = customList.FindLastIndex(11, 7, p => p == 4);

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void FindLastIndex_WithIndex17Count14_Expect16()
        {
            //Arrange
            CustomList<int> customList = new CustomList<int>();
            customList.AddRange(new int[] { 2, 4, 3, 5, 6, 5, 8, 7, 5, 4, 9, 0, 2, 4, 5, 6, 6, 5, 3 });
            int actual, expected = 16;

            //Act
            actual = customList.FindLastIndex(17, 14, p => p == 6);

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void FindLastIndex_WithIndex14Count10_ExpectNegativeOne()
        {
            //Arrange
            CustomList<int> customList = new CustomList<int>();
            customList.AddRange(new int[] { 2, 4, 3, 5, 6, 5, 8, 7, 5, 4, 9, 0, 2, 4, 5, 6, 6, 5, 3 });
            int actual, expected = -1;

            //Act
            actual = customList.FindLastIndex(14, 10, p => p == 6);

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void FindLastIndex_WithIndex14Count12_Expect4()
        {
            //Arrange
            CustomList<int> customList = new CustomList<int>();
            customList.AddRange(new int[] { 2, 4, 3, 5, 6, 5, 8, 7, 5, 4, 9, 0, 2, 4, 5, 6, 6, 5, 3 });
            int actual, expected = 4;

            //Act
            actual = customList.FindLastIndex(14, 12, p => p == 6);

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ForEach_ChangeIds_ExpectCorrectToString()
        {
            //Arrange
            var customList = new CustomList<Person>();
            customList.AddRange(new Person[] { new Person("John", "Doe", 19), new Person("Paul", "Wang", 54),
                                new Person("Eric", "Faulk", 19), new Person("John", "Doe", 112),
                                new Person("Jane", "Katz", 73),  new Person("Eric", "Faulk", 19),
                                new Person("Jason", "Bourne", 42),  new Person("Eric", "Faulk", 19),
                                new Person("Kate", "Chen", 55), new Person("Eric", "Bates", 39),
                                new Person("Laura", "Schultz", 132)});

            string actual, expected = "John Doe 44, Paul Wang 54, Eric Faulk 44, John Doe 112, Jane Katz 73, " +
                "Eric Faulk 44, Jason Bourne 42, Eric Faulk 44, Kate Chen 55, Eric Bates 39, Laura Schultz 132";

            //Act
            customList.ForEach(p => p.Id = p.Id == 19 ? 44 : p.Id);
            actual = customList.ToString();

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void GetRange_4To8_ExpectCorrectToString()
        {
            //Arrange
            CustomList<int> customList = new CustomList<int>();
            customList.AddRange(new int[] { 2, 4, 3, 5, 6, 54, 56, 76, 77, 87, 88, 98, 890 });
            string actual, expected = "6, 54, 56, 76, 77";

            //Act
            var returnedList = customList.GetRange(4, 5);
            actual = returnedList.ToString();

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void GetRange_4To8_ExpectCorrectCount()
        {
            //Arrange
            CustomList<int> customList = new CustomList<int>();
            customList.AddRange(new int[] { 2, 4, 3, 5, 6, 54, 56, 76, 77, 87, 88, 98, 890 });
            int actual, expected = 13;

            //Act
            customList.GetRange(4, 5);
            actual = customList.Count;

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void GetRange_0To4_ExpectCorrectToString()
        {
            //Arrange
            CustomList<int> customList = new CustomList<int>();
            customList.AddRange(new int[] { 2, 4, 3, 5, 6, 54, 56, 76, 77, 87, 88, 98, 890 });
            string actual, expected = "2, 4, 3, 5, 6";

            //Act
            var returnedList = customList.GetRange(0, 5);
            actual = returnedList.ToString();

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void GetRange_0To4_ExpectCorrectReturnedListCount()
        {
            //Arrange
            CustomList<int> customList = new CustomList<int>();
            customList.AddRange(new int[] { 2, 4, 3, 5, 6, 54, 56, 76, 77, 87, 88, 98, 890 });
            int actual, expected = 5;

            //Act
            var returnedList = customList.GetRange(0, 5);
            actual = returnedList.Count;

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void GetRange_8ToEnd_ExpectCorrectToString()
        {
            //Arrange
            CustomList<int> customList = new CustomList<int>();
            customList.AddRange(new int[] { 2, 4, 3, 5, 6, 54, 56, 76, 77, 87, 88, 98, 890 });
            string actual, expected = "77, 87, 88, 98, 890";

            //Act
            var returnedList = customList.GetRange(8, 5);
            actual = returnedList.ToString();

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Indexer_GetVaueAtIndex0_Expect2()
        {
            //Arrange
            CustomList<int> customList = new CustomList<int>();
            customList.AddRange(new int[] { 2, 4, 3, 5, 6, 54, 56, 76, 77, 87, 88, 98, 890 });
            int actual, expected = 2;

            //Act
            actual = customList[0];

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Indexer_GetVaueAtIndex4_Expect6()
        {
            //Arrange
            CustomList<int> customList = new CustomList<int>();
            customList.AddRange(new int[] { 2, 4, 3, 5, 6, 54, 56, 76, 77, 87, 88, 98, 890 });
            int actual, expected = 6;

            //Act
            actual = customList[4];

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Indexer_GetVaueAtIndex12_Expect890()
        {
            //Arrange
            CustomList<int> customList = new CustomList<int>();
            customList.AddRange(new int[] { 2, 4, 3, 5, 6, 54, 56, 76, 77, 87, 88, 98, 890 });
            int actual, expected = 890;

            //Act
            actual = customList[12];

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Indexer_SetValueAtIndex0_ExpectCorrectToString()
        {
            //Arrange
            CustomList<int> customList = new CustomList<int>();
            customList.AddRange(new int[] { 2, 4, 3, 5, 6, 54, 56, 76, 77, 87, 88, 98, 890 });
            string actual, expected = "1000, 4, 3, 5, 6, 54, 56, 76, 77, 87, 88, 98, 890";

            //Act
            customList[0] = 1000;
            actual = customList.ToString();

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Indexer_SetValueAtIndex4_ExpectCorrectToString()
        {
            //Arrange
            CustomList<int> customList = new CustomList<int>();
            customList.AddRange(new int[] { 2, 4, 3, 5, 6, 54, 56, 76, 77, 87, 88, 98, 890 });
            string actual, expected = "2, 4, 3, 5, 1000, 54, 56, 76, 77, 87, 88, 98, 890";

            //Act
            customList[4] = 1000;
            actual = customList.ToString();

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Indexer_SetValueAtIndex12_ExpectCorrectToString()
        {
            //Arrange
            CustomList<int> customList = new CustomList<int>();
            customList.AddRange(new int[] { 2, 4, 3, 5, 6, 54, 56, 76, 77, 87, 88, 98, 890 });
            string actual, expected = "2, 4, 3, 5, 6, 54, 56, 76, 77, 87, 88, 98, 1000";

            //Act
            customList[12] = 1000;
            actual = customList.ToString();

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void IndexOf_210_ExpectNeghativeOne()
        {
            //Arrange
            var customList = new CustomList<int>();
            customList.AddRange(new int[] { 2, 4, 3, 5, 6, 5, 8, 7, 5, 4, 9, 0, 2, 4, 5, 6, 6, 5, 3, 7, 8, 9, 12, 34, 54, 56, 76, 77, 87, 88, 98, 890 });
            int actual, expected = -1;

            //Act
            actual = customList.IndexOf(210);

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void IndexOf_890_Expect31()
        {
            //Arrange
            var customList = new CustomList<int>();
            customList.AddRange(new int[] { 2, 4, 3, 5, 6, 5, 8, 7, 5, 4, 9, 0, 2, 4, 5, 6, 6, 5, 3, 7, 8, 9, 12, 34, 54, 56, 76, 77, 87, 88, 98, 890 });
            int actual, expected = 31;

            //Act
            actual = customList.IndexOf(890);

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void IndexOf_2_ExpectZero()
        {
            //Arrange
            var customList = new CustomList<int>();
            customList.AddRange(new int[] { 2, 4, 3, 5, 6, 5, 8, 7, 5, 4, 9, 0, 2, 4, 5, 6, 6, 5, 3, 7, 8, 9, 12, 34, 54, 56, 76, 77, 87, 88, 98, 890 });
            int actual, expected = 0;

            //Act
            actual = customList.IndexOf(2);

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void IndexOf_0_Expect11()
        {
            //Arrange
            var customList = new CustomList<int>();
            customList.AddRange(new int[] { 2, 4, 3, 5, 6, 5, 8, 7, 5, 4, 9, 0, 2, 4, 5, 6, 6, 5, 3, 7, 8, 9, 12, 34, 54, 56, 76, 77, 87, 88, 98, 890 });
            int actual, expected = 11;

            //Act
            actual = customList.IndexOf(0);

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void IndexOf_6_Expect4()
        {
            //Arrange
            var customList = new CustomList<int>();
            customList.AddRange(new int[] { 2, 4, 3, 5, 6, 5, 8, 7, 5, 4, 9, 0, 2, 4, 5, 6, 6, 5, 3, 7, 8, 9, 12, 34, 54, 56, 76, 77, 87, 88, 98, 890 });
            int actual, expected = 4;

            //Act
            actual = customList.IndexOf(6);

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void IndexOf_0StartAt12_ExpectNegativeOne()
        {
            //Arrange
            CustomList<int> customList = new CustomList<int>();
            customList.AddRange(new int[] { 2, 4, 3, 5, 6, 5, 8, 7, 5, 4, 9, 0, 2,
                4, 5, 6, 6, 5, 3, 7, 8, 9, 12, 34, 54, 56, 76, 77, 87, 88, 98, 890 });
            int actual, expected = -1;

            //Act
            actual = customList.IndexOf(0, 12);

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void IndexOf_6StartAt9_Expect15()
        {
            //Arrange
            CustomList<int> customList = new CustomList<int>();
            customList.AddRange(new int[] { 2, 4, 3, 5, 6, 5, 8, 7, 5, 4, 9, 0, 2, 4,
                5, 6, 6, 5, 3, 7, 8, 9, 12, 34, 54, 56, 76, 77, 87, 88, 98, 890 });
            int actual, expected = 15;

            //Act
            actual = customList.IndexOf(6, 9);

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void IndexOf_890StartAt12Count19_ExpectNegativeOne()
        {
            //Arrange
            CustomList<int> customList = new CustomList<int>();
            customList.AddRange(new int[] { 2, 4, 3, 5, 6, 5, 8, 7, 5, 4, 9, 0, 2,
                4, 5, 6, 6, 5, 3, 7, 8, 9, 12, 34, 54, 56, 76, 77, 87, 88, 98, 890 });
            int actual, expected = -1;

            //Act
            actual = customList.IndexOf(890, 12, 19);

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void IndexOf_890StartAt12Count20_Expect31()
        {
            //Arrange
            CustomList<int> customList = new CustomList<int>();
            customList.AddRange(new int[] { 2, 4, 3, 5, 6, 5, 8, 7, 5, 4, 9, 0, 2, 4,
                5, 6, 6, 5, 3, 7, 8, 9, 12, 34, 54, 56, 76, 77, 87, 88, 98, 890 });
            int actual, expected = 31;

            //Act
            actual = customList.IndexOf(890, 12, 20);

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Insert_12InMiddle_ExpectCorrectToString()
        {
            //Arrange
            var customList = new CustomList<int>();
            customList.AddRange(new int[] { 2, 4, 3, 5, 6, 54, 56, 76, 77, 87, 88, 98, 890 });
            string actual, expected = "2, 4, 3, 5, 6, 54, 12, 56, 76, 77, 87, 88, 98, 890";

            //Act
            customList.Insert(12, 6);
            actual = customList.ToString();

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Insert_12InMiddle_ExpectCorrectIndexOf()
        {
            //Arrange
            var customList = new CustomList<int>();
            customList.AddRange(new int[] { 2, 4, 3, 5, 6, 54, 56, 76, 77, 87, 88, 98, 890 });
            int actual, expected = 6;

            //Act
            customList.Insert(12, 6);
            actual = customList.IndexOf(12);

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Insert_12InMiddle_ExpectCorrectCountf()
        {
            //Arrange
            var customList = new CustomList<int>();
            customList.AddRange(new int[] { 2, 4, 3, 5, 6, 54, 56, 76, 77, 87, 88, 98, 890 });
            int actual, expected = 14;

            //Act
            customList.Insert(12, 6);
            actual = customList.Count;

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Insert_24AtEnd_ExpectCorrectToString()
        {
            //Arrange
            var customList = new CustomList<int>();
            customList.AddRange(new int[] { 2, 4, 3, 5, 6, 54, 56, 76, 77, 87, 88, 98, 890 });
            string actual, expected = "2, 4, 3, 5, 6, 54, 56, 76, 77, 87, 88, 98, 24, 890";

            //Act
            customList.Insert(24, 12);
            actual = customList.ToString();

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Insert_24AtEnd_ExpectCorrectIndexOf()
        {
            //Arrange
            var customList = new CustomList<int>();
            customList.AddRange(new int[] { 2, 4, 3, 5, 6, 54, 56, 76, 77, 87, 88, 98, 890 });
            int actual, expected = 12;

            //Act
            customList.Insert(24, 12);
            actual = customList.IndexOf(24);

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Insert_24AtEnd_ExpectCorrectCount()
        {
            //Arrange
            var customList = new CustomList<int>();
            customList.AddRange(new int[] { 2, 4, 3, 5, 6, 54, 56, 76, 77, 87, 88, 98, 890 });
            int actual, expected = 14;

            //Act
            customList.Insert(24, 12);
            actual = customList.Count;

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Insert_42AtBeginning_ExpectCorrectToString()
        {
            //Arrange
            var customList = new CustomList<int>();
            customList.AddRange(new int[] { 2, 4, 3, 5, 6, 54, 56, 76, 77, 87, 88, 98, 890 });
            string actual, expected = "42, 2, 4, 3, 5, 6, 54, 56, 76, 77, 87, 88, 98, 890";

            //Act
            customList.Insert(42, 0);
            actual = customList.ToString();

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Insert_42AtBeginning_ExpectCorrectIndexOf()
        {
            //Arrange
            var customList = new CustomList<int>();
            customList.AddRange(new int[] { 2, 4, 3, 5, 6, 54, 56, 76, 77, 87, 88, 98, 890 });
            int actual, expected = 0;

            //Act
            customList.Insert(42, 0);
            actual = customList.IndexOf(42);

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Insert_42AtBeginning_ExpectCorrectCount()
        {
            //Arrange
            var customList = new CustomList<int>();
            customList.AddRange(new int[] { 2, 4, 3, 5, 6, 54, 56, 76, 77, 87, 88, 98, 890 });
            int actual, expected = 14;

            //Act
            customList.Insert(42, 0);
            actual = customList.Count;

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void InsertRange_AtBeginning_ExpectCorrectString()
        {
            //Arrange
            CustomList<int> customList = new CustomList<int>();
            customList.Add(21);
            customList.Add(35);
            customList.Add(20);
            customList.Add(19);
            customList.Add(44);
            string actual, expected = "25, 28, 79, 21, 35, 20, 19, 44";

            //Act
            customList.InsertRange(new int[] { 25, 28, 79 }, 0);
            actual = customList.ToString();

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void InsertRange_InMiddle_ExpectCorrectString()
        {
            // Arrange
            CustomList<int> customList = new CustomList<int>();
            customList.Add(21);
            customList.Add(35);
            customList.Add(20);
            customList.Add(19);
            customList.Add(44);
            string actual, expected = "21, 35, 25, 28, 79, 20, 19, 44";

            //Act
            customList.InsertRange(new int[] { 25, 28, 79 }, 2);
            actual = customList.ToString();

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void InsertRange_AtLastIndex_ExpectCorrectString()
        {
            // Arrange
            CustomList<int> customList = new CustomList<int>();
            customList.Add(21);
            customList.Add(35);
            customList.Add(20);
            customList.Add(19);
            customList.Add(44);
            string actual, expected = "21, 35, 20, 19, 25, 28, 79, 44";

            //Act
            customList.InsertRange(new int[] { 25, 28, 79 }, 4);
            actual = customList.ToString();

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Remove_54InMiddle_ExpectCorrectToString()
        {
            //Arrange
            var customList = new CustomList<int>();
            customList.AddRange(new int[] { 2, 4, 3, 5, 6, 54, 56, 76, 77, 87, 88, 98, 890 });
            string actual, expected = "2, 4, 3, 5, 6, 56, 76, 77, 87, 88, 98, 890";

            //Act
            customList.Remove(54);
            actual = customList.ToString();

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Remove_54InMiddle_ExpectCorrectCount()
        {
            //Arrange
            var customList = new CustomList<int>();
            customList.AddRange(new int[] { 2, 4, 3, 5, 6, 54, 56, 76, 77, 87, 88, 98, 890 });
            int actual, expected = 12;

            //Act
            customList.Remove(54);
            actual = customList.Count;

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Remove_890AtEnd_ExpectCorrectToString()
        {
            //Arrange
            var customList = new CustomList<int>();
            customList.AddRange(new int[] { 2, 4, 3, 5, 6, 54, 56, 76, 77, 87, 88, 98, 890 });
            string actual, expected = "2, 4, 3, 5, 6, 54, 56, 76, 77, 87, 88, 98";

            //Act
            customList.Remove(890);
            actual = customList.ToString();

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Remove_890AtEnd_ExpectCorrectCount()
        {
            //Arrange
            var customList = new CustomList<int>();
            customList.AddRange(new int[] { 2, 4, 3, 5, 6, 54, 56, 76, 77, 87, 88, 98, 890 });
            int actual, expected = 12;

            //Act
            customList.Remove(890);
            actual = customList.Count;

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Remove_2AtBeginning_ExpectCorrectToString()
        {
            //Arrange
            var customList = new CustomList<int>();
            customList.AddRange(new int[] { 2, 4, 3, 5, 6, 54, 56, 76, 77, 87, 88, 98, 890 });
            string actual, expected = "4, 3, 5, 6, 54, 56, 76, 77, 87, 88, 98, 890";

            //Act
            customList.Remove(2);
            actual = customList.ToString();

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Remove_2AtBeginning_ExpectCorrectCount()
        {
            //Arrange
            var customList = new CustomList<int>();
            customList.AddRange(new int[] { 2, 4, 3, 5, 6, 54, 56, 76, 77, 87, 88, 98, 890 });
            int actual, expected = 12;

            //Act
            customList.Remove(2);
            actual = customList.Count;

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void RemoveAll_6_ExpectCorrectToString()
        {
            //Arrange
            var customList = new CustomList<int>();
            customList.AddRange(new int[] { 2, 66, 3, 5, 6, 54, 6, 6, 77, 87, 6, 98, 6, 6 });
            string actual, expected = "2, 66, 3, 5, 54, 77, 87, 98";

            //Act
            customList.RemoveAll(6);
            actual = customList.ToString();

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void RemoveAll_6_ExpectCorrectCount()
        {
            //Arrange
            var customList = new CustomList<int>();
            customList.AddRange(new int[] { 2, 66, 3, 5, 6, 54, 6, 6, 77, 87, 6, 98, 6, 6 });
            int actual, expected = 8;

            //Act
            customList.RemoveAll(6);
            actual = customList.Count;

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void RemoveAll_Lisa_ExpectCorrectToString()
        {
            //Arrange
           var customList = new CustomList<string>();
            customList.AddRange(new string[] { "Paul", "liSa", "Mark", "Eric", "Lisa", "Maggie", "Lisa", 
                                               "Lisa", " ", "Kofi", "Lisa", "Abena", "Lisa", "Lisa" });
            string actual, expected = "Paul, liSa, Mark, Eric, Maggie,  , Kofi, Abena";

            //Act
            customList.RemoveAll("Lisa");
            actual = customList.ToString();

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void RemoveAll_Lisa_ExpectCorrectCount()
        {
            //Arrange
            var customList = new CustomList<string>();
            customList.AddRange(new string[] { "Paul", "liSa", "Mark", "Eric", "Lisa", "Maggie", "Lisa", "Lisa", " ", "Kofi", "Lisa", "Abena", "Lisa", "Lisa" });
            int actual, expected = 8;

            //Act
            customList.RemoveAll("Lisa");
            actual = customList.Count;

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void RemoveAll_StartsWithM_ExpectCorrectToString()
        {
            //Arrange
            var customList = new CustomList<string>();
            customList.AddRange(new string[] { "Paul", "liSa", "Mark", "Eric", "Lisa", "Maggie", "Lisa", "Lisa", " ", "Kofi", "Lisa", "Abena", "Lisa", "Lisa" });
            string actual, expected = "Paul, liSa, Eric, Lisa, Lisa, Lisa,  , Kofi, Lisa, Abena, Lisa, Lisa";

            //Act
            customList.RemoveAll(m=>m.StartsWith('M'));
            actual = customList.ToString();

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void RemoveAll_StartsWithM_ExpectCorrectCount()
        {
            //Arrange
            var customList = new CustomList<string>();
            customList.AddRange(new string[] { "Paul", "liSa", "Mark", "Eric", "Lisa", "Maggie", "Lisa", "Lisa", " ", "Kofi", "Lisa", "Abena", "Lisa", "Lisa" });
            int actual, expected = 12;

            //Act
            customList.RemoveAll(m=>m.StartsWith('M'));
            actual = customList.Count;

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void RemoveAll_EndssWithA_ExpectCorrectToString()
        {
            //Arrange
            var customList = new CustomList<string>();
            customList.AddRange(new string[] { "Paul", "liSa", "Mark", "Eric", "Lisa", "Maggie", 
                                               "Lisa", "Lisa", " ", "Kofi", "Lisa", "Abena", "Lisa", "Lisa" });
            string actual, expected = "Paul, Mark, Eric, Maggie,  , Kofi";

            //Act
            customList.RemoveAll(m => m.EndsWith('a'));
            actual = customList.ToString();

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void RemoveAll_EndsWithA_ExpectCorrectCount()
        {
            //Arrange
            var customList = new CustomList<string>();
            customList.AddRange(new string[] { "Paul", "liSa", "Mark", "Eric", "Lisa", "Maggie", "Lisa", "Lisa", " ", "Kofi", "Lisa", "Abena", "Lisa", "Lisa" });
            int actual, expected = 6;

            //Act
            customList.RemoveAll( m=>m.EndsWith('a'));
            actual = customList.Count;

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void RemoveAll_EndsWithA_ExpectCorrectReturnedCount()
        {
            //Arrange
            var customList = new CustomList<string>();
            customList.AddRange(new string[] { "Paul", "liSa", "Mark", "Eric", "Lisa", "Maggie", "Lisa", "Lisa", " ", "Kofi", "Lisa", "Abena", "Lisa", "Lisa" });
            int actual, expected = 8;

            //Act
            actual =customList.RemoveAll(m => m.EndsWith('a'));

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void RemoveAt_Index6_ExpectCorrectToString()
        {
            //Arrange
            CustomList<int> customList = new CustomList<int>();
            customList.AddRange(new int[] { 2, 4, 3, 5, 6, 54, 56, 76, 77, 87, 88, 98, 890 });
            string actual, expected = "2, 4, 3, 5, 6, 54, 76, 77, 87, 88, 98, 890";

            //Act
            customList.RemoveAt(6);
            actual = customList.ToString();

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void RemoveAt_Index6_ExpectCorrectCount()
        {
            //Arrange
            CustomList<int> customList = new CustomList<int>();
            customList.AddRange(new int[] { 2, 4, 3, 5, 6, 54, 56, 76, 77, 87, 88, 98, 890 });
            int actual, expected = 12;

            //Act
            customList.RemoveAt(6);
            actual = customList.Count;

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void RemoveAt_Index12ExpectCorrectToString()
        {
            //Arrange
            CustomList<int> customList = new CustomList<int>();
            customList.AddRange(new int[] { 2, 4, 3, 5, 6, 54, 56, 76, 77, 87, 88, 98, 890 });
            string actual, expected = "2, 4, 3, 5, 6, 54, 56, 76, 77, 87, 88, 98";

            //Act
            customList.RemoveAt(12);
            actual = customList.ToString();

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void RemoveAt_Index12_ExpectCorrectCount()
        {
            //Arrange
            CustomList<int> customList = new CustomList<int>();
            customList.AddRange(new int[] { 2, 4, 3, 5, 6, 54, 56, 76, 77, 87, 88, 98, 890 });
            int actual, expected = 12;

            //Act
            customList.RemoveAt(12);
            actual = customList.Count;

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void RemoveAt_Index0_ExpectCorrectToString()
        {
            //Arrange
            CustomList<int> customList = new CustomList<int>();
            customList.AddRange(new int[] { 2, 4, 3, 5, 6, 54, 56, 76, 77, 87, 88, 98, 890 });
            string actual, expected = "4, 3, 5, 6, 54, 56, 76, 77, 87, 88, 98, 890";

            //Act
            customList.RemoveAt(0);
            actual = customList.ToString();

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void RemoveAt_Index0_ExpectCorrectCount()
        {
            //Arrange
            CustomList<int> customList = new CustomList<int>();
            customList.AddRange(new int[] { 2, 4, 3, 5, 6, 54, 56, 76, 77, 87, 88, 98, 890 });
            int actual, expected = 12;

            //Act
            customList.RemoveAt(0);
            actual = customList.Count;

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void RemoveFirst_ExpectCorrectToString()
        {
            //Arrange
            CustomList<int> customList = new CustomList<int>();
            customList.AddRange(new int[] { 2, 4, 3, 5, 6, 54, 56, 76, 77, 87, 88, 98, 890 });
            string actual, expected = "4, 3, 5, 6, 54, 56, 76, 77, 87, 88, 98, 890";

            //Act
            customList.RemoveFirst();
            actual = customList.ToString();

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void RemoveFirst_ExpectCorrectCount()
        {
            //Arrange
            CustomList<int> customList = new CustomList<int>();
            customList.AddRange(new int[] { 2, 4, 3, 5, 6, 54, 56, 76, 77, 87, 88, 98, 890 });
            int actual, expected = 12;

            //Act
            customList.RemoveFirst();
            actual = customList.Count;

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void RemoveLast_ExpectCorrectToString()
        {
            //Arrange
            CustomList<int> customList = new CustomList<int>();
            customList.AddRange(new int[] { 2, 4, 3, 5, 6, 54, 56, 76, 77, 87, 88, 98, 890 });
            string actual, expected = "2, 4, 3, 5, 6, 54, 56, 76, 77, 87, 88, 98";

            //Act
            customList.RemoveLast();
            actual = customList.ToString();

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void RemoveLast_ExpectCorrectCount()
        {
            //Arrange
            CustomList<int> customList = new CustomList<int>();
            customList.AddRange(new int[] { 2, 4, 3, 5, 6, 54, 56, 76, 77, 87, 88, 98, 890 });
            int actual, expected = 12;

            //Act
            customList.RemoveLast();
            actual = customList.Count;

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void RemoveRange_WithouthCountAtIndex4_ExpectCorrectToString()
        {
            //Arrange
            CustomList<int> customList = new CustomList<int>();
            customList.AddRange(new int[] { 2, 4, 3, 5, 6, 54, 56, 76, 77, 87, 88, 98, 890 });
            string actual, expected = "2, 4, 3, 5";

            //Act
            customList.RemoveRange(4);
            actual = customList.ToString();

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void RemoveRange_WithouthCountAtIndex4_ExpectCorrectCount()
        {
            //Arrange
            CustomList<int> customList = new CustomList<int>();
            customList.AddRange(new int[] { 2, 4, 3, 5, 6, 54, 56, 76, 77, 87, 88, 98, 890 });
            int actual, expected = 4;

            //Act
            customList.RemoveRange(4);
            actual = customList.Count;

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void RemoveRange_WithouthCountAtIndex0_ExpectCorrectToString()
        {
            //Arrange
            CustomList<int> customList = new CustomList<int>();
            customList.AddRange(new int[] { 2, 4, 3, 5, 6, 54, 56, 76, 77, 87, 88, 98, 890 });
            string actual, expected = "";

            //Act
            customList.RemoveRange(0);
            actual = customList.ToString();

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void RemoveRange_WithouthCountAtIndex0_ExpectCorrectCount()
        {
            //Arrange
            CustomList<int> customList = new CustomList<int>();
            customList.AddRange(new int[] { 2, 4, 3, 5, 6, 54, 56, 76, 77, 87, 88, 98, 890 });
            int actual, expected = 0;

            //Act
            customList.RemoveRange(0);
            actual = customList.Count;

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void RemoveRange_WithouthCountAtIndex12_ExpectCorrectToString()
        {
            //Arrange
            CustomList<int> customList = new CustomList<int>();
            customList.AddRange(new int[] { 2, 4, 3, 5, 6, 54, 56, 76, 77, 87, 88, 98, 890 });
            string actual, expected = "2, 4, 3, 5, 6, 54, 56, 76, 77, 87, 88, 98";

            //Act
            customList.RemoveRange(12);
            actual = customList.ToString();

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void RemoveRange_WithouthCountAtIndex12_ExpectCorrectCount()
        {
            //Arrange
            CustomList<int> customList = new CustomList<int>();
            customList.AddRange(new int[] { 2, 4, 3, 5, 6, 54, 56, 76, 77, 87, 88, 98, 890 });
            int actual, expected = 12;

            //Act
            customList.RemoveRange(12);
            actual = customList.Count;

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void RemoveRange_4To8_ExpectCorrectToString()
        {
            //Arrange
            var customList = new CustomList<int>();
            customList.AddRange(new int[] { 2, 4, 3, 5, 6, 54, 56, 76, 77, 87, 88, 98, 890 });
            string actual, expected = "2, 4, 3, 5, 87, 88, 98, 890";

            //Act
            customList.RemoveRange(4, 5);
            actual = customList.ToString();

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Remove_4To8_ExpectCorrectCount()
        {
            //Arrange
            var customList = new CustomList<int>();
            customList.AddRange(new int[] { 2, 4, 3, 5, 6, 54, 56, 76, 77, 87, 88, 98, 890 });
            int actual, expected = 6;

            //Act
            customList.RemoveRange(4, 7);
            actual = customList.Count;

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void RemoveRange_0To4_ExpectCorrectToString()
        {
            //Arrange
            var customList = new CustomList<int>();
            customList.AddRange(new int[] { 2, 4, 3, 5, 6, 54, 56, 76, 77, 87, 88, 98, 890 });
            string actual, expected = "54, 56, 76, 77, 87, 88, 98, 890";

            //Act
            customList.RemoveRange(0, 5);
            actual = customList.ToString();

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void RemoveRange_0To4_ExpectCorrectReturnedToString()
        {
            //Arrange
            CustomList<int> customList = new CustomList<int>();
            customList.AddRange(new int[] { 2, 4, 3, 5, 6, 54, 56, 76, 77, 87, 88, 98, 890 });
            string actual, expected = "2, 4, 3, 5, 6";

            //Act
            var returnedList = customList.RemoveRange(0, 5);
            actual = returnedList.ToString();

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void RemoveRange_0To4_ExpectCorrectCount()
        {
            //Arrange
            var customList = new CustomList<int>();
            customList.AddRange(new int[] { 2, 4, 3, 5, 6, 54, 56, 76, 77, 87, 88, 98, 890 });
            int actual, expected = 8;

            //Act
            customList.RemoveRange(0, 5);
            actual = customList.Count;

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void RemoveRange_8ToEnd_ExpectCorrectToString()
        {
            //Arrange
            var customList = new CustomList<int>();
            customList.AddRange(new int[] { 2, 4, 3, 5, 6, 54, 56, 76, 77, 87, 88, 98, 890 });
            string actual, expected = "2, 4, 3, 5, 6, 54, 56, 76";

            //Act
            customList.RemoveRange(8, 5);
            actual = customList.ToString();

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void RemoveRange_8ToEnd_ExpectCorrectReturnedToString()
        {
            //Arrange
            CustomList<int> customList = new CustomList<int>();
            customList.AddRange(new int[] { 2, 4, 3, 5, 6, 54, 56, 76, 77, 87, 88, 98, 890 });
            string actual, expected = "77, 87, 88, 98, 890";

            //Act
            var returnedList = customList.RemoveRange(8, 5);
            actual = returnedList.ToString();

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void RemoveRange_8ToEnd_ExpectCorrectCount()
        {
            //Arrange
            var customList = new CustomList<int>();
            customList.AddRange(new int[] { 2, 4, 3, 5, 6, 54, 56, 76, 77, 87, 88, 98, 890 });
            int actual, expected = 8;

            //Act
            customList.RemoveRange(8, 5);
            actual = customList.Count;

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Reverse_IntList4ToEnd_ExpectCorrectString()
        {
            //Arrange
            var customList = new CustomList<int>();
            customList.AddRange(new int[] { 2, 4, 3, 5, 6, 54, 56, 76, 77, 87, 88, 98, 890 });
            string actual, expected = "2, 4, 3, 5, 890, 98, 88, 87, 77, 76, 56, 54, 6";

            //Act
            customList.Reverse(4,9);
            actual = customList.ToString();

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Reverse_IntList4To8_ExpectCorrectString()
        {
            //Arrange
            var customList = new CustomList<int>();
            customList.AddRange(new int[] { 2, 4, 3, 5, 6, 54, 56, 76, 77, 87, 88, 98, 890 });
            string actual, expected = "2, 4, 3, 5, 77, 76, 56, 54, 6, 87, 88, 98, 890";

            //Act
            customList.Reverse(4, 5);
            actual = customList.ToString();

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Reverse_EntireIntList_ExpectCorrectString()
        {
            //Arrange
            var customList = new CustomList<int>();
            customList.AddRange(new int[] { 2, 4, 3, 5});
            string actual, expected = "5, 3, 4, 2";

            //Act
            customList.Reverse();
            actual = customList.ToString();

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Reverse_StringList4ToEnd_ExpectCorrectString()
        {
            //Arrange
            var customList = new CustomList<string>();
            customList.AddRange(new string[] { "Paul", "liSa", "Mark", "Eric", "Lisa", "Maggie",
                                               "Lisa", "Lisa", " ", "Kofi", "Lisa", "Abena", "Lisa", "Lisa" });
            string actual, expected = "Paul, liSa, Mark, Eric, Lisa, Lisa, Abena, Lisa, Kofi,  , Lisa, Lisa, Maggie, Lisa";

            //Act
            customList.Reverse(4, 10);
            actual = customList.ToString();

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Reverse_ObjectList4ToEnd_ExpectCorrectString()
        {
            //Arrange
            var customList = new CustomList<Person>();
            customList.AddRange(new Person[] { new Person("John", "Doe", 19), new Person("Paul", "Wang", 54),
                                new Person("Eric", "Faulk", 19), new Person("John", "Doe", 112),
                                new Person("Jane", "Katz", 73),  new Person("Eric", "Faulk", 19),
                                new Person("Jason", "Bourne", 42),  new Person("Eric", "Faulk", 19),
                                new Person("Kate", "Chen", 55), new Person("Eric", "Bates", 39),
                                new Person("Laura", "Schultz", 132)});

            string actual, expected = "John Doe 19, Paul Wang 54, Eric Faulk 19, John Doe 112, Laura Schultz 132, " +
                                      "Eric Bates 39, Kate Chen 55, Eric Faulk 19, Jason Bourne 42, Eric Faulk 19, Jane Katz 73";

            //Act
            customList.Reverse(4, 7);
            actual = customList.ToString();

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TrueForAll_CheckFor6_ExpectFalse()
        {
            //Arrange
            CustomList<int> customList = new CustomList<int>();
            customList.AddRange(new int[] { 2, 4, 3, 5, 6, 5, 8, 7, 5, 4, 9, 0, 2, 4, 5, 6, 6, 5, 3 });
            bool actual, expected = false;

            //Act
            actual = customList.TrueForAll(p => p == 6);

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TrueForAll_CheckFor6_ExpectTrue()
        {
            //Arrange
            CustomList<int> customList = new CustomList<int>();
            customList.AddRange(new int[] { 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6 });
            bool actual, expected = true;

            //Act
            actual = customList.TrueForAll(p => p == 6);

            //Assert
            Assert.AreEqual(expected, actual);
        }
    }
}