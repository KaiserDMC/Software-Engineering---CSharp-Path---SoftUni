import {Drink} from "./Drink";

export class VendingMachine {
    private buttonCapacity: number;
    private drinks: Drink[];

    constructor(buttonCapacity: number) {
        this.buttonCapacity = buttonCapacity;
        this.drinks = [];
    }

    addDrink(drink: Drink): void {
        if (this.drinks.length < this.buttonCapacity) {
            this.drinks.push(drink);
        }
    }

    removeDrink(name: string): boolean {
        const index = this.drinks.findIndex(drink => drink.name === name);

        if (index !== -1) {
            this.drinks.splice(index, 1);
            return true;
        }

        return false;
    }

    getLongest(): string {
        const longestDrink = this.drinks.reduce((prev, current) => {
            return prev.volume > current.volume ? prev : current;
        });

        return longestDrink.toString();
    }

    getCheapest(): string {
        const cheapestDrink = this.drinks.reduce((prev, current) => {
            return prev.price < current.price ? prev : current;
        });

        return cheapestDrink.toString();
    }

    buyDrink(name: string): string {
        const drink = this.drinks.find(drink => drink.name === name);
        if (drink) {
            return drink.toString()
        } else {
            return "This drink is not available.";
        }
    }

    get getCount(): number {
        return this.drinks.length;
    }

    report(): string {
        const drinks = this.drinks.map(drink => drink.toString()).join("\n");
        return `Drinks available:\n${drinks}`;
    }
}