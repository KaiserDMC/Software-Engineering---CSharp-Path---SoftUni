interface City {
    name: string;
    population: number;
    treasury: number;
    taxRate: number;
    collectTaxes: () => void;
    applyGrowth: (percentage: number) => void;
    applyRecession: (percentage: number) => void;
}

function cityTaxes(cityName: string, population: number, treasury: number): City {
    const taxRate = 10;

    const city: City = {
        name: cityName,
        population: population,
        treasury: treasury,
        taxRate: taxRate,
        collectTaxes: function () {
            this.treasury += Math.floor(this.population * this.taxRate);
        },
        applyGrowth: function (percentage: number) {
            this.population += Math.floor(this.population * (percentage / 100));
        },
        applyRecession: function (percentage: number) {
            this.treasury -= Math.floor(this.treasury * (percentage / 100));
        }
    };

    return city;
}

// Input 1
const city2 = cityTaxes('Tortuga', 7000, 15000);
console.log(city2);

// Input 2
const city3 = cityTaxes('Tortuga', 7000, 15000);
city3.collectTaxes();
console.log(city3.treasury);
city3.applyGrowth(5);
console.log(city3.population);
