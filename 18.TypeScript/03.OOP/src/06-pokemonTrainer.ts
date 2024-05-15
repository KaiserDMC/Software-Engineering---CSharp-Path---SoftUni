class Trainer {
    name: string;
    badges: number;
    pokemons: Pokemon[];

    constructor(name: string) {
        this.name = name;
        this.badges = 0;
        this.pokemons = [];
    }
}

class Pokemon {
    name: string;
    element: string;
    health: number;

    constructor(name: string, element: string, health: number) {
        this.name = name;
        this.element = element;
        this.health = health;
    }
}

function pokemonBattle(arr: string[]): void {
    let trainers: { [name: string]: Trainer } = {};
    let trainer: Trainer | undefined;
    let pokemon: Pokemon | undefined;
    let index: number = 0;

    for (let i = 0; i < arr.length; i++) {
        if (arr[i].split(' ').length === 4) {
            let [trainerName, pokemonName, element, healthStr] = arr[i].split(' ');
            let health = Number(healthStr);

            if (!trainers[trainerName]) {
                trainer = new Trainer(trainerName);
                trainers[trainerName] = trainer;
            } else {
                trainer = trainers[trainerName];
            }
            
            pokemon = new Pokemon(pokemonName, element, health);

            trainer.pokemons.push(pokemon);
            trainers[trainerName] = trainer;
        } else if (arr[i] === "Tournament") {
            index = i + 1;
            break;
        }
    }

    for (let i = index; i < arr.length; i++) {
        if (arr[i] !== "End") {
            if (arr[i] === "Fire" || arr[i] === "Water" || arr[i] === "Electricity") {
                for (let key in trainers) {
                    let hasElement = trainers[key].pokemons.some(pokemon => pokemon.element === arr[i]);
                    if (hasElement) {
                        trainers[key].badges++;
                    } else {
                        trainers[key].pokemons.forEach(pokemon => pokemon.health -= 10);
                        trainers[key].pokemons = trainers[key].pokemons.filter(pokemon => pokemon.health > 0);
                    }
                }
            }
        }
    }

    let sortedTrainers = Object.entries(trainers).sort((a, b) => b[1].badges - a[1].badges);

    sortedTrainers.forEach(trainer => {
        console.log(`${trainer[0]} ${trainer[1].badges} ${trainer[1].pokemons.length}`);
    });
}

pokemonBattle(["Peter Charizard Fire 100", "George Squirtle Water 38", "Peter Pikachu Electricity 10", "Tournament", "Fire", "Electricity", "End"]);
pokemonBattle(["Sam Blastoise Water 18", "Narry Pikachu Electricity 22", "John Kadabra Psychic 90", "Tournament", "Fire", "Electricity", "Fire", "End"]);