using System;

namespace FightingArena.Tests
{
    using NUnit.Framework;
    using System.Collections.Generic;

    [TestFixture]
    public class ArenaTests
    {
        private Warrior _warriorOne;
        private Warrior _warriorTwo;
        private Arena _arena;
        private List<Warrior> _warriors;

        [SetUp]
        public void Setup()
        {
            _warriorOne = new Warrior("Dido", 15, 35);
            _warriorTwo = new Warrior("Toni", 12, 45);

            _warriors = new List<Warrior>();
        }

        [TearDown]
        public void TearDown()
        {
            _arena = new Arena();
        }

        [Test]
        public void Test_ArenaConstructorInitialisesCollection_ShouldWork()
        {
            _arena = new Arena();

            CollectionAssert.AreEqual(_warriors, _arena.Warriors);
        }

        //Assume Enroll method works!
        [Test]
        public void Test_CountPropertyReturnsCollectionCount_ShouldWork()
        {
            _arena.Enroll(_warriorOne);
            _arena.Enroll(_warriorTwo);
            _warriors = new List<Warrior>() { _warriorOne, _warriorTwo };

            int expectedCount = _warriors.Count;
            int actualCount = _arena.Count;

            Assert.AreEqual(expectedCount, actualCount);
        }

        [Test]
        public void Test_EnrollMethodUpdatesTheCollection_ShouldWork()
        {
            _arena.Enroll(_warriorOne);
            _arena.Enroll(_warriorTwo);
            _warriors = new List<Warrior>() { _warriorOne, _warriorTwo };

            CollectionAssert.AreEqual(_warriors, _arena.Warriors);
        }


        [Test]
        public void Test_EnrollMethodCannotAddSameWarrior_ShouldThrow()
        {
            _arena = new Arena();
            _arena.Enroll(_warriorOne);

            Assert.Throws<InvalidOperationException>(() => { _arena.Enroll(_warriorOne); },
                "Warrior is already enrolled for the fights!");
        }

        [Test]
        public void Test_FightMethodAttackerVsDefender_ShouldWork()
        {
            _arena = new Arena();
            _arena.Enroll(_warriorOne);
            _arena.Enroll(_warriorTwo);

            int expectedHPOne = _warriorOne.HP - _warriorTwo.Damage;
            int expectedHPTwo = _warriorTwo.HP - _warriorOne.Damage;

            _arena.Fight("Dido", "Toni");

            Assert.IsTrue(_warriorOne.HP == expectedHPOne && _warriorTwo.HP == expectedHPTwo);
        }

        [Test]
        public void Test_FightMethodAttackerMissingName_ShouldThrow()
        {
            _arena = new Arena();
            _arena.Enroll(_warriorOne);
            _arena.Enroll(_warriorTwo);

            Assert.Throws<InvalidOperationException>(() => { _arena.Fight("Penka", _warriorTwo.Name); },
                "There is no fighter with name Penka enrolled for the fights!");
        }

        [Test]
        public void Test_FightMethodDefenderMissingName_ShouldThrow()
        {
            _arena = new Arena();
            _arena.Enroll(_warriorOne);
            _arena.Enroll(_warriorTwo);

            Assert.Throws<InvalidOperationException>(() => { _arena.Fight(_warriorOne.Name, "Penka"); },
                "There is no fighter with name Penka enrolled for the fights!");
        }
    }
}