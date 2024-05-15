using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Threading;

namespace PlanetWars.Tests
{
    public class Tests
    {
        [TestFixture]
        public class PlanetWarsTests
        {
            private string _name;
            private double _price;
            private int _destructionLevel;
            private Weapon _weapon;
            private string _planetName;
            private double _budget;
            private List<Weapon> _weapons;
            private Planet _planet;

            [SetUp]
            public void Setup()
            {
                _name = "ChovekoUbieca";
                _price = 200;
                _destructionLevel = 10;
                _weapon = new Weapon(_name, _price, _destructionLevel);
                _planetName = "Andromeda";
                _budget = 10000;
                _weapons = new List<Weapon>();
                _planet = new Planet(_planetName, _budget);
            }

            // [TearDown]
            // public void TearDown()
            // {
            //     _planet = new Planet(_planetName, _budget);
            // }

            //Tests for class Weapon

            [Test]
            public void Test_ConstructorWeapon_ShouldWork()
            {
                Assert.AreEqual(_name, _weapon.Name);
                Assert.AreEqual(_price, _weapon.Price);
                Assert.AreEqual(_destructionLevel, _weapon.DestructionLevel);
            }

            // [Test]
            // public void Test_PropertyName_ShouldWork()
            // {
            //     _weapon.Name = "JivkoAkulata";
            //
            //     Assert.AreEqual("JivkoAkulata", _weapon.Name);
            // }

            [Test]
            [TestCase(-1)]
            [TestCase(-100)]
            public void Test_PropertyPrice_ShouldThrow(double price)
            {
                Assert.Throws<ArgumentException>(() => { _weapon = new Weapon(_name, price, _destructionLevel); },
                    "Price cannot be negative.");
            }

            [Test]
            public void Test_MethodIncreaseDestructionLevel_IncreasesDestructionLevel()
            {
                int increment = 5;

                for (int i = 0; i < increment; i++)
                {
                    _weapon.IncreaseDestructionLevel();
                }

                Assert.AreEqual(_destructionLevel + 5, _weapon.DestructionLevel);
            }

            [Test]
            [TestCase(10)]
            [TestCase(100)]
            [TestCase(9999)]
            public void Test_MethodNuclear_ShouldBeTrue(int destructionLevel)
            {
                _weapon = new Weapon(_name, _price, destructionLevel);

                Assert.IsTrue(_weapon.IsNuclear);
            }

            [Test]
            [TestCase(9)]
            [TestCase(0)]
            [TestCase(-1)]
            public void Test_MethodNuclear_ShouldBeFalse(int destructionLevel)
            {
                _weapon = new Weapon(_name, _price, destructionLevel);

                Assert.IsFalse(_weapon.IsNuclear);
            }

            //Tests for class Planet

            [Test]
            public void Test_ConstructorPlanet_ShouldWork()
            {
                Assert.AreEqual(_planetName, _planet.Name);
                Assert.AreEqual(_budget, _planet.Budget);
                Assert.AreEqual(_weapons, _planet.Weapons);
            }

            [Test]
            [TestCase(null)]
            [TestCase("")]
            public void Test_PropertyName_ShouldThrow(string name)
            {
                Assert.Throws<ArgumentException>(() => { _planet = new Planet(name, _budget); }, "Invalid planet Name");
            }

            [Test]
            [TestCase(-1)]
            [TestCase(-200)]
            public void Test_PropertyBudget_ShouldThrow(double budget)
            {
                Assert.Throws<ArgumentException>(() => { _planet = new Planet(_name, budget); },
                    "Budget cannot drop below Zero!");
            }

            [Test]
            public void Test_WeaponCollection_ReturnsIReadOnly()
            {
                Weapon _weaponTwo = new Weapon("JivkoAkulata", 200, 11);

                _weapons.Add(_weapon);
                _weapons.Add(_weaponTwo);
                
                _planet.AddWeapon(_weapon);
                _planet.AddWeapon(_weaponTwo);

                CollectionAssert.AreEqual(_weapons, _planet.Weapons);
            }

            [Test]
            public void Test_MilitaryPowerRatio_ShouldSum()
            {
                Weapon _weaponTwo = new Weapon("JivkoAkulata", 200, 11);
                _planet.AddWeapon(_weapon);
                _planet.AddWeapon(_weaponTwo);

                Assert.AreEqual(_destructionLevel + _weaponTwo.DestructionLevel, _planet.MilitaryPowerRatio);
            }

            [Test]
            public void Test_Profit_ShouldAddToBudget()
            {
                _budget += 100;

                _planet.Profit(100);

                Assert.AreEqual(_budget, _planet.Budget);
            }

            [Test]
            public void Test_SpendFunds_ShouldRemoveFromBudget()
            {
                _budget -= 100;

                _planet.SpendFunds(100);

                Assert.AreEqual(_budget, _planet.Budget);
            }

            [Test]
            [TestCase(10001)]
            [TestCase(1000000)]
            public void Test_SpendFunds_ShouldThrow(double amount)
            {
                _budget -= amount;

                Assert.Throws<InvalidOperationException>(() => { _planet.SpendFunds(amount); },
                    "Not enough funds to finalize the deal.");
            }

            [Test]
            public void Test_AddWeapon_ShouldWork()
            {
                _planet.AddWeapon(_weapon);

                _weapons.Add(_weapon);

                CollectionAssert.AreEqual(_weapons, _planet.Weapons);
            }

            [Test]
            public void Test_AddWeapon_ShouldThrow()
            {
                _planet = new Planet(_planetName, _budget);
                _planet.AddWeapon(_weapon);

                Assert.Throws<InvalidOperationException>(() => { _planet.AddWeapon(_weapon); },
                    $"There is already a {_weapon.Name} weapon.");
            }

            [Test]
            public void Test_RemoveWeapon_ShouldWork()
            {
                _planet.AddWeapon(_weapon);

                _planet.RemoveWeapon(_weapon.Name);

                CollectionAssert.AreEqual(_weapons, _planet.Weapons);
            }

            [Test]
            public void Test_UpdateWeapon_ShouldWork()
            {
                _planet.AddWeapon(_weapon);

                _planet.UpgradeWeapon(_weapon.Name);

                Assert.AreEqual(_destructionLevel+1, _weapon.DestructionLevel);
            }

            [Test]
            public void Test_UpdateWeapon_ShouldThrow()
            {
                Assert.Throws<InvalidOperationException>(() => { _planet.UpgradeWeapon(_weapon.Name); },
                    $"{_weapon.Name} does not exist in the weapon repository of {_name}");
            }

            [Test]
            public void Test_DestructOpponent_ShouldWork()
            {
                Planet _planetOpponent = new Planet("Uranus", 10000);
                _planet.AddWeapon(_weapon);

                string expectedOutput = $"Uranus is destructed!";
                string actualOutput = _planet.DestructOpponent(_planetOpponent);

                Assert.AreEqual(expectedOutput, actualOutput);
            }

            [Test]
            public void Test_DestructOpponent_ShouldThrow()
            {
                Planet _planetOpponent = new Planet("Uranus", 10000);

                _planetOpponent.AddWeapon(_weapon);

                Assert.Throws<InvalidOperationException>(() => { _planet.DestructOpponent(_planetOpponent); },
                    $"Uranus is too strong to declare war to!");
            }
        }
    }
}