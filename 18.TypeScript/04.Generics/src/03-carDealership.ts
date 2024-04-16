interface Dealership<T> {
    dealershipName: T;
    soldCars: number;
}

interface Actions<T> {
    sellCar(dealerID: T, model: T): void;
}

class CarDealership<T, V> implements Dealership<T>, Actions<V> {
    modelsSold: { [key: string]: V } = {};
    soldCars = 0;

    constructor(public dealershipName: T) {
    }

    sellCar(dealerID: V, model: V): void {
        if (!this.modelsSold.hasOwnProperty(`${dealerID}`)) {
            this.modelsSold[`${dealerID}`] = model;
        }

        this.soldCars++;
    }

    showDetails(): string {
        let details = `${this.dealershipName}:\n`;
        
        for (const dealerID in this.modelsSold) {
            const model = this.modelsSold[dealerID];
            details += `${dealerID} sold ${model}\n`;
        }
        return details;
    }
}

let dealership = new CarDealership('SilverStar');

dealership.sellCar('BG01', 'C Class');
dealership.sellCar('BG02', 'S Class');
dealership.sellCar('BG03', 'ML Class');
dealership.sellCar('BG04', 'CLK Class');
console.log(dealership.showDetails());
