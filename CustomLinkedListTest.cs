using Microsoft.VisualStudio.TestTools.UnitTesting;
using GenericsConsoleApp;

namespace GenericConsoleApp.UnitTests
{
    [TestClass]
    public class CustomLinkedListTest
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

        [TestMethod]
        public void Add_210_Expect210()
        {
            //Arrange
            CustomLinkedList<int> customLinkedList = new CustomLinkedList<int>();
            string actual, expected = "210";
            
            //Act
            customLinkedList.Add(210);
            actual = customLinkedList.ToString();

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Add_220After210_Expect220then210()
        {
            //Arrange
            CustomLinkedList<int> customLinkedList = new CustomLinkedList<int>();
            string actual, expected = "210, 220";
            
            //Act
            customLinkedList.Add(210);
            customLinkedList.Add(220);
            actual = customLinkedList.ToString();

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Add_220then210then230_ExpectCount3()
        {
            //Arrange
            CustomLinkedList<int> customLinkedList = new CustomLinkedList<int>();
            int actual, expected = 3;
            
            //Act
            customLinkedList.Add(210);
            customLinkedList.Add(220);
            customLinkedList.Add(230);
            actual = customLinkedList.Count;

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void AddRange_ExpectCorrectString()
        {
            //Arrange
            CustomLinkedList<int> customLinkedList = new CustomLinkedList<int>();
            customLinkedList.Add(21);
            customLinkedList.Add(35);
            customLinkedList.Add(20);
            customLinkedList.Add(19);
            customLinkedList.Add(44);
            string actual, expected = "21, 35, 20, 19, 44, 25, 28, 79";

            //Act
            customLinkedList.AddRange(new int[] { 25, 28, 79 });
            actual = customLinkedList.ToString();

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void AddRange_ExpectCorrectCount()
        {
            //Arrange
            CustomLinkedList<int> customLinkedList = new CustomLinkedList<int>();
            customLinkedList.Add(21);
            customLinkedList.Add(35);
            customLinkedList.Add(20);
            customLinkedList.Add(19);
            customLinkedList.Add(44);
            int actual, expected = 8;

            //Act
            customLinkedList.AddRange(new int[] { 25, 28, 79 });
            actual = customLinkedList.Count;

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Clear_ExpectCorrectToString()
        {
            //Arrange
            CustomLinkedList<int> customLinkedList = new CustomLinkedList<int>();
            customLinkedList.AddRange(new int[] { 2, 4, 3, 5, 6, 54, 56, 76, 77, 87, 88, 98, 890 });
            string actual, expected = "";

            //Act
            customLinkedList.Clear();
            actual = customLinkedList.ToString();

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Clear_ExpectCorrectCount()
        {
            //Arrange
            CustomLinkedList<int> customLinkedList = new CustomLinkedList<int>();
            customLinkedList.AddRange(new int[] { 2, 4, 3, 5, 6, 54, 56, 76, 77, 87, 88, 98, 890 });
            int actual, expected = 0;

            //Act
            customLinkedList.Clear();
            actual = customLinkedList.Count;

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Contains_2_ExpectTrue()
        {
            //Arrange
            CustomLinkedList<int> customLinkedList = new CustomLinkedList<int>();
            customLinkedList.AddRange(new int[] { 2, 4, 3, 5, 6, 5, 8, 7, 5, 4, 9, 0, 2, 4, 5, 6, 6, 5, 3, 7, 8, 9, 12, 34, 54, 56, 76, 77, 87, 88, 98, 890 });
            bool actual, expected = true;
            
            //Act
            actual =customLinkedList.Contains(2);

            //Assert
            Assert.AreEqual(actual,expected);
        }

        [TestMethod]
        public void Contains_2_ExpectCorrectCount()
        {
            //Arrange
            CustomLinkedList<int> customLinkedList = new CustomLinkedList<int>();
            customLinkedList.AddRange(new int[] { 2, 4, 3, 5, 6, 5, 8, 7, 54, 56, 76, 77, 87, 88, 98, 890 });
            int actual, expected = 16;

            //Act
            customLinkedList.Contains(2);
            actual = customLinkedList.Count;

            //Assert
            Assert.AreEqual(actual, expected);
        }

        [TestMethod]
        public void Contains_890_ExpectTrue()
        {
            //Arrange
            CustomLinkedList<int> customLinkedList = new CustomLinkedList<int>();
            customLinkedList.AddRange(new int[] { 2, 4, 3, 5, 6, 5, 8, 7, 5, 4, 9, 0, 2, 4, 5, 6, 6, 5, 3, 7, 8, 9, 12, 34, 54, 56, 76, 77, 87, 88, 98, 890 });
            bool actual, expected = true;
            
            //Act
            actual = customLinkedList.Contains(890);

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Contains_6_ExpectTrue()
        {
            //Arrange
            CustomLinkedList<int> customLinkedList = new CustomLinkedList<int>();
            customLinkedList.AddRange(new int[] { 2, 4, 3, 5, 6, 5, 8, 7, 5, 4, 9, 0, 2, 4, 5, 6, 6, 5, 3, 7, 8, 9, 12, 34, 54, 56, 76, 77, 87, 88, 98, 890 });
            bool actual, expected = true;
            //Act

            actual = customLinkedList.Contains(6);

            //Assert

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Contains_210_ExpectFalse()
        {
            //Arrange
            CustomLinkedList<int> customLinkedList = new CustomLinkedList<int>();
            customLinkedList.AddRange(new int[] { 2, 4, 3, 5, 6, 5, 8, 7, 5, 4, 9, 0, 2, 4, 5, 6, 6, 5, 3, 7, 8, 9, 12, 34, 54, 56, 76, 77, 87, 88, 98, 890 });
            bool actual, expected = false;
            
            //Act
            actual = customLinkedList.Contains(210);

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Contains_21_ExpectFalse()
        {
            //Arrange
            CustomLinkedList<int> customLinkedList = new CustomLinkedList<int>();
            customLinkedList.AddRange(new int[] { 2, 4, 3, 5, 6, 5, 8, 7, 5, 4, 9, 0, 2, 4, 5, 6, 6, 5, 3, 7, 8, 9, 12, 34, 54, 56, 76, 77, 87, 88, 98, 890 });
            bool actual, expected = false;
            
            //Act
            actual = customLinkedList.Contains(21);

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void CopyTo_WithoutIndexOrCount__ExpectCorrectString()
        {
            //Arrange
            CustomLinkedList<int> customLinkedList = new CustomLinkedList<int>();
            customLinkedList.AddRange(new int[] { 2, 4, 3, 5, 6, 5, 8, 7, 5, 4, 9, 0, 2, 4, 5, 6, 6, 5, 3});
            string actual, expected = "2, 4, 3, 5, 6, 5, 8, 7, 5, 4, 9, 0, 2, 4, 5, 6, 6, 5, 3";

            //Act
            var array= customLinkedList.CopyTo(new int[19]);
            actual = ArrayToString(array);

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void CopyTo_WithArrayIndex0__ExpectCorrectString()
        {
            //Arrange
            CustomLinkedList<int> customLinkedList = new CustomLinkedList<int>();
            customLinkedList.AddRange(new int[] { 2, 4, 3, 5, 6, 5, 8, 7, 5, 4, 9, 0, 2, 4, 5, 6, 6, 5, 3 });
            string actual, expected = "2, 4, 3, 5, 6, 5, 8, 7, 5, 4, 9, 0, 2, 4, 5, 6, 6, 5, 3, 0, 0, 0, 0, 0, 0";

            //Act
            var array = customLinkedList.CopyTo(new int[25], 0);
            actual = ArrayToString(array);

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void CopyTo_WithArrayIndex6__ExpectCorrectString()
        {
            //Arrange
            CustomLinkedList<int> customLinkedList = new CustomLinkedList<int>();
            customLinkedList.AddRange(new int[] { 2, 4, 3, 5, 6, 5, 8, 7, 5, 4, 9, 0, 2, 4, 5, 6, 6, 5, 3 });
            string actual, expected = "0, 0, 0, 0, 0, 0, 2, 4, 3, 5, 6, 5, 8, 7, 5, 4, 9, 0, 2, 4, 5, 6, 6, 5, 3";

            //Act
            var array = customLinkedList.CopyTo(new int[25], 6);
            actual = ArrayToString(array);

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void CopyTo_WithArrayIndex2__ExpectCorrectString()
        {
            //Arrange
            CustomLinkedList<int> customLinkedList = new CustomLinkedList<int>();
            customLinkedList.AddRange(new int[] { 2, 4, 3, 5, 6, 5, 8, 7, 5, 4, 9, 0, 2, 4, 5, 6, 6, 5, 3 });
            string actual, expected = "0, 0, 2, 4, 3, 5, 6, 5, 8, 7, 5, 4, 9, 0, 2, 4, 5, 6, 6, 5, 3, 0, 0, 0, 0";

            //Act
            var array = customLinkedList.CopyTo(new int[25],2);
            actual = ArrayToString(array);

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void CopyTo_WithListIndex2ArrayIndex2Count5__ExpectCorrectString()
        {
            //Arrange
            CustomLinkedList<int> customLinkedList = new CustomLinkedList<int>();
            customLinkedList.AddRange(new int[] { 2, 4, 3, 5, 6, 5, 8, 7, 5, 4, 9, 0, 2, 4, 5, 6, 6, 5, 3 });
            string actual, expected = "0, 0, 3, 5, 6, 5, 8, 0, 0, 0, 0";

            //Act
            var array = customLinkedList.CopyTo(2,new int[11], 2, 5);
            actual = ArrayToString(array);

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void CopyTo_WithListIndex0ArrayIndex5Count6__ExpectCorrectString()
        {
            //Arrange
            CustomLinkedList<int> customLinkedList = new CustomLinkedList<int>();
            customLinkedList.AddRange(new int[] { 2, 4, 3, 5, 6, 5, 8, 7, 5, 4, 9, 0, 2, 4, 5, 6, 6, 5, 3 });
            string actual, expected = "0, 0, 0, 0, 0, 2, 4, 3, 5, 6, 5";

            //Act
            var array = customLinkedList.CopyTo(0, new int[11], 5, 6);
            actual = ArrayToString(array);

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void CopyTo_WithListIndex10ArrayIndex0Count9__ExpectCorrectString()
        {
            //Arrange
            CustomLinkedList<int> customLinkedList = new CustomLinkedList<int>();
            customLinkedList.AddRange(new int[] { 2, 4, 3, 5, 6, 5, 8, 7, 5, 4, 9, 0, 2, 4, 5, 6, 6, 5, 3 });
            string actual, expected = "9, 0, 2, 4, 5, 6, 6, 5, 3, 0, 0";

            //Act
            var array = customLinkedList.CopyTo(10, new int[11], 0, 9);
            actual = ArrayToString(array);

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Exists_LastNameIsSchultzExpectTrue()
        {
            //Arrange
            var customLinkedList = new CustomLinkedList<Person>();
            customLinkedList.AddRange(new Person[] { new Person("John", "Doe", 19), new Person("Paul", "Wang", 54),
                                new Person("Eric", "Faulk", 19), new Person("John", "Doe", 112),
                                new Person("Jane", "Katz", 73),  new Person("Eric", "Faulk", 19),
                                new Person("Jason", "Bourne", 42),  new Person("Eric", "Faulk", 19),
                                new Person("Kate", "Chen", 55), new Person("Eric", "Bates", 39),
                                new Person("Laura", "Schultz", 132)});

            bool actual, expected = true;

            //Act
            actual = customLinkedList.Exists(p => p.LastName == "Schultz");

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Exists_FirstNameIsJackExpectFalse()
        {
            //Arrange
            var customLinkedList = new CustomLinkedList<Person>();
            customLinkedList.AddRange(new Person[] { new Person("John", "Doe", 19), new Person("Paul", "Wang", 54),
                                new Person("Eric", "Faulk", 19), new Person("John", "Doe", 112),
                                new Person("Jane", "Katz", 73),  new Person("Eric", "Faulk", 19),
                                new Person("Jason", "Bourne", 42),  new Person("Eric", "Faulk", 19),
                                new Person("Kate", "Chen", 55), new Person("Eric", "Bates", 39),
                                new Person("Laura", "Schultz", 132)});

            bool actual, expected = false;

            //Act
            actual = customLinkedList.Exists(p => p.FirstName == "Jack");

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Find_JanetLin_ExpectNull()
        {
            //Arrange
            var customLinkedList = new CustomLinkedList<Person>();
            customLinkedList.AddRange(new Person[] { new Person("John", "Doe", 19), new Person("Paul", "Wang", 54),
                                new Person("Eric", "Faulk", 19), new Person("John", "Doe", 112),
                                new Person("Jane", "Katz", 73),  new Person("Eric", "Faulk", 19),
                                new Person("Jason", "Bourne", 42),  new Person("Eric", "Faulk", 19),
                                new Person("Kate", "Chen", 55), new Person("Eric", "Bates", 39),
                                new Person("Laura", "Schultz", 132)});
            Person actual, expected = null;

            //Act
            actual = customLinkedList.Find(p => (p.FirstName == "Janet" && p.LastName == "Lin"));

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Find_LauraShultz_ExpectLauraSchultz()
        {
            //Arrange
            var customLinkedList = new CustomLinkedList<Person>();
            customLinkedList.AddRange(new Person[] { new Person("John", "Doe", 19), new Person("Paul", "Wang", 54),
                                new Person("Eric", "Faulk", 19), new Person("John", "Doe", 112),
                                new Person("Jane", "Katz", 73),  new Person("Eric", "Faulk", 19),
                                new Person("Jason", "Bourne", 42),  new Person("Eric", "Faulk", 19),
                                new Person("Kate", "Chen", 55), new Person("Eric", "Bates", 39),
                                new Person("Laura", "Schultz", 132)});
            string actual, expected = "Laura Schultz 132";
            actual = customLinkedList.Find(p => (p.FirstName == "Laura" && p.LastName == "Schultz")).ToString();

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Find_Id19_ExpectJohnDoe()
        {
            //Arrange
            var customLinkedList = new CustomLinkedList<Person>();
            customLinkedList.AddRange(new Person[] { new Person("John", "Doe", 19), new Person("Paul", "Wang", 54),
                                new Person("Eric", "Faulk", 19), new Person("John", "Doe", 112),
                                new Person("Jane", "Katz", 73),  new Person("Eric", "Faulk", 19),
                                new Person("Jason", "Bourne", 42),  new Person("Eric", "Faulk", 19),
                                new Person("Kate", "Chen", 55), new Person("Eric", "Bates", 39),
                                new Person("Laura", "Schultz", 132)});
            string actual, expected = "John Doe 19";

            //Act
            actual = customLinkedList.Find(p => (p.Id == 19 )).ToString();

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void FindIndex_JanetLin_ExpectNegativeOne()
        {
            //Arrange
            var customLinkedList = new CustomLinkedList<Person>();
            customLinkedList.AddRange(new Person[] { new Person("John", "Doe", 19), new Person("Paul", "Wang", 54),
                                new Person("Eric", "Faulk", 19), new Person("John", "Doe", 112),
                                new Person("Jane", "Katz", 73),  new Person("Eric", "Faulk", 19),
                                new Person("Jason", "Bourne", 42),  new Person("Eric", "Faulk", 19),
                                new Person("Kate", "Chen", 55), new Person("Eric", "Bates", 39),
                                new Person("Laura", "Schultz", 132)});
            int actual, expected = -1;

            //Act
            actual = customLinkedList.FindIndex(p => (p.FirstName == "Janet" && p.LastName == "Lin"));

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void FindIndex_EricFaulk_ExpectTwo()
        {
            //Arrange
            var customLinkedList = new CustomLinkedList<Person>();
            customLinkedList.AddRange(new Person[] { new Person("John", "Doe", 19), new Person("Paul", "Wang", 54),
                                new Person("Eric", "Faulk", 19), new Person("John", "Doe", 112),
                                new Person("Jane", "Katz", 73),  new Person("Eric", "Faulk", 19),
                                new Person("Jason", "Bourne", 42),  new Person("Eric", "Faulk", 19),
                                new Person("Kate", "Chen", 55), new Person("Eric", "Bates", 39),
                                new Person("Laura", "Schultz", 132)});
            int actual, expected = 2;

            //Act
            actual = customLinkedList.FindIndex(p => (p.FirstName == "Eric" && p.LastName == "Faulk"));

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void FindIndex_EricFaulkStartAt3_ExpectFive()
        {
            //Arrange
            var customLinkedList = new CustomLinkedList<Person>();
            customLinkedList.AddRange(new Person[] { new Person("John", "Doe", 19), new Person("Paul", "Wang", 54),
                                new Person("Eric", "Faulk", 19), new Person("John", "Doe", 112),
                                new Person("Jane", "Katz", 73),  new Person("Eric", "Faulk", 19),
                                new Person("Jason", "Bourne", 42),  new Person("Eric", "Faulk", 19),
                                new Person("Kate", "Chen", 55), new Person("Eric", "Bates", 39),
                                new Person("Laura", "Schultz", 132)});
            int actual, expected = 5;

            //Act
            actual = customLinkedList.FindIndex(3, p => (p.FirstName == "Eric" && p.LastName == "Faulk"));

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void FindIndex_JasonBourneStartAt1Count6_ExpectSix()
        {
            //Arrange
            var customLinkedList = new CustomLinkedList<Person>();
            customLinkedList.AddRange(new Person[] { new Person("John", "Doe", 19), new Person("Paul", "Wang", 54),
                                new Person("Eric", "Faulk", 19), new Person("John", "Doe", 112),
                                new Person("Jane", "Katz", 73),  new Person("Eric", "Faulk", 19),
                                new Person("Jason", "Bourne", 42),  new Person("Eric", "Faulk", 19),
                                new Person("Kate", "Chen", 55), new Person("Eric", "Bates", 39),
                                new Person("Laura", "Schultz", 132)});
            int actual, expected = 6;

            //Act
            actual = customLinkedList.FindIndex(1, 6, p => (p.FirstName == "Jason" && p.LastName == "Bourne"));

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void FindIndex_JasonBourneStartAt1Count5_ExpectNegativeOne()
        {
            //Arrange
            var customLinkedList = new CustomLinkedList<Person>();
            customLinkedList.AddRange(new Person[] { new Person("John", "Doe", 19), new Person("Paul", "Wang", 54),
                                new Person("Eric", "Faulk", 19), new Person("John", "Doe", 112),
                                new Person("Jane", "Katz", 73),  new Person("Eric", "Faulk", 19),
                                new Person("Jason", "Bourne", 42),  new Person("Eric", "Faulk", 19),
                                new Person("Kate", "Chen", 55), new Person("Eric", "Bates", 39),
                                new Person("Laura", "Schultz", 132)});
            int actual, expected = -1;

            //Act
            actual = customLinkedList.FindIndex(1, 5, p => (p.FirstName == "Jason" && p.LastName == "Bourne"));

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void FindIndex_LauraSchultzStartAt6Count5_ExpectSix()
        {
            //Arrange
            var customLinkedList = new CustomLinkedList<Person>();
            customLinkedList.AddRange(new Person[] { new Person("John", "Doe", 19), new Person("Paul", "Wang", 54),
                                new Person("Eric", "Faulk", 19), new Person("John", "Doe", 112),
                                new Person("Jane", "Katz", 73),  new Person("Eric", "Faulk", 19),
                                new Person("Jason", "Bourne", 42),  new Person("Eric", "Faulk", 19),
                                new Person("Kate", "Chen", 55), new Person("Eric", "Bates", 39),
                                new Person("Laura", "Schultz", 132)});
            int actual, expected = 10;

            //Act
            actual = customLinkedList.FindIndex(6, 5, p => (p.FirstName == "Laura"));

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void FindIndex_LauraSchultzStartAt6Count4_ExpectNegativeOne()
        {
            //Arrange
            var customLinkedList = new CustomLinkedList<Person>();
            customLinkedList.AddRange(new Person[] { new Person("John", "Doe", 19), new Person("Paul", "Wang", 54),
                                new Person("Eric", "Faulk", 19), new Person("John", "Doe", 112),
                                new Person("Jane", "Katz", 73),  new Person("Eric", "Faulk", 19),
                                new Person("Jason", "Bourne", 42),  new Person("Eric", "Faulk", 19),
                                new Person("Kate", "Chen", 55), new Person("Eric", "Bates", 39),
                                new Person("Laura", "Schultz", 132)});
            int actual, expected = -1;

            //Act
            actual = customLinkedList.FindIndex(6, 4, p => (p.Id== 132));

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void FindAll_IdIs19OrLastNameIsShultz_ExpectCorrectString()
        {
            //Arrange
            var customLinkedList = new CustomLinkedList<Person>();
            customLinkedList.AddRange(new Person[] { new Person("John", "Doe", 19), new Person("Paul", "Wang", 54),
                                new Person("Eric", "Faulk", 19), new Person("John", "Doe", 112),
                                new Person("Jane", "Katz", 73),  new Person("Eric", "Faulk", 19),
                                new Person("Jason", "Bourne", 42),  new Person("Eric", "Faulk", 19),
                                new Person("Kate", "Chen", 55), new Person("Eric", "Bates", 39),
                                new Person("Laura", "Schultz", 132)});

            string actual, expected = "John Doe 19, Eric Faulk 19, Eric Faulk 19, Eric Faulk 19, Laura Schultz 132";

            //Act
            var returnedList = customLinkedList.FindAll(p => (p.Id == 19 || p.LastName == "Schultz"));
            actual = returnedList.ToString();

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void FindLast_LastIsAtTheBeginning_ExpectCorrectString()
        {
            //Arrange
            var customLinkedList = new CustomLinkedList<Person>();
            customLinkedList.AddRange(new Person[] { new Person("John", "Doe", 34), new Person("Paul", "Wang", 54),
                                new Person("Eric", "Faulk", 19), new Person("John", "Doe", 112),
                                new Person("Jane", "Katz", 73),  new Person("Eric", "Faulk", 19),
                                new Person("Jason", "Bourne", 42),  new Person("Abigail", "Faulk", 19),
                                new Person("Kate", "Chen", 55), new Person("Eric", "Bates", 39),
                                new Person("Laura", "Schultz", 132)});

            string actual, expected = "John Doe 34";

            //Act
            var returnedItem = customLinkedList.FindLast(p => (p.Id == 34 ));
            actual = returnedItem.ToString();

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void FindLast_LastIsInTheMiddle_ExpectCorrectString()
        {
            //Arrange
            var customLinkedList = new CustomLinkedList<Person>();
            customLinkedList.AddRange(new Person[] { new Person("John", "Doe", 19), new Person("Paul", "Wang", 54),
                                new Person("Eric", "Faulk", 19), new Person("John", "Doe", 112),
                                new Person("Jane", "Katz", 73),  new Person("Eric", "Faulk", 19),
                                new Person("Jason", "Bourne", 42),  new Person("Abigail", "Faulk", 19),
                                new Person("Kate", "Chen", 55), new Person("Eric", "Bates", 39),
                                new Person("Laura", "Schultz", 132)});

            string actual, expected = "Abigail Faulk 19";

            //Act
            var returnedItem = customLinkedList.FindLast(p => (p.Id == 19 || p.LastName == "Abigail"));
            actual = returnedItem.ToString();

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void FindLast_LastisAtTheEnd_ExpectCorrecString()
        {
            //Arrange
            var customLinkedList = new CustomLinkedList<Person>();
            customLinkedList.AddRange(new Person[] { new Person("John", "Doe", 19), new Person("Paul", "Wang", 54),
                                new Person("Eric", "Faulk", 19), new Person("John", "Doe", 112),
                                new Person("Jane", "Katz", 73),  new Person("Eric", "Faulk", 19),
                                new Person("Jason", "Bourne", 42),  new Person("Eric", "Faulk", 19),
                                new Person("Kate", "Chen", 55), new Person("Eric", "Bates", 39),
                                new Person("Laura", "Schultz", 132)});

            string actual, expected = "Laura Schultz 132";

            //Act
            var returnedItem = customLinkedList.FindLast(p => (p.Id == 19 || p.FirstName == "Laura"));
            actual = returnedItem.ToString();

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void FindLastIndex_WithoutIndexOrCountJanetLin_ExpectNegativeOne()
        {
            //Arrange
            var customLinkedList = new CustomLinkedList<Person>();
            customLinkedList.AddRange(new Person[] { new Person("John", "Doe", 19), new Person("Paul", "Wang", 54),
                                new Person("Eric", "Faulk", 19), new Person("John", "Doe", 112),
                                new Person("Jane", "Katz", 73),  new Person("Eric", "Faulk", 19),
                                new Person("Jason", "Bourne", 42),  new Person("Eric", "Faulk", 19),
                                new Person("Kate", "Chen", 55), new Person("Eric", "Bates", 39),
                                new Person("Laura", "Schultz", 132)});
            int actual, expected = -1;

            //Act
            actual = customLinkedList.FindLastIndex(p => (p.FirstName == "Janet" && p.LastName == "Lin"));

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void FindLastIndex_WithoutIndexOrCountLauraSchultz_Expect10()
        {
            //Arrange
            var customLinkedList = new CustomLinkedList<Person>();
            customLinkedList.AddRange(new Person[] { new Person("John", "Doe", 19), new Person("Paul", "Wang", 54),
                                new Person("Eric", "Faulk", 19), new Person("John", "Doe", 112),
                                new Person("Jane", "Katz", 73),  new Person("Eric", "Faulk", 19),
                                new Person("Jason", "Bourne", 42),  new Person("Eric", "Faulk", 19),
                                new Person("Kate", "Chen", 55), new Person("Eric", "Bates", 39),
                                new Person("Laura", "Schultz", 132)});
            int actual, expected = 10;

            //Act
            actual = customLinkedList.FindLastIndex(p => (p.LastName == "Schultz" || p.FirstName == "Laura"));

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void FindLastIndex_WithoutIndexOrCountEric19_Expect7()
        {
            //Arrange
            var customLinkedList = new CustomLinkedList<Person>();
            customLinkedList.AddRange(new Person[] { new Person("John", "Doe", 19), new Person("Paul", "Wang", 54),
                                new Person("Eric", "Faulk", 19), new Person("John", "Doe", 112),
                                new Person("Jane", "Katz", 73),  new Person("Eric", "Faulk", 19),
                                new Person("Jason", "Bourne", 42),  new Person("Eric", "Faulk", 19),
                                new Person("Kate", "Chen", 55), new Person("Eric", "Bates", 39),
                                new Person("Laura", "Schultz", 132)});
            int actual, expected = 9;

            //Act
            actual = customLinkedList.FindLastIndex(p => (p.Id == 19 || p.FirstName == "Eric"));

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void FindLastIndex_WithIndex4JanetLin_ExpectNegativeOne()
        {
            //Arrange
            var customLinkedList = new CustomLinkedList<Person>();
            customLinkedList.AddRange(new Person[] { new Person("John", "Doe", 19), new Person("Paul", "Wang", 54),
                                new Person("Eric", "Faulk", 19), new Person("John", "Doe", 112),
                                new Person("Jane", "Katz", 73),  new Person("Eric", "Faulk", 19),
                                new Person("Jason", "Bourne", 42),  new Person("Eric", "Faulk", 19),
                                new Person("Kate", "Chen", 55), new Person("Eric", "Bates", 39),
                                new Person("Laura", "Schultz", 132)});
            int actual, expected = -1;

            //Act
            actual = customLinkedList.FindLastIndex(4, p => (p.FirstName == "Janet" && p.LastName == "Lin"));

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void FindLastIndex_WithIndex10LauraSchultz_Expect10()
        {
            //Arrange
            var customLinkedList = new CustomLinkedList<Person>();
            customLinkedList.AddRange(new Person[] { new Person("John", "Doe", 19), new Person("Paul", "Wang", 54),
                                new Person("Eric", "Faulk", 19), new Person("John", "Doe", 112),
                                new Person("Jane", "Katz", 73),  new Person("Eric", "Faulk", 19),
                                new Person("Jason", "Bourne", 42),  new Person("Eric", "Faulk", 19),
                                new Person("Kate", "Chen", 55), new Person("Eric", "Bates", 39),
                                new Person("Laura", "Schultz", 132)});
            int actual, expected = 10;

            //Act
            actual = customLinkedList.FindLastIndex(10, p => (p.LastName == "Schultz" || p.FirstName == "Laura"));

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void FindLastIndex_WithIndex6Faulk_Expect5()
        {
            //Arrange
            var customLinkedList = new CustomLinkedList<Person>();
            customLinkedList.AddRange(new Person[] { new Person("John", "Doe", 19), new Person("Paul", "Wang", 54),
                                new Person("Eric", "Faulk", 19), new Person("John", "Doe", 112),
                                new Person("Jane", "Katz", 73),  new Person("Eric", "Faulk", 19),
                                new Person("Jason", "Bourne", 42),  new Person("Eric", "Faulk", 19),
                                new Person("Kate", "Chen", 55), new Person("Eric", "Bates", 39),
                                new Person("Laura", "Schultz", 132)});
            int actual, expected = 5;

            //Act
            actual = customLinkedList.FindLastIndex( 6, p => p.LastName == "Faulk");

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void FindLastIndex_WithIndex11Count7_Expect9()
        {
            //Arrange
            CustomLinkedList<int> customLinkedList = new CustomLinkedList<int>();
            customLinkedList.AddRange(new int[] { 2, 4, 3, 5, 6, 5, 8, 7, 5, 4, 9, 0, 2, 4, 5, 6, 6, 5, 3 });
            int actual, expected = 9;

            //Act
            actual = customLinkedList.FindLastIndex(11, 7,p => p==4);

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void FindLastIndex_WithIndex17Count14_Expect16()
        {
            //Arrange
            CustomLinkedList<int> customLinkedList = new CustomLinkedList<int>();
            customLinkedList.AddRange(new int[] { 2, 4, 3, 5, 6, 5, 8, 7, 5, 4, 9, 0, 2, 4, 5, 6, 6, 5, 3 });
            int actual, expected = 16;

            //Act
            actual = customLinkedList.FindLastIndex(17, 14, p => p == 6);

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void FindLastIndex_WithIndex14Count10_ExpectNegativeOne()
        {
            //Arrange
            CustomLinkedList<int> customLinkedList = new CustomLinkedList<int>();
            customLinkedList.AddRange(new int[] { 2, 4, 3, 5, 6, 5, 8, 7, 5, 4, 9, 0, 2, 4, 5, 6, 6, 5, 3 });
            int actual, expected = -1;

            //Act
            actual = customLinkedList.FindLastIndex(14, 10, p => p == 6);

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void FindLastIndex_WithIndex14Count12_Expect4()
        {
            //Arrange
            CustomLinkedList<int> customLinkedList = new CustomLinkedList<int>();
            customLinkedList.AddRange(new int[] { 2, 4, 3, 5, 6, 5, 8, 7, 5, 4, 9, 0, 2, 4, 5, 6, 6, 5, 3 });
            int actual, expected = 4;

            //Act
            actual = customLinkedList.FindLastIndex(14, 12, p => p == 6);

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ForEach_ChangeIds_ExpectCorrectToString()
        {
            //Arrange
            var customLinkedList = new CustomLinkedList<Person>();
            customLinkedList.AddRange(new Person[] { new Person("John", "Doe", 19), new Person("Paul", "Wang", 54),
                                new Person("Eric", "Faulk", 19), new Person("John", "Doe", 112),
                                new Person("Jane", "Katz", 73),  new Person("Eric", "Faulk", 19),
                                new Person("Jason", "Bourne", 42),  new Person("Eric", "Faulk", 19),
                                new Person("Kate", "Chen", 55), new Person("Eric", "Bates", 39),
                                new Person("Laura", "Schultz", 132)});

            string actual, expected = "John Doe 44, Paul Wang 54, Eric Faulk 44, John Doe 112, Jane Katz 73, " +
                "Eric Faulk 44, Jason Bourne 42, Eric Faulk 44, Kate Chen 55, Eric Bates 39, Laura Schultz 132";

            //Act
            customLinkedList.ForEach(p => p.Id = p.Id==19 ? 44:p.Id);
            actual = customLinkedList.ToString();

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void GetRange_4To8_ExpectCorrectToString()
        {
            //Arrange
            CustomLinkedList<int> customLinkedList = new CustomLinkedList<int>();
            customLinkedList.AddRange(new int[] { 2, 4, 3, 5, 6, 54, 56, 76, 77, 87, 88, 98, 890 });
            string actual, expected = "6, 54, 56, 76, 77";

            //Act
            var returnedList = customLinkedList.GetRange(4, 5);
            actual = returnedList.ToString();

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void GetRange_4To8_ExpectCorrectCount()
        {
            //Arrange
            CustomLinkedList<int> customLinkedList = new CustomLinkedList<int>();
            customLinkedList.AddRange(new int[] { 2, 4, 3, 5, 6, 54, 56, 76, 77, 87, 88, 98, 890 });
            int actual, expected = 13;

            //Act
            customLinkedList.GetRange(4, 5);
            actual = customLinkedList.Count;

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void GetRange_0To4_ExpectCorrectToString()
        {
            //Arrange
            CustomLinkedList<int> customLinkedList = new CustomLinkedList<int>();
            customLinkedList.AddRange(new int[] { 2, 4, 3, 5, 6, 54, 56, 76, 77, 87, 88, 98, 890 });
            string actual, expected = "2, 4, 3, 5, 6";

            //Act
            var returnedList = customLinkedList.GetRange(0, 5);
            actual = returnedList.ToString();

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void GetRange_0To4_ExpectCorrectReturnedListCount()
        {
            //Arrange
            CustomLinkedList<int> customLinkedList = new CustomLinkedList<int>();
            customLinkedList.AddRange(new int[] { 2, 4, 3, 5, 6, 54, 56, 76, 77, 87, 88, 98, 890 });
            int actual, expected = 5;

            //Act
            var returnedList = customLinkedList.GetRange(0, 5);
            actual = returnedList.Count;

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void GetRange_8ToEnd_ExpectCorrectToString()
        {
            //Arrange
            CustomLinkedList<int> customLinkedList = new CustomLinkedList<int>();
            customLinkedList.AddRange(new int[] { 2, 4, 3, 5, 6, 54, 56, 76, 77, 87, 88, 98, 890 });
            string actual, expected = "77, 87, 88, 98, 890";

            //Act
            var returnedList = customLinkedList.GetRange(8, 5);
            actual = returnedList.ToString();

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Indexer_GetVaueAtIndex0_Expect2()
        {
            //Arrange
            CustomLinkedList<int> customLinkedList = new CustomLinkedList<int>();
            customLinkedList.AddRange(new int[] { 2, 4, 3, 5, 6, 54, 56, 76, 77, 87, 88, 98, 890 });
            int actual, expected = 2;

            //Act
            actual = customLinkedList[0];

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Indexer_GetVaueAtIndex4_Expect6()
        {
            //Arrange
            CustomLinkedList<int> customLinkedList = new CustomLinkedList<int>();
            customLinkedList.AddRange(new int[] { 2, 4, 3, 5, 6, 54, 56, 76, 77, 87, 88, 98, 890 });
            int actual, expected = 6;

            //Act
            actual = customLinkedList[4];

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Indexer_GetVaueAtIndex12_Expect890()
        {
            //Arrange
            CustomLinkedList<int> customLinkedList = new CustomLinkedList<int>();
            customLinkedList.AddRange(new int[] { 2, 4, 3, 5, 6, 54, 56, 76, 77, 87, 88, 98, 890 });
            int actual, expected = 890;

            //Act
            actual = customLinkedList[12];

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Indexer_SetValueAtIndex0_ExpectCorrectToString()
        {
            //Arrange
            CustomLinkedList<int> customLinkedList = new CustomLinkedList<int>();
            customLinkedList.AddRange(new int[] { 2, 4, 3, 5, 6, 54, 56, 76, 77, 87, 88, 98, 890 });
            string actual, expected = "1000, 4, 3, 5, 6, 54, 56, 76, 77, 87, 88, 98, 890";

            //Act
            customLinkedList[0] = 1000;
            actual = customLinkedList.ToString();

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Indexer_SetValueAtIndex4_ExpectCorrectToString()
        {
            //Arrange
            CustomLinkedList<int> customLinkedList = new CustomLinkedList<int>();
            customLinkedList.AddRange(new int[] { 2, 4, 3, 5, 6, 54, 56, 76, 77, 87, 88, 98, 890 });
            string actual, expected = "2, 4, 3, 5, 1000, 54, 56, 76, 77, 87, 88, 98, 890";

            //Act
            customLinkedList[4] = 1000;
            actual = customLinkedList.ToString();

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Indexer_SetValueAtIndex12_ExpectCorrectToString()
        {
            //Arrange
            CustomLinkedList<int> customLinkedList = new CustomLinkedList<int>();
            customLinkedList.AddRange(new int[] { 2, 4, 3, 5, 6, 54, 56, 76, 77, 87, 88, 98, 890 });
            string actual, expected = "2, 4, 3, 5, 6, 54, 56, 76, 77, 87, 88, 98, 1000";

            //Act
            customLinkedList[12] = 1000;
            actual = customLinkedList.ToString();

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void IndexOf_210_ExpectNeghativeOne()
        {
            //Arrange
            CustomLinkedList<int> customLinkedList = new CustomLinkedList<int>();
            customLinkedList.AddRange(new int[] { 2, 4, 3, 5, 6, 5, 8, 7, 5, 4, 9, 0, 2, 4, 5, 6, 6, 5, 3, 7, 8, 9, 12, 34, 54, 56, 76, 77, 87, 88, 98, 890 });
            int actual, expected = -1;
            
            //Act
            actual = customLinkedList.IndexOf(210);

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void IndexOf_890_Expect31()
        {
            //Arrange
            CustomLinkedList<int> customLinkedList = new CustomLinkedList<int>();
            customLinkedList.AddRange(new int[] { 2, 4, 3, 5, 6, 5, 8, 7, 5, 4, 9, 0, 2, 4, 5, 6, 6, 5, 3, 7, 8, 9, 12, 34, 54, 56, 76, 77, 87, 88, 98, 890 });
            int actual, expected = 31;

            //Act
            actual = customLinkedList.IndexOf(890);

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void IndexOf_2_ExpectZero()
        {
            //Arrange
            CustomLinkedList<int> customLinkedList = new CustomLinkedList<int>();
            customLinkedList.AddRange(new int[] { 2, 4, 3, 5, 6, 5, 8, 7, 5, 4, 9, 0, 2, 4, 5, 6, 6, 5, 3, 7, 8, 9, 12, 34, 54, 56, 76, 77, 87, 88, 98, 890 });
            int actual, expected = 0;

            //Act
            actual = customLinkedList.IndexOf(2);

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void IndexOf_0_Expect11()
        {
            //Arrange
            CustomLinkedList<int> customLinkedList = new CustomLinkedList<int>();
            customLinkedList.AddRange(new int[] { 2, 4, 3, 5, 6, 5, 8, 7, 5, 4, 9, 0, 2, 4, 5, 6, 6, 5, 3, 7, 8, 9, 12, 34, 54, 56, 76, 77, 87, 88, 98, 890 });
            int actual, expected = 11;

            //Act
            actual = customLinkedList.IndexOf(0);

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void IndexOf_6_Expect4()
        {
            //Arrange
            CustomLinkedList<int> customLinkedList = new CustomLinkedList<int>();
            customLinkedList.AddRange(new int[] { 2, 4, 3, 5, 6, 5, 8, 7, 5, 4, 9, 0, 2, 4, 5, 6, 6, 5, 3, 7, 8, 9, 12, 34, 54, 56, 76, 77, 87, 88, 98, 890 });
            int actual, expected = 4;

            //Act
            actual = customLinkedList.IndexOf(6);

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void IndexOf_0StartAt12_ExpectNegativeOne()
        {
            //Arrange
            CustomLinkedList<int> customLinkedList = new CustomLinkedList<int>();
            customLinkedList.AddRange(new int[] { 2, 4, 3, 5, 6, 5, 8, 7, 5, 4, 9, 0, 2, 
                4, 5, 6, 6, 5, 3, 7, 8, 9, 12, 34, 54, 56, 76, 77, 87, 88, 98, 890 });
            int actual, expected = -1;

            //Act
            actual = customLinkedList.IndexOf(0,12);

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void IndexOf_6StartAt9_Expect15()
        {
            //Arrange
            CustomLinkedList<int> customLinkedList = new CustomLinkedList<int>();
            customLinkedList.AddRange(new int[] { 2, 4, 3, 5, 6, 5, 8, 7, 5, 4, 9, 0, 2, 4, 
                5, 6, 6, 5, 3, 7, 8, 9, 12, 34, 54, 56, 76, 77, 87, 88, 98, 890 });
            int actual, expected = 15;

            //Act
            actual = customLinkedList.IndexOf(6,9);

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void IndexOf_890StartAt12Count19_ExpectNegativeOne()
        {
            //Arrange
            CustomLinkedList<int> customLinkedList = new CustomLinkedList<int>();
            customLinkedList.AddRange(new int[] { 2, 4, 3, 5, 6, 5, 8, 7, 5, 4, 9, 0, 2,
                4, 5, 6, 6, 5, 3, 7, 8, 9, 12, 34, 54, 56, 76, 77, 87, 88, 98, 890 });
            int actual, expected = -1;

            //Act
            actual = customLinkedList.IndexOf(890, 12, 19);

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void IndexOf_890StartAt12Count20_Expect31()
        {
            //Arrange
            CustomLinkedList<int> customLinkedList = new CustomLinkedList<int>();
            customLinkedList.AddRange(new int[] { 2, 4, 3, 5, 6, 5, 8, 7, 5, 4, 9, 0, 2, 4,
                5, 6, 6, 5, 3, 7, 8, 9, 12, 34, 54, 56, 76, 77, 87, 88, 98, 890 });
            int actual, expected = 31;

            //Act
            actual = customLinkedList.IndexOf(890, 12, 20);

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Insert_12InMiddle_ExpectCorrectToString()
        {
            //Arrange
            CustomLinkedList<int> customLinkedList = new CustomLinkedList<int>();
            customLinkedList.AddRange(new int[] { 2, 4, 3, 5, 6, 54, 56, 76, 77, 87, 88, 98, 890 });
            string actual, expected = "2, 4, 3, 5, 6, 54, 12, 56, 76, 77, 87, 88, 98, 890";

            //Act
            customLinkedList.Insert(12, 6);
            actual = customLinkedList.ToString();

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Insert_12InMiddle_ExpectCorrectIndexOf()
        {
            //Arrange
            CustomLinkedList<int> customLinkedList = new CustomLinkedList<int>();
            customLinkedList.AddRange(new int[] { 2, 4, 3, 5, 6, 54, 56, 76, 77, 87, 88, 98, 890 });
            int actual, expected = 6;

            //Act
            customLinkedList.Insert(12, 6);
            actual = customLinkedList.IndexOf(12);

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Insert_12InMiddle_ExpectCorrectCountf()
        {
            //Arrange
            CustomLinkedList<int> customLinkedList = new CustomLinkedList<int>();
            customLinkedList.AddRange(new int[] { 2, 4, 3, 5, 6, 54, 56, 76, 77, 87, 88, 98, 890 });
            int actual, expected = 14;

            //Act
            customLinkedList.Insert(12, 6);
            actual = customLinkedList.Count;

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Insert_24AtEnd_ExpectCorrectToString()
        {
            //Arrange
            CustomLinkedList<int> customLinkedList = new CustomLinkedList<int>();
            customLinkedList.AddRange(new int[] { 2, 4, 3, 5, 6, 54, 56, 76, 77, 87, 88, 98, 890 });
            string actual, expected = "2, 4, 3, 5, 6, 54, 56, 76, 77, 87, 88, 98, 24, 890";

            //Act
            customLinkedList.Insert(24, 12);
            actual = customLinkedList.ToString();

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Insert_24AtEnd_ExpectCorrectIndexOf()
        {
            //Arrange
            CustomLinkedList<int> customLinkedList = new CustomLinkedList<int>();
            customLinkedList.AddRange(new int[] { 2, 4, 3, 5, 6, 54, 56, 76, 77, 87, 88, 98, 890 });
            int actual, expected = 12;

            //Act
            customLinkedList.Insert(24, 12);
            actual = customLinkedList.IndexOf(24);

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Insert_24AtEnd_ExpectCorrectCount()
        {
            //Arrange
            CustomLinkedList<int> customLinkedList = new CustomLinkedList<int>();
            customLinkedList.AddRange(new int[] { 2, 4, 3, 5, 6, 54, 56, 76, 77, 87, 88, 98, 890 });
            int actual, expected = 14;

            //Act
            customLinkedList.Insert(24, 12);
            actual = customLinkedList.Count;

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Insert_42AtBeginning_ExpectCorrectToString()
        {
            //Arrange
            CustomLinkedList<int> customLinkedList = new CustomLinkedList<int>();
            customLinkedList.AddRange(new int[] { 2, 4, 3, 5, 6, 54, 56, 76, 77, 87, 88, 98, 890 });
            string actual, expected = "42, 2, 4, 3, 5, 6, 54, 56, 76, 77, 87, 88, 98, 890";

            //Act
            customLinkedList.Insert(42, 0);
            actual = customLinkedList.ToString();

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Insert_42AtBeginning_ExpectCorrectIndexOf()
        {
            //Arrange
            CustomLinkedList<int> customLinkedList = new CustomLinkedList<int>();
            customLinkedList.AddRange(new int[] { 2, 4, 3, 5, 6, 54, 56, 76, 77, 87, 88, 98, 890 });
            int actual, expected = 0;

            //Act
            customLinkedList.Insert(42, 0);
            actual = customLinkedList.IndexOf(42);

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Insert_42AtBeginning_ExpectCorrectCount()
        {
            //Arrange
            CustomLinkedList<int> customLinkedList = new CustomLinkedList<int>();
            customLinkedList.AddRange(new int[] { 2, 4, 3, 5, 6, 54, 56, 76, 77, 87, 88, 98, 890 });
            int actual, expected = 14;

            //Act
            customLinkedList.Insert(42, 0);
            actual = customLinkedList.Count;

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void InsertRange_AtBeginning_ExpectCorrectString()
        {
            //Arrange
            CustomLinkedList<int> customLinkedList = new CustomLinkedList<int>();
            customLinkedList.Add(21);
            customLinkedList.Add(35);
            customLinkedList.Add(20);
            customLinkedList.Add(19);
            customLinkedList.Add(44);
            string actual, expected = "25, 28, 79, 21, 35, 20, 19, 44";

            //Act
            customLinkedList.InsertRange(new int[] { 25, 28, 79 }, 0);
            actual = customLinkedList.ToString();

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void InsertRange_InMiddle_ExpectCorrectString()
        {
            // Arrange
            CustomLinkedList<int> customLinkedList = new CustomLinkedList<int>();
            customLinkedList.Add(21);
            customLinkedList.Add(35);
            customLinkedList.Add(20);
            customLinkedList.Add(19);
            customLinkedList.Add(44);
            string actual, expected = "21, 35, 25, 28, 79, 20, 19, 44";

            //Act
            customLinkedList.InsertRange(new int[] { 25, 28, 79 }, 2);
            actual = customLinkedList.ToString();

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void InsertRange_AtLastIndex_ExpectCorrectString()
        {
            // Arrange
            CustomLinkedList<int> customLinkedList = new CustomLinkedList<int>();
            customLinkedList.Add(21);
            customLinkedList.Add(35);
            customLinkedList.Add(20);
            customLinkedList.Add(19);
            customLinkedList.Add(44);
            string actual, expected = "21, 35, 20, 19, 25, 28, 79, 44";

            //Act
            customLinkedList.InsertRange(new int[] { 25, 28, 79 }, 4);
            actual = customLinkedList.ToString();

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Remove_54InMiddle_ExpectCorrectToString()
        {
            //Arrange
            CustomLinkedList<int> customLinkedList = new CustomLinkedList<int>();
            customLinkedList.AddRange(new int[] { 2, 4, 3, 5, 6, 54, 56, 76, 77, 87, 88, 98, 890 });
            string actual, expected = "2, 4, 3, 5, 6, 56, 76, 77, 87, 88, 98, 890";

            //Act
            customLinkedList.Remove(54);
            actual = customLinkedList.ToString();

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Remove_54InMiddle_ExpectCorrectCount()
        {
            //Arrange
            CustomLinkedList<int> customLinkedList = new CustomLinkedList<int>();
            customLinkedList.AddRange(new int[] { 2, 4, 3, 5, 6, 54, 56, 76, 77, 87, 88, 98, 890 });
            int actual, expected = 12;

            //Act
            customLinkedList.Remove(54);
            actual = customLinkedList.Count;

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Remove_890AtEnd_ExpectCorrectToString()
        {
            //Arrange
            CustomLinkedList<int> customLinkedList = new CustomLinkedList<int>();
            customLinkedList.AddRange(new int[] { 2, 4, 3, 5, 6, 54, 56, 76, 77, 87, 88, 98, 890 });
            string actual, expected = "2, 4, 3, 5, 6, 54, 56, 76, 77, 87, 88, 98";

            //Act
            customLinkedList.Remove(890);
            actual = customLinkedList.ToString();

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Remove_890AtEnd_ExpectCorrectCount()
        {
            //Arrange
            CustomLinkedList<int> customLinkedList = new CustomLinkedList<int>();
            customLinkedList.AddRange(new int[] { 2, 4, 3, 5, 6, 54, 56, 76, 77, 87, 88, 98, 890 });
            int actual, expected = 12;

            //Act
            customLinkedList.Remove(890);
            actual = customLinkedList.Count;

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Remove_2AtBeginning_ExpectCorrectToString()
        {
            //Arrange
            CustomLinkedList<int> customLinkedList = new CustomLinkedList<int>();
            customLinkedList.AddRange(new int[] { 2, 4, 3, 5, 6, 54, 56, 76, 77, 87, 88, 98, 890 });
            string actual, expected = "4, 3, 5, 6, 54, 56, 76, 77, 87, 88, 98, 890";

            //Act
            customLinkedList.Remove(2);
            actual = customLinkedList.ToString();

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Remove_2AtBeginning_ExpectCorrectCount()
        {
            //Arrange
            CustomLinkedList<int> customLinkedList = new CustomLinkedList<int>();
            customLinkedList.AddRange(new int[] { 2, 4, 3, 5, 6, 54, 56, 76, 77, 87, 88, 98, 890 });
            int actual, expected = 12;

            //Act
            customLinkedList.Remove(2);
            actual = customLinkedList.Count;

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void RemoveAll_6_ExpectCorrectToString()
        {
            //Arrange
            CustomLinkedList<int> customLinkedList = new CustomLinkedList<int>();
            customLinkedList.AddRange(new int[] { 2, 66, 3, 5, 6, 54, 6, 6, 77, 87, 6, 98, 6, 6});
            string actual, expected = "2, 66, 3, 5, 54, 77, 87, 98";

            //Act
            customLinkedList.RemoveAll(6);
            actual = customLinkedList.ToString();

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void RemoveAll_6_ExpectCorrectCount()
        {
            //Arrange
            CustomLinkedList<int> customLinkedList = new CustomLinkedList<int>();
            customLinkedList.AddRange(new int[] { 2, 66, 3, 5, 6, 54, 6, 6, 77, 87, 6, 98, 6, 6});
            int actual, expected = 8;

            //Act
            customLinkedList.RemoveAll(6);
            actual = customLinkedList.Count;

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void RemoveAll_Lisa_ExpectCorrectToString()
        {
            //Arrange
            CustomLinkedList<string> customLinkedList = new CustomLinkedList<string>();
            customLinkedList.AddRange(new string[] {"Paul", "liSa", "Mark", "Eric", "Lisa", "Maggie", "Lisa", "Lisa", " ", "Kofi", "Lisa", "Abena", "Lisa", "Lisa"});
            string actual, expected = "Paul, liSa, Mark, Eric, Maggie,  , Kofi, Abena";

            //Act
            customLinkedList.RemoveAll("Lisa");
            actual = customLinkedList.ToString();

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void RemoveAll_Lisa_ExpectCorrectCount()
        {
            //Arrange
            CustomLinkedList<string> customLinkedList = new CustomLinkedList<string>();
            customLinkedList.AddRange(new string[] { "Paul", "liSa", "Mark", "Eric", "Lisa", "Maggie", "Lisa", "Lisa", " ", "Kofi", "Lisa", "Abena", "Lisa", "Lisa" });
            int actual, expected = 8;

            //Act
            customLinkedList.RemoveAll("Lisa");
            actual = customLinkedList.Count;

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void RemoveAll_StartsWithM_ExpectCorrectToString()
        {
            //Arrange
            var customLinkedList = new CustomLinkedList<string>();
            customLinkedList.AddRange(new string[] { "Paul", "liSa", "Mark", "Eric", "Lisa", "Maggie", "Lisa", "Lisa", " ", "Kofi", "Lisa", "Abena", "Lisa", "Lisa" });
            string actual, expected = "Paul, liSa, Eric, Lisa, Lisa, Lisa,  , Kofi, Lisa, Abena, Lisa, Lisa";

            //Act
            customLinkedList.RemoveAll(m => m.StartsWith('M'));
            actual = customLinkedList.ToString();

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void RemoveAll_StartsWithM_ExpectCorrectCount()
        {
            //Arrange
            var customLinkedList = new CustomLinkedList<string>();
            customLinkedList.AddRange(new string[] { "Paul", "liSa", "Mark", "Eric", "Lisa", "Maggie", "Lisa", "Lisa", " ", "Kofi", "Lisa", "Abena", "Lisa", "Lisa" });
            int actual, expected = 12;

            //Act
            customLinkedList.RemoveAll(m => m.StartsWith('M'));
            actual = customLinkedList.Count;

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void RemoveAll_EndssWithA_ExpectCorrectToString()
        {
            //Arrange
            var customLinkedList = new CustomLinkedList<string>();
            customLinkedList.AddRange(new string[] { "Paul", "liSa", "Mark", "Eric", "Lisa", "Maggie",
                                               "Lisa", "Lisa", " ", "Kofi", "Lisa", "Abena", "Lisa", "Lisa" });
            string actual, expected = "Paul, Mark, Eric, Maggie,  , Kofi";

            //Act
            customLinkedList.RemoveAll(m => m.EndsWith('a'));
            actual = customLinkedList.ToString();

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void RemoveAll_EndsWithA_ExpectCorrectCount()
        {
            //Arrange
            var customLinkedList = new CustomLinkedList<string>();
            customLinkedList.AddRange(new string[] { "Paul", "liSa", "Mark", "Eric", "Lisa", "Maggie", "Lisa", "Lisa", " ", "Kofi", "Lisa", "Abena", "Lisa", "Lisa" });
            int actual, expected = 6;

            //Act
            customLinkedList.RemoveAll(m => m.EndsWith('a'));
            actual = customLinkedList.Count;

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void RemoveAll_EndsWithA_ExpectCorrectReturnedCount()
        {
            //Arrange
            var customLinkedList = new CustomLinkedList<string>();
            customLinkedList.AddRange(new string[] { "Paul", "liSa", "Mark", "Eric", "Lisa", "Maggie", "Lisa", "Lisa", " ", "Kofi", "Lisa", "Abena", "Lisa", "Lisa" });
            int actual, expected = 8;

            //Act
            actual = customLinkedList.RemoveAll(m => m.EndsWith('a'));

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void RemoveAt_Index6_ExpectCorrectToString()
        {
            //Arrange
            CustomLinkedList<int> customLinkedList = new CustomLinkedList<int>();
            customLinkedList.AddRange(new int[] { 2, 4, 3, 5, 6, 54, 56, 76, 77, 87, 88, 98, 890 });
            string actual, expected = "2, 4, 3, 5, 6, 54, 76, 77, 87, 88, 98, 890";

            //Act
            customLinkedList.RemoveAt(6);
            actual = customLinkedList.ToString();

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void RemoveAt_Index6_ExpectCorrectCount()
        {
            //Arrange
            CustomLinkedList<int> customLinkedList = new CustomLinkedList<int>();
            customLinkedList.AddRange(new int[] { 2, 4, 3, 5, 6, 54, 56, 76, 77, 87, 88, 98, 890 });
            int actual, expected = 12;

            //Act
            customLinkedList.RemoveAt(6);
            actual = customLinkedList.Count;

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void RemoveAt_Index12ExpectCorrectToString()
        {
            //Arrange
            CustomLinkedList<int> customLinkedList = new CustomLinkedList<int>();
            customLinkedList.AddRange(new int[] { 2, 4, 3, 5, 6, 54, 56, 76, 77, 87, 88, 98, 890 });
            string actual, expected = "2, 4, 3, 5, 6, 54, 56, 76, 77, 87, 88, 98";

            //Act
            customLinkedList.RemoveAt(12);
            actual = customLinkedList.ToString();

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void RemoveAt_Index12_ExpectCorrectCount()
        {
            //Arrange
            CustomLinkedList<int> customLinkedList = new CustomLinkedList<int>();
            customLinkedList.AddRange(new int[] { 2, 4, 3, 5, 6, 54, 56, 76, 77, 87, 88, 98, 890 });
            int actual, expected = 12;

            //Act
            customLinkedList.RemoveAt(12);
            actual = customLinkedList.Count;

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void RemoveAt_Index0_ExpectCorrectToString()
        {
            //Arrange
            CustomLinkedList<int> customLinkedList = new CustomLinkedList<int>();
            customLinkedList.AddRange(new int[] { 2, 4, 3, 5, 6, 54, 56, 76, 77, 87, 88, 98, 890 });
            string actual, expected = "4, 3, 5, 6, 54, 56, 76, 77, 87, 88, 98, 890";

            //Act
            customLinkedList.RemoveAt(0);
            actual = customLinkedList.ToString();

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void RemoveAt_Index0_ExpectCorrectCount()
        {
            //Arrange
            CustomLinkedList<int> customLinkedList = new CustomLinkedList<int>();
            customLinkedList.AddRange(new int[] { 2, 4, 3, 5, 6, 54, 56, 76, 77, 87, 88, 98, 890 });
            int actual, expected = 12;

            //Act
            customLinkedList.RemoveAt(0);
            actual = customLinkedList.Count;

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void RemoveFirst_ExpectCorrectToString()
        {
            //Arrange
            CustomLinkedList<int> customLinkedList = new CustomLinkedList<int>();
            customLinkedList.AddRange(new int[] { 2, 4, 3, 5, 6, 54, 56, 76, 77, 87, 88, 98, 890 });
            string actual, expected = "4, 3, 5, 6, 54, 56, 76, 77, 87, 88, 98, 890";

            //Act
            customLinkedList.RemoveFirst();
            actual = customLinkedList.ToString();

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void RemoveFirst_ExpectCorrectCount()
        {
            //Arrange
            CustomLinkedList<int> customLinkedList = new CustomLinkedList<int>();
            customLinkedList.AddRange(new int[] { 2, 4, 3, 5, 6, 54, 56, 76, 77, 87, 88, 98, 890 });
            int actual, expected = 12;

            //Act
            customLinkedList.RemoveFirst();
            actual = customLinkedList.Count;

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void RemoveLast_ExpectCorrectToString()
        {
            //Arrange
            CustomLinkedList<int> customLinkedList = new CustomLinkedList<int>();
            customLinkedList.AddRange(new int[] { 2, 4, 3, 5, 6, 54, 56, 76, 77, 87, 88, 98, 890 });
            string actual, expected = "2, 4, 3, 5, 6, 54, 56, 76, 77, 87, 88, 98";

            //Act
            customLinkedList.RemoveLast();
            actual = customLinkedList.ToString();

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void RemoveLast_ExpectCorrectCount()
        {
            //Arrange
            CustomLinkedList<int> customLinkedList = new CustomLinkedList<int>();
            customLinkedList.AddRange(new int[] { 2, 4, 3, 5, 6, 54, 56, 76, 77, 87, 88, 98, 890 });
            int actual, expected = 12;

            //Act
            customLinkedList.RemoveLast();
            actual = customLinkedList.Count;

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void RemoveRange_WithouthCountAtIndex4_ExpectCorrectToString()
        {
            //Arrange
            CustomLinkedList<int> customLinkedList = new CustomLinkedList<int>();
            customLinkedList.AddRange(new int[] { 2, 4, 3, 5, 6, 54, 56, 76, 77, 87, 88, 98, 890 });
            string actual, expected = "2, 4, 3, 5";

            //Act
            customLinkedList.RemoveRange(4);
            actual = customLinkedList.ToString();

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void RemoveRange_WithouthCountAtIndex4_ExpectCorrectCount()
        {
            //Arrange
            CustomLinkedList<int> customLinkedList = new CustomLinkedList<int>();
            customLinkedList.AddRange(new int[] { 2, 4, 3, 5, 6, 54, 56, 76, 77, 87, 88, 98, 890 });
            int actual, expected = 4;

            //Act
            customLinkedList.RemoveRange(4);
            actual = customLinkedList.Count;

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void RemoveRange_WithouthCountAtIndex0_ExpectCorrectToString()
        {
            //Arrange
            CustomLinkedList<int> customLinkedList = new CustomLinkedList<int>();
            customLinkedList.AddRange(new int[] { 2, 4, 3, 5, 6, 54, 56, 76, 77, 87, 88, 98, 890 });
            string actual, expected = "";

            //Act
            customLinkedList.RemoveRange(0);
            actual = customLinkedList.ToString();

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void RemoveRange_WithouthCountAtIndex0_ExpectCorrectCount()
        {
            //Arrange
            CustomLinkedList<int> customLinkedList = new CustomLinkedList<int>();
            customLinkedList.AddRange(new int[] { 2, 4, 3, 5, 6, 54, 56, 76, 77, 87, 88, 98, 890 });
            int actual, expected = 0;

            //Act
            customLinkedList.RemoveRange(0);
            actual = customLinkedList.Count;

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void RemoveRange_WithouthCountAtIndex12_ExpectCorrectToString()
        {
            //Arrange
            CustomLinkedList<int> customLinkedList = new CustomLinkedList<int>();
            customLinkedList.AddRange(new int[] { 2, 4, 3, 5, 6, 54, 56, 76, 77, 87, 88, 98, 890 });
            string actual, expected = "2, 4, 3, 5, 6, 54, 56, 76, 77, 87, 88, 98";

            //Act
            customLinkedList.RemoveRange(12);
            actual = customLinkedList.ToString();

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void RemoveRange_WithouthCountAtIndex12_ExpectCorrectCount()
        {
            //Arrange
            CustomLinkedList<int> customLinkedList = new CustomLinkedList<int>();
            customLinkedList.AddRange(new int[] { 2, 4, 3, 5, 6, 54, 56, 76, 77, 87, 88, 98, 890 });
            int actual, expected = 12;

            //Act
            customLinkedList.RemoveRange(12);
            actual = customLinkedList.Count;

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void RemoveRange_4To8_ExpectCorrectToString()
        {
            //Arrange
            CustomLinkedList<int> customLinkedList = new CustomLinkedList<int>();
            customLinkedList.AddRange(new int[] { 2, 4, 3, 5, 6, 54, 56, 76, 77, 87, 88, 98, 890 });
            string actual, expected = "2, 4, 3, 5, 87, 88, 98, 890";

            //Act
            customLinkedList.RemoveRange(4, 5);
            actual = customLinkedList.ToString();

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void RemoveRange_4To8_ExpectCorrectCount()
        {
            //Arrange
            CustomLinkedList<int> customLinkedList = new CustomLinkedList<int>();
            customLinkedList.AddRange(new int[] {2, 4, 3, 5, 6, 54, 56, 76, 77, 87, 88, 98, 890});
            int actual, expected = 8;

            //Act
            customLinkedList.RemoveRange(4, 5);
            actual = customLinkedList.Count;

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void RemoveRange_0To4_ExpectCorrectToString()
        {
            //Arrange
            CustomLinkedList<int> customLinkedList = new CustomLinkedList<int>();
            customLinkedList.AddRange(new int[] {2, 4, 3, 5, 6, 54, 56, 76, 77, 87, 88, 98, 890 });
            string actual, expected = "54, 56, 76, 77, 87, 88, 98, 890";

            //Act
            customLinkedList.RemoveRange(0,5);
            actual = customLinkedList.ToString();

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void RemoveRange_0To4_ExpectCorrectReturnedToString()
        {
            //Arrange
            CustomLinkedList<int> customLinkedList = new CustomLinkedList<int>();
            customLinkedList.AddRange(new int[] { 2, 4, 3, 5, 6, 54, 56, 76, 77, 87, 88, 98, 890 });
            string actual, expected = "2, 4, 3, 5, 6";

            //Act
            var returnedList = customLinkedList.RemoveRange(0, 5);
            actual = returnedList.ToString();

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void RemoveRange_0To4_ExpectCorrectCount()
        {
            //Arrange
            CustomLinkedList<int> customLinkedList = new CustomLinkedList<int>();
            customLinkedList.AddRange(new int[] {2, 4, 3, 5, 6, 54, 56, 76, 77, 87, 88, 98, 890 });
            int actual, expected = 8;

            //Act
            customLinkedList.RemoveRange(0, 5);
            actual = customLinkedList.Count;

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void RemoveRange_8ToEnd_ExpectCorrectToString()
        {
            //Arrange
            CustomLinkedList<int> customLinkedList = new CustomLinkedList<int>();
            customLinkedList.AddRange(new int[] { 2, 4, 3, 5, 6, 54, 56, 76, 77, 87, 88, 98, 890 });
            string actual, expected = "2, 4, 3, 5, 6, 54, 56, 76";

            //Act
            customLinkedList.RemoveRange(8, 5); 
            actual = customLinkedList.ToString();

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void RemoveRange_8ToEnd_ExpectCorrectReturnedToString()
        {
            //Arrange
            CustomLinkedList<int> customLinkedList = new CustomLinkedList<int>();
            customLinkedList.AddRange(new int[] { 2, 4, 3, 5, 6, 54, 56, 76, 77, 87, 88, 98, 890 });
            string actual, expected = "77, 87, 88, 98, 890";

            //Act
            var returnedList = customLinkedList.RemoveRange(8, 5);
            actual = returnedList.ToString();

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void RemoveRange_8ToEnd_ExpectCorrectCount()
        {
            //Arrange
            CustomLinkedList<int> customLinkedList = new CustomLinkedList<int>();
            customLinkedList.AddRange(new int[] { 2, 4, 3, 5, 6, 54, 56, 76, 77, 87, 88, 98, 890 });
            int actual, expected = 8;

            //Act
            customLinkedList.RemoveRange(8, 5);
            actual = customLinkedList.Count;

            //Assert
            Assert.AreEqual(expected, actual);
        }



        [TestMethod]
        public void Reverse_IntList4ToEnd_ExpectCorrectString()
        {
            //Arrange
            var customLinkedList = new CustomLinkedList<int>();
            customLinkedList.AddRange(new int[] { 2, 4, 3, 5, 6, 54, 56, 76, 77, 87, 88, 98, 890 });
            string actual, expected = "2, 4, 3, 5, 890, 98, 88, 87, 77, 76, 56, 54, 6";

            //Act
            customLinkedList.Reverse(4, 9);
            actual = customLinkedList.ToString();

            //Assert
            Assert.AreEqual(expected, actual);
        }

        public void Reverse_IntList4To8_ExpectCorrectString()
        {
            //Arrange
            var customLinkedList = new CustomLinkedList<int>();
            customLinkedList.AddRange(new int[] { 2, 4, 3, 5, 6, 54, 56, 76, 77, 87, 88, 98, 890 });
            string actual, expected = "2, 4, 3, 5, 77, 76, 56, 54, 6, 87, 88, 98, 890";

            //Act
            customLinkedList.Reverse(4, 5);
            actual = customLinkedList.ToString();

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Reverse_IntListEntireList_ExpectCorrectString()
        {
            //Arrange
            var customLinkedList = new CustomLinkedList<int>();
            customLinkedList.AddRange(new int[] { 2, 4, 3, 5, 6, 54, 56, 76, 77, 87, 88, 98, 890 });
            string actual, expected = "890, 98, 88, 87, 77, 76, 56, 54, 6, 5, 3, 4, 2";

            //Act
            customLinkedList.Reverse();
            actual = customLinkedList.ToString();

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Reverse_StringList4ToEnd_ExpectCorrectString()
        {
            //Arrange
            var customLinkedList = new CustomLinkedList<string>();
            customLinkedList.AddRange(new string[] { "Paul", "liSa", "Mark", "Eric", "Lisa", "Maggie",
                                               "Lisa", "Lisa", " ", "Kofi", "Lisa", "Abena", "Lisa", "Lisa" });
            string actual, expected = "Paul, liSa, Mark, Eric, Lisa, Lisa, Abena, Lisa, Kofi,  , Lisa, Lisa, Maggie, Lisa";

            //Act
            customLinkedList.Reverse(4, 10);
            actual = customLinkedList.ToString();

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Reverse_StringList4ToEnd_ExpectCorrectCount()
        {
            //Arrange
            var customLinkedList = new CustomLinkedList<string>();
            customLinkedList.AddRange(new string[] { "Paul", "liSa", "Mark", "Eric", "Lisa", "Maggie",
                                               "Lisa", "Lisa", " ", "Kofi", "Lisa", "Abena", "Lisa", "Lisa" });
            int actual, expected = 14;

            //Act
            customLinkedList.Reverse(4, 10);
            actual = customLinkedList.Count;

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Reverse_ObjectList4ToEnd_ExpectCorrectString()
        {
            //Arrange
            var customLinkedList = new CustomLinkedList<Person>();
            customLinkedList.AddRange(new Person[] { new Person("John", "Doe", 19), new Person("Paul", "Wang", 54),
                                new Person("Eric", "Faulk", 19), new Person("John", "Doe", 112),
                                new Person("Jane", "Katz", 73),  new Person("Eric", "Faulk", 19),
                                new Person("Jason", "Bourne", 42),  new Person("Eric", "Faulk", 19),
                                new Person("Kate", "Chen", 55), new Person("Eric", "Bates", 39),
                                new Person("Laura", "Schultz", 132)});

            string actual, expected = "John Doe 19, Paul Wang 54, Eric Faulk 19, John Doe 112, Laura Schultz 132, " +
                                      "Eric Bates 39, Kate Chen 55, Eric Faulk 19, Jason Bourne 42, Eric Faulk 19, Jane Katz 73";

            //Act
            customLinkedList.Reverse(4, 7);
            actual = customLinkedList.ToString();

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TrueForAll_CheckFor6_ExpectFalse()
        {
            //Arrange
            CustomLinkedList<int> customLinkedList = new CustomLinkedList<int>();
            customLinkedList.AddRange(new int[] { 2, 4, 3, 5, 6, 5, 8, 7, 5, 4, 9, 0, 2, 4, 5, 6, 6, 5, 3 });
            bool actual, expected = false;

            //Act
            actual = customLinkedList.TrueForAll(p => p == 6);

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TrueForAll_CheckFor6_ExpectTrue()
        {
            //Arrange
            CustomLinkedList<int> customLinkedList = new CustomLinkedList<int>();
            customLinkedList.AddRange(new int[] { 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6 });
            bool actual, expected = true;

            //Act
            actual = customLinkedList.TrueForAll(p => p == 6);

            //Assert
            Assert.AreEqual(expected, actual);
        }
    }
}
