"use strict";
class Car {
    _brand;
    _model;
    _horsePower;
    get brand() {
        return this._brand;
    }
    set brand(value) {
        this._brand = value;
    }
    get model() {
        return this._model;
    }
    set model(value) {
        this._model = value;
    }
    get horsePower() {
        return this._horsePower;
    }
    set horsePower(value) {
        this._horsePower = value;
    }
    constructor(brand, model, horsePower) {
        this._brand = brand;
        this._model = model;
        this._horsePower = horsePower;
    }
    printInfo() {
        console.log(`This car is: ${this._brand} ${this._model} - ${this._horsePower} HP.`);
    }
}
function solveCar(input) {
    let [brand, model, horsePower] = input.split(' ');
    let car = new Car(brand, model, Number(horsePower));
    car.printInfo();
}
solveCar("Chevrolet Impala 390");
solveCar("Skoda Karoq 150");
//# sourceMappingURL=01-carInfo.js.map