using System;
using NUnit.Framework;

namespace Skeleton.Tests
{
    [TestFixture]
    public class AxeTests
    {
        private int attackPoints;
        private int durabilityPoints;
        private Axe axe;
        private Dummy _dummy;

        [SetUp]
        public void Setup()
        {
            attackPoints = 10;
            durabilityPoints = 10;
            axe = new Axe(attackPoints, durabilityPoints);
            _dummy = new Dummy(1000, 1000);
        }

        [Test]
        public void Test_AxeConstructor_ShouldWork()
        {
            Assert.AreEqual(attackPoints, axe.AttackPoints);
            Assert.AreEqual(durabilityPoints, axe.DurabilityPoints);
        }

        [Test]
        public void Test_AxeDurabilityReducedAfterAttack_ShouldWork()
        {
            axe.Attack(_dummy);

            Assert.AreEqual(durabilityPoints - 1, axe.DurabilityPoints);
        }

        [Test]
        public void Test_AxeDurabilityZeroUnableToAttack_ShouldThrow()
        {
            Assert.Throws<InvalidOperationException>(() =>
            {
                while (axe.DurabilityPoints >= 0)
                {
                    axe.Attack(_dummy);
                }
            });
        }

        [Test]
        public void Test_AxeDurabilityBelowZeroUnableToAttack_ShouldThrow()
        {
            Assert.Throws<InvalidOperationException>(() =>
            {
                for (int i = 0; i < durabilityPoints + 10; i++)
                {
                    axe.Attack(_dummy);
                }
            });
        }

        [Test]
        public void Test_AxeIsCalledWithNullValueDummy_ShouldThrow()
        {
            Assert.Throws<NullReferenceException>(() =>
            {
                axe.Attack(null);
            });
        }
    }
}