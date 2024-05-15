using System;
using NUnit.Framework;

namespace Skeleton.Tests
{
    [TestFixture]
    public class DummyTests
    {
        private int health;
        private int experience;
        private Dummy _dummy;
        private Dummy deadDummy;

        [SetUp]
        public void Setup()
        {
            health = 10;
            experience = 10;
            _dummy = new Dummy(health, experience);
            deadDummy = new Dummy(-10, experience);
        }

        [Test]
        public void Test_DummyConstructor_ShouldWork()
        {
            Assert.AreEqual(health, _dummy.Health);
        }

        [Test]
        public void Test_DummyLosesHealthWhenAttacked_ShouldWork()
        {
            _dummy.TakeAttack(5);

            Assert.AreEqual(health - 5, _dummy.Health);
        }

        [Test]
        public void Test_DummyLosesHealthWhenAttackedButIsDead_ShouldThrow()
        {
            Assert.Throws<InvalidOperationException>(() =>
            {
                deadDummy.TakeAttack(_dummy.Health);
            });
        }

        [Test]
        public void Test_DummyGivesExperienceWhenDead_ShouldWork()
        {
            Assert.AreEqual(deadDummy.GiveExperience(), experience);
        }

        [Test]
        public void Test_DummyGivesExperienceWhenAlive_ShouldThrow()
        {
            Assert.Throws<InvalidOperationException>(() =>
            {
                _dummy.GiveExperience();
            });
        }

        [Test]
        public void Test_DummyIsDeadWhenHealthIsZero_ShouldBeDead()
        {
            _dummy = new Dummy(0, experience);

            Assert.That(_dummy.IsDead(), Is.EqualTo(true));
        }
        
        [Test]
        public void Test_DummyIsDeadWhenHealthIsNegativeNumber_ShouldBeDead()
        {
            Assert.That(deadDummy.IsDead(), Is.EqualTo(true));
        }
    }
}