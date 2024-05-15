class Car {
    private _brand: string;
    private _model: string;
    private _horsePower: number;

    public get brand() {
        return this._brand;
    }

    public set brand(value: string) {
        this._brand = value;
    }

    public get model() {
        return this._model;
    }

    public set model(value: string) {
        this._model = value;
    }

    public get horsePower() {
        return this._horsePower;
    }

    public set horsePower(value: number) {
        this._horsePower = value;
    }

    constructor(brand: string, model: string, horsePower: number) {
        this._brand = brand;
        this._model = model;
        this._horsePower = horsePower;
    }

    public printInfo() {
        console.log(`This car is: ${this._brand} ${this._model} - ${this._horsePower} HP.`);
    }
}

function solveCar(input: string): void {
    let [brand, model, horsePower] = input.split(' ');
    let car = new Car(brand, model, Number(horsePower));
    car.printInfo();
}

solveCar("Chevrolet Impala 390");
solveCar("Skoda Karoq 150");