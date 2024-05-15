using System;
using ExtendedDatabase;

namespace DatabaseExtended.Tests
{
    using NUnit.Framework;

    [TestFixture]
    public class ExtendedDatabaseTests
    {
        private Person testPerson;
        private const long maxValueId = long.MaxValue;
        private const long minValueId = long.MinValue;
        private Database testDatabase;

        [SetUp]
        public void Setup()
        {
            testDatabase = new Database();
        }

        //Testing of Class Person's Constructor

        [TestCase(maxValueId)]
        [TestCase(minValueId)]
        [TestCase(210319031941740174)]
        public void Test_ConstructorPersonTakesId_ShouldWork(long id)
        {
            testPerson = new Person(id, "Tonkata");

            long expectedId = id;
            long actualId = testPerson.Id;

            Assert.AreEqual(expectedId, actualId);
        }

        [TestCase("Tonkata")]
        [TestCase("JivkoAkulata")]
        [TestCase("Khan Ark ili Jana Tumnata")]
        public void Test_ConstructorPersonTakesName_ShouldWork(string name)
        {
            testPerson = new Person(111, name);

            string expectedName = name;
            string actualName = testPerson.UserName;

            Assert.AreEqual(expectedName, actualName);
        }

        //Testing of Class Database's Constructor
        //Assume AddRange Method is working
        [Test]
        public void Test_ConstructorDatabaseTakesPersonAndAddsIt_ShouldWork()
        {
            int counter = 16;
            Person[] expectedCollection = new Person[counter];

            for (int i = 1; i <= counter; i++)
            {
                testPerson = new Person(i, $"{i}");
                expectedCollection[i - 1] = testPerson;
                testDatabase.Add(testPerson);
            }

            int expectedPersonCount = expectedCollection.Length;
            int actualPersonCount = testDatabase.Count;

            Assert.AreEqual(expectedPersonCount, actualPersonCount);
        }

        [Test]
        public void Test_AddTakesPersonAndIncreasesCount_ShouldWork()
        {
            int counter = 10;
            Person[] expectedCollection = new Person[counter];

            for (int i = 1; i <= counter; i++)
            {
                testPerson = new Person(i, $"{i}");
                expectedCollection[i - 1] = testPerson;
                testDatabase.Add(testPerson);
            }

            int expectedPersonCount = expectedCollection.Length;
            int actualPersonCount = testDatabase.Count;

            Assert.AreEqual(expectedPersonCount, actualPersonCount);
        }

        [Test]
        public void Test_AddPersonWithExistingId_ShouldThrow()
        {
            int counter = 2;
            Person[] expectedCollection = new Person[counter];

            for (int i = 1; i <= counter; i++)
            {
                testPerson = new Person(i, $"{i}");
                expectedCollection[i - 1] = testPerson;
                testDatabase.Add(testPerson);
            }

            Assert.Throws<InvalidOperationException>(() => { testDatabase.Add(new Person(2, "Didkata")); },
                "There is already user with this Id!");
        }

        [Test]
        public void Test_AddPersonWithExistingName_ShouldThrow()
        {
            int counter = 2;
            Person[] expectedCollection = new Person[counter];

            for (int i = 1; i <= counter; i++)
            {
                testPerson = new Person(i, $"{i}");
                expectedCollection[i - 1] = testPerson;
                testDatabase.Add(testPerson);
            }

            Assert.Throws<InvalidOperationException>(() => { testDatabase.Add(new Person(3, $"{2}")); },
                "There is already user with this username!");
        }

        [Test]
        public void Test_AddPersonAfterMaxCount_ShouldThrow()
        {
            int counter = 16;

            for (int i = 1; i <= counter; i++)
            {
                testPerson = new Person(i, $"{i}");
                testDatabase.Add(testPerson);
            }

            Assert.Throws<InvalidOperationException>(() => { testDatabase.Add(new Person(17, "Tonkata")); },
                "Array's capacity must be exactly 16 integers!");
        }

        [Test]
        public void Test_RemovePersonAndReduceCount_ShouldWork()
        {
            int counter = 10;


            for (int i = 1; i <= counter; i++)
            {
                testPerson = new Person(i, $"{i}");
                testDatabase.Add(testPerson);
            }

            int remove = 3;

            for (int i = counter; i > counter - remove; i--)
            {
                testDatabase.Remove();
            }

            Person[] expectedCollection = new Person[counter - remove];
            for (int i = 1; i <= counter - remove; i++)
            {
                testPerson = new Person(i, $"{i}");
                expectedCollection[i - 1] = testPerson;
            }

            int expectedCount = expectedCollection.Length;
            int actualCount = testDatabase.Count;

            Assert.AreEqual(expectedCount, actualCount);
        }

        [TestCase(null)]
        public void Test_RemovePersonEmptyCollection_ShouldThrow(Person person)
        {
            Assert.Throws<InvalidOperationException>(() =>
            {
                testDatabase.Remove();
            });
        }

        [Test]
        public void Test_FindUserByUsername_ShouldThrow()
        {
            Assert.That(() => testDatabase.FindByUsername("Pesho"), Throws.InvalidOperationException);
        }
        
        [TestCase(null)]
        [TestCase("")]
        public void Test_FindByUsername_UserCantBeNull_ShouldThrow(string username)
        {            
            Assert.That(() => testDatabase.FindByUsername(username), Throws.ArgumentNullException);
        }
        
        [Test]
        public void Test_FindByUsername_ReturnsTheCorrectPerson()
        {
            int counter = 2;
            Person[] expectedCollection = new Person[counter];

            for (int i = 1; i <= counter; i++)
            {
                testPerson = new Person(i, $"{i}");
                expectedCollection[i - 1] = testPerson;
                testDatabase.Add(testPerson);
            }
            
            Person personToFind = testDatabase.FindByUsername("1");
            string expectedName = "1";
            string actualName = personToFind.UserName;
            
            Assert.AreEqual(expectedName, actualName);
        }
               
        [Test]
        public void FindById_ReturnsTheCorrectPerson()
        {
            int counter = 2;
            Person[] expectedCollection = new Person[counter];

            for (int i = 1; i <= counter; i++)
            {
                testPerson = new Person(i, $"{i}");
                expectedCollection[i - 1] = testPerson;
                testDatabase.Add(testPerson);
            }
            
            Person personToFind = testDatabase.FindById(1);
            long expectedId = 1;
            long actualId = personToFind.Id;
            
            Assert.AreEqual(expectedId, actualId);
        }

        [Test]
        public void Test_FindUserById_ShouldThrow()
        {
            Assert.That(() => testDatabase.FindById(666), Throws.InvalidOperationException);
        }
        
        [TestCase(-1)]
        [TestCase(-2000)]
        public void Test_FindByID_IdCantBeNull_ShouldThrow(long id)
        {
            Assert.Throws<ArgumentOutOfRangeException>(() =>
            {
                testDatabase.FindById(id);
            });
        }
    }
}