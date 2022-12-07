using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace SmartphoneShop.Tests
{
    [TestFixture]
    public class SmartphoneShopTests
    {
        private Smartphone _smartphone;
        private string _smartphoneName;
        private int _maxBatteryLevel;
        private int _capacity;
        private Shop _shop;

        [SetUp]
        public void Setup()
        {
            _smartphoneName = "Samsung";
            _maxBatteryLevel = 100;
            _smartphone = new Smartphone(_smartphoneName, _maxBatteryLevel);
            _capacity = 15;
            _shop = new Shop(_capacity);
        }

        [Test]
        public void Test_ConstructorSmartphone_ShouldWork()
        {
            int expectedCurrent = _maxBatteryLevel;
            Assert.AreEqual(_smartphoneName, _smartphone.ModelName);
            Assert.AreEqual(expectedCurrent, _smartphone.CurrentBateryCharge);
            Assert.AreEqual(_maxBatteryLevel, _smartphone.MaximumBatteryCharge);
        }

        [Test]
        public void Test_ConstructorShop_ShouldWork()
        {
            Assert.AreEqual(_capacity, _shop.Capacity);
        }

        [Test]
        [TestCase(-1)]
        public void Test_PropertyCapacity_ShouldThrow(int capacity)
        {
            Assert.Throws<ArgumentException>(() => { _shop = new Shop(capacity); });
        }

        //Assumes Add method works
        [Test]
        public void Test_PropertyCount_IncreasesWithNewPhone()
        {
            _shop.Add(_smartphone);

            Assert.AreEqual(1, _shop.Count);
        }

        [Test]
        public void Test_MethodAdd_ShouldThrow_PhoneExists()
        {
            _shop.Add(_smartphone);

            Assert.Throws<InvalidOperationException>(() => { _shop.Add(_smartphone); });
        }

        [Test]
        public void Test_MethodAdd_ShouldThrow_CapacityIsFull()
        {
            for (int i = 0; i < _capacity; i++)
            {
                _shop.Add(new Smartphone($"{i}", _maxBatteryLevel));
            }

            Assert.Throws<InvalidOperationException>(() => { _shop.Add(_smartphone); });
        }

        [Test]
        public void Test_MethodRemove_ShouldWork_RemovesPhoneFromCollection()
        {
            _shop.Add(_smartphone);

            _shop.Remove(_smartphone.ModelName);

            Assert.AreEqual(0, _shop.Count);
        }

        [Test]
        public void Test_MethodRemove_ShouldThrow_PhoneNotInCollection()
        {
            Assert.Throws<InvalidOperationException>(() => { _shop.Remove("Penka"); });
        }

        [Test]
        public void Test_MethodTestPhone_ShouldWork_PhoneBatteryDrains()
        {
            int expectedCharge = _maxBatteryLevel - 50;
            _shop.Add(_smartphone);

            _shop.TestPhone(_smartphone.ModelName, 50);

            Assert.AreEqual(expectedCharge, _smartphone.CurrentBateryCharge);
        }

        [Test]
        public void Test_MethodTestPhone_ShouldThrow_PhoneNotInCollection()
        {
            _shop.Add(_smartphone);

            Assert.Throws<InvalidOperationException>(() => { _shop.TestPhone("Penka", 50); });
        }

        [Test]
        public void Test_MethodTestPhone_ShouldThrow_NotEnoughCharge()
        {
            _shop.Add(_smartphone);

            Assert.Throws<InvalidOperationException>(() =>
            {
                _shop.TestPhone(_smartphoneName, _maxBatteryLevel + 10);
            });
        }

        [Test]
        public void Test_MethodChargePhone_ShouldWork_PhoneBatteryCharges()
        {
            _shop.Add(_smartphone);
            _shop.TestPhone(_smartphone.ModelName, 10);

            _shop.ChargePhone(_smartphone.ModelName);

            Assert.AreEqual(_maxBatteryLevel, _smartphone.CurrentBateryCharge);
        }

        [Test]
        public void Test_MethodChargePhone_ShouldThrow_PhoneNotInCollection()
        {
            Assert.Throws<InvalidOperationException>(() => { _shop.ChargePhone("Penka"); });
        }
    }
}