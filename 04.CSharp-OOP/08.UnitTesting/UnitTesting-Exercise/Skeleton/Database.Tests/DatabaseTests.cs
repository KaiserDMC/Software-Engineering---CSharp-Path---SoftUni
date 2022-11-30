using System;

namespace Database.Tests
{
    using NUnit.Framework;

    [TestFixture]
    public class DatabaseTests
    {
        private Database _database;

        [SetUp]
        public void Setup()
        {
            _database = new Database();
        }

        //Assume Fetch is working
        [TestCase(new int[] { })]
        [TestCase(new int[] { 1, 2, 3 })]
        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16 })]
        public void Test_ConstructorTakesIntArrayAddsToNewArray_ShouldWork(int[] data)
        {
            Database dataB = new Database(data);

            int[] expectedData = data;
            int[] actualData = dataB.Fetch();

            CollectionAssert.AreEqual(expectedData, actualData);
        }

        //Assume Fetch is working
        [TestCase(new int[] { })]
        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16 })]
        public void Test_ConstructorTakesIntArrayAddsToNewArray_CountIsCorrect(int[] data)
        {
            Database dataB = new Database(data);

            int expectedCount = data.Length;
            int actualCount = dataB.Count;

            Assert.AreEqual(expectedCount, actualCount);
        }

        //Assume Fetch is working
        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 20, 21, 22 })]
        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17 })]
        public void Test_ConstructorTakesIntArrayAddsToNewArray_ShouldThrow(int[] data)
        {
            Assert.Throws<InvalidOperationException>(() =>
            {
                Database dataB = new Database(data);

                int[] expectedData = data;
                int[] actualData = dataB.Fetch();

                CollectionAssert.AreEqual(expectedData, actualData);
            }, "Array's capacity must be exactly 16 integers!");
        }

        //Assume Fetch is working
        [Test]
        public void Test_AddsElementsToTheCollection_ShouldWork()
        {
            int elementLength = 16;
            int[] expectedCollection = new int[elementLength];

            for (int i = 1; i <= elementLength; i++)
            {
                _database.Add(i);
                expectedCollection[i - 1] = i;
            }

            int[] actualCollection = _database.Fetch();

            CollectionAssert.AreEqual(expectedCollection, actualCollection);
        }

        //Assume Fetch is working
        [Test]
        public void Test_AddsElementsToTheCollection_ShouldThrow()
        {
            int elementLength = 17;
            int[] expectedCollection = new int[elementLength];

            Assert.Throws<InvalidOperationException>(() =>
            {
                for (int i = 1; i <= elementLength; i++)
                {
                    _database.Add(i);
                    expectedCollection[i - 1] = i;
                }
            }, "Array's capacity must be exactly 16 integers!");
        }

        //Assume Fetch is working
        [Test]
        public void Test_RemovesElementsFromTheCollection_ShouldWork()
        {
            int elementLength = 16;
            int[] expectedCollection = new int[elementLength - 5];

            for (int i = 1; i <= elementLength; i++)
            {
                _database.Add(i);
            }

            for (int i = elementLength; i > elementLength - 5; i--)
            {
                _database.Remove();
            }

            for (int i = 1; i <= elementLength - 5; i++)
            {
                expectedCollection[i - 1] = i;
            }

            int[] actualCollection = _database.Fetch();

            int expectedCount = expectedCollection.Length;
            int actualCount = _database.Count;

            CollectionAssert.AreEqual(expectedCollection, actualCollection);

            Assert.AreEqual(expectedCount, actualCount);
        }

        [TestCase(new int[] { })]
        public void Test_RemovesElementsFromTheCollection_ShouldThrow(int[] data)
        {
            Assert.Throws<InvalidOperationException>(() =>
            {
                _database = new Database(data);
                _database.Remove();
            }, "The collection is empty!");
        }

        [TestCase(new int[] { })]
        [TestCase(new int[] { 1, 2, 3 })]
        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16 })]
        public void Test_FetchReturnsTheCollection_ShouldWork(int[] data)
        {
            _database = new Database(data);

            int[] expectedCollection = data;

            int[] actualCollection = _database.Fetch();

            CollectionAssert.AreEqual(expectedCollection, actualCollection);
        }
    }
}