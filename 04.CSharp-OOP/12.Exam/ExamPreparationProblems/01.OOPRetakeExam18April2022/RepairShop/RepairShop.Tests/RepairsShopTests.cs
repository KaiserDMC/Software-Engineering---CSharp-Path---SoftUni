using System;
using NUnit.Framework;

namespace RepairShop.Tests
{
    public class Tests
    {
        public class RepairsShopTests
        {
            [Test]
            public void TestConstructor_Car()
            {
                // Arrange
                var carModel = "Ford";
                var numberOfIssues = 2;

                // Act
                var car = new Car(carModel, numberOfIssues);

                // Assert
                Assert.AreEqual(carModel, car.CarModel);
                Assert.AreEqual(numberOfIssues, car.NumberOfIssues);
            }

            [Test]
            public void TestIsFixed()
            {
                // Arrange
                var car1 = new Car("Ford", 2);
                var car2 = new Car("Toyota", 0);

                // Act
                var isCar1Fixed = car1.IsFixed;
                var isCar2Fixed = car2.IsFixed;

                // Assert
                Assert.IsFalse(isCar1Fixed);
                Assert.IsTrue(isCar2Fixed);
            }


            [Test]
            public void TestConstructor_Garage()
            {
                // Arrange
                var name = "My Garage";
                var mechanicsAvailable = 3;

                // Act
                var garage = new Garage(name, mechanicsAvailable);

                // Assert
                Assert.AreEqual(name, garage.Name);
                Assert.AreEqual(mechanicsAvailable, garage.MechanicsAvailable);
                Assert.AreEqual(0, garage.CarsInGarage);
            }

            [Test]
            public void TestAddCar()
            {
                // Arrange
                var garage = new Garage("My Garage", 2);
                var car1 = new Car("Ford", 2);
                var car2 = new Car("Toyota", 3);

                // Act
                garage.AddCar(car1);
                garage.AddCar(car2);

                // Assert
                Assert.AreEqual(2, garage.CarsInGarage);
            }

            [Test]
            public void TestAddCar_NoMechanicsAvailable()
            {
                // Arrange
                var garage = new Garage("My Garage", 1);
                var car1 = new Car("Ford", 2);
                var car2 = new Car("Toyota", 3);

                garage.AddCar(car1);

                // Act and Assert
                var ex = Assert.Throws<InvalidOperationException>(() => garage.AddCar(car2));
                Assert.AreEqual("No mechanic available.", ex.Message);
            }

            [Test]
            public void TestFixCar()
            {
                // Arrange
                var garage = new Garage("My Garage", 2);
                var car1 = new Car("Ford", 2);
                var car2 = new Car("Toyota", 3);

                garage.AddCar(car1);
                garage.AddCar(car2);

                // Act
                var fixedCar = garage.FixCar("Ford");

                // Assert
                Assert.AreEqual("Ford", fixedCar.CarModel);
                Assert.AreEqual(0, fixedCar.NumberOfIssues);
            }

            [Test]
            public void TestFixCar_CarDoesNotExist()
            {
                // Arrange
                var garage = new Garage("My Garage", 2);
                var car1 = new Car("Ford", 2);
                var car2 = new Car("Toyota", 3);

                garage.AddCar(car1);
                garage.AddCar(car2);

                // Act and Assert
                var ex = Assert.Throws<InvalidOperationException>(() => garage.FixCar("Honda"));
                Assert.AreEqual("The car Honda doesn't exist.", ex.Message);
            }

            [Test]
            public void TestRemoveFixedCar()
            {
                // Arrange
                var garage = new Garage("My Garage", 2);
                var car1 = new Car("Ford", 2);
                var car2 = new Car("Toyota", 0);

                garage.AddCar(car1);
                garage.AddCar(car2);

                // Act
                var removedCars = garage.RemoveFixedCar();

                // Assert
                Assert.AreEqual(1, removedCars);
                Assert.AreEqual(1, garage.CarsInGarage);
            }

            [Test]
            public void TestRemoveFixedCar_NoFixedCars()
            {
                // Arrange
                var garage = new Garage("My Garage", 2);
                var car1 = new Car("Ford", 2);
                var car2 = new Car("Toyota", 3);

                garage.AddCar(car1);
                garage.AddCar(car2);

                // Act and Assert
                var ex = Assert.Throws<InvalidOperationException>(() => garage.RemoveFixedCar());
                Assert.AreEqual("No fixed cars available.", ex.Message);
            }
        }
    }
}
