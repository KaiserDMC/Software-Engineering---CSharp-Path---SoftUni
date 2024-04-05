"use strict";
function townPopulation(arr) {
    let towns = [];
    for (let i = 0; i < arr.length; i++) {
        let [name, population] = arr[i].split(' <-> ');
        let town = {
            name: name,
            population: Number(population)
        };
        if (towns.some(t => t.name === name)) {
            let index = towns.findIndex(t => t.name === name);
            towns[index].population += town.population;
        }
        else {
            towns.push(town);
        }
    }
    towns.forEach(t => console.log(`${t.name} : ${t.population}`));
}
townPopulation(['Sofia <-> 1200000', 'Montana <-> 20000', 'New York <-> 10000000', 'Washington <-> 2345000', 'Las Vegas <-> 1000000']);
townPopulation(['Istanbul <-> 100000', 'Honk Kong <-> 2100004', 'Jerusalem <-> 2352344', 'Mexico City <-> 23401925', 'Istanbul <-> 1000']);
//# sourceMappingURL=05-townPopulation.js.map