"use strict";
class City {
    name;
    population;
    treasury;
    taxRate;
    constructor(name, population, treasury) {
        this.name = name;
        this.population = population;
        this.treasury = treasury;
        this.taxRate = 10;
    }
    collectTaxes() {
        this.treasury += Math.floor(this.population * this.taxRate);
    }
    applyGrowth(percentage) {
        this.population += Math.floor(this.population * (percentage / 100));
    }
    applyRecession(percentage) {
        this.treasury -= Math.floor(this.treasury * (percentage / 100));
    }
}
function cityTaxes(cityName, population, treasury) {
    const city = new City(cityName, population, treasury);
    city.collectTaxes = City.prototype.collectTaxes;
    city.applyGrowth = City.prototype.applyGrowth;
    city.applyRecession = City.prototype.applyRecession;
    return city;
}
// Input 1
const city = cityTaxes('Tortuga', 7000, 15000);
console.log(city);
// Input 2
const city1 = cityTaxes('Tortuga', 7000, 15000);
city1.collectTaxes();
console.log(city1.treasury);
city1.applyGrowth(5);
console.log(city1.population);
//# sourceMappingURL=main.js.map