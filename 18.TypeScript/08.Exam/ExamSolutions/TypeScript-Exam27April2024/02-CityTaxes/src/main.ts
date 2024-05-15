class City {
    private name: string;
    public population: number;
    public treasury: number;
    private taxRate: number;

    constructor(name: string, population: number, treasury: number) {
        this.name = name;
        this.population = population;
        this.treasury = treasury;
        this.taxRate = 10;
    }

    collectTaxes(): void {
        this.treasury += Math.floor(this.population * this.taxRate);
    }

    applyGrowth(percentage: number): void {
        this.population += Math.floor(this.population * (percentage / 100));
    }

    applyRecession(percentage: number): void {
        this.treasury -= Math.floor(this.treasury * (percentage / 100));
    }
}

function cityTaxes(cityName: string, population: number, treasury: number): City {
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
