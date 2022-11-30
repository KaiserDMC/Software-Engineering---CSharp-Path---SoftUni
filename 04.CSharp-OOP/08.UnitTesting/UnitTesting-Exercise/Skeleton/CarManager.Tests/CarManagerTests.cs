using System;

namespace CarManager.Tests
{
    using NUnit.Framework;

    [TestFixture]
    public class CarManagerTests
    {
        private Car _car;
        private string _make;
        private string _model;
        private double _fuelConsumption;
        private double _fuelAmount;
        private double _fuelCapacity;

        [SetUp]
        public void Setup()
        {
            _make = "VW";
            _model = "Polo";
            _fuelConsumption = 20;
            _fuelCapacity = 100;
            _fuelAmount = 0;

            _car = new Car(_make, _model, _fuelConsumption, _fuelCapacity);
        }

        [Test]
        public void Test_Constructor_ShouldWork()
        {
            Assert.AreEqual(_make, _car.Make);
            Assert.AreEqual(_model, _car.Model);
            Assert.AreEqual(_fuelConsumption, _car.FuelConsumption);
            Assert.AreEqual(_fuelCapacity, _car.FuelCapacity);
            Assert.AreEqual(_fuelAmount, _car.FuelAmount);
        }

        [TestCase(null)]
        [TestCase("")]
        public void Test_MakeProperty_ShouldThrow(string make)
        {
            Assert.Throws<ArgumentException>(() => { _car = new Car(make, _model, _fuelConsumption, _fuelCapacity); },
                "Make cannot be null or empty!");
        }

        [TestCase(null)]
        [TestCase("")]
        public void Test_ModelProperty_ShouldThrow(string model)
        {
            Assert.Throws<ArgumentException>(() => { _car = new Car(_make, model, _fuelConsumption, _fuelCapacity); },
                "Model cannot be null or empty!");
        }

        [TestCase(0)]
        [TestCase(-1)]
        [TestCase(-10000)]
        public void Test_FuelConsumptionProperty_ShouldThrow(double fuelConsumption)
        {
            Assert.Throws<ArgumentException>(() => { _car = new Car(_make, _model, fuelConsumption, _fuelCapacity); },
                "Fuel consumption cannot be zero or negative!");
        }

        //Assumes Refuel Method works!
        [TestCase(-1)]
        [TestCase(-10000)]
        public void Test_FuelAmountProperty_ShouldThrow(double fuelAmount)
        {
            Assert.Throws<ArgumentException>(() =>
            {
                _car = new Car(_make, _model, _fuelConsumption, _fuelCapacity);
                _car.Refuel(fuelAmount);
            }, "Fuel amount cannot be zero or negative!");
        }

        [TestCase(0)]
        [TestCase(-1)]
        [TestCase(-10000)]
        public void Test_FuelCapacityProperty_ShouldThrow(double fuelCapacity)
        {
            Assert.Throws<ArgumentException>(() => { _car = new Car(_make, _model, _fuelConsumption, fuelCapacity); },
                "Fuel capacity cannot be zero or negative!");
        }

        [Test]
        public void Test_RefuelWithAmountLowerThanCapacity_ShouldWork()
        {
            double amountToRefuel = 50;

            _car.Refuel(amountToRefuel);

            Assert.AreEqual(amountToRefuel, _car.FuelAmount);
        }

        [Test]
        public void Test_RefuelWithAmountHigherThanCapacity_ShouldWork()
        {
            double amountToRefuel = 200;

            _car.Refuel(amountToRefuel);

            Assert.AreEqual(_fuelCapacity, _car.FuelAmount);
        }

        [TestCase(0)]
        [TestCase(-1)]
        [TestCase(-10000)]
        public void Test_RefuelWithAmountZeroOrNegativeAmount_ShouldThrow(double amountToRefuel)
        {
            Assert.Throws<ArgumentException>(() => { _car.Refuel(amountToRefuel); },
                "Fuel amount cannot be zero or negative!");
        }

        [TestCase(500)]
        [TestCase(100)]
        [TestCase(0)]
        public void Test_DriveWithFuelNeededEqualOrLowerThanFuelAmount(double distance)
        {
            double amountToRefuel = 100;
            _car.Refuel(amountToRefuel);

            _car.Drive(distance);

            double expectedAmountLeft = amountToRefuel - ((distance / 100) * _fuelConsumption);
            double actualAmountLeft = _car.FuelAmount;

            Assert.AreEqual(expectedAmountLeft, actualAmountLeft);
        }

        [TestCase(5000)]
        [TestCase(1000)]
        public void Test_DriveWithFuelNeededHigherThanFuelAmount(double distance)
        {
            double amountToRefuel = 100;
            _car.Refuel(amountToRefuel);

            Assert.Throws<InvalidOperationException>(() => { _car.Drive(distance); },
                "You don't have enough fuel to drive!");
        }
    }
}