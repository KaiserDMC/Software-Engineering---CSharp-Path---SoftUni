"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
exports.VendingMachine = void 0;
class VendingMachine {
    buttonCapacity;
    drinks;
    constructor(buttonCapacity) {
        this.buttonCapacity = buttonCapacity;
        this.drinks = [];
    }
    addDrink(drink) {
        if (this.drinks.length < this.buttonCapacity) {
            this.drinks.push(drink);
        }
    }
    removeDrink(name) {
        const index = this.drinks.findIndex(drink => drink.name === name);
        if (index !== -1) {
            this.drinks.splice(index, 1);
            return true;
        }
        return false;
    }
    getLongest() {
        const longestDrink = this.drinks.reduce((prev, current) => {
            return prev.volume > current.volume ? prev : current;
        });
        return longestDrink.toString();
    }
    getCheapest() {
        const cheapestDrink = this.drinks.reduce((prev, current) => {
            return prev.price < current.price ? prev : current;
        });
        return cheapestDrink.toString();
    }
    buyDrink(name) {
        const drink = this.drinks.find(drink => drink.name === name);
        if (drink) {
            return drink.toString();
        }
        else {
            return "This drink is not available.";
        }
    }
    get getCount() {
        return this.drinks.length;
    }
    report() {
        const drinks = this.drinks.map(drink => drink.toString()).join("\n");
        return `Drinks available:\n${drinks}`;
    }
}
exports.VendingMachine = VendingMachine;
//# sourceMappingURL=VendingMachine.js.map