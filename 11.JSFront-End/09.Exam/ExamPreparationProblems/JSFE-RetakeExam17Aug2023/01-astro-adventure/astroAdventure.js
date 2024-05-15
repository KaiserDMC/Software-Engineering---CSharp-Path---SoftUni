function astroAdventure(inputArray) {
    const n = Number(inputArray.shift());
    const astronauts = {};

    for (let i = 0; i < n; i++) {
        let [name, oxygen, energy] = inputArray.shift().split(' ');
        oxygen = Number(oxygen);
        energy = Number(energy);

        if (oxygen > 100) {
            oxygen = 100;
        } else if (oxygen < 0) {
            oxygen = 0;
        }

        if (energy < 0) {
            energy = 0;
        } else if (energy > 200) {
            energy = 200;
        }

        astronauts[name] = {oxygen, energy};
    }

    while (true) {
        let command = inputArray.shift();

        if (command === 'End') {
            break;
        }

        let [action, name, value] = command.split(' - ');

        switch (action) {
            case "Explore":
                if (Number(value) > astronauts[name].energy) {
                    console.log(`${name} does not have enough energy to explore!`);
                } else {
                    astronauts[name].energy -= Number(value);
                    console.log(`${name} has successfully explored a new area and now has ${astronauts[name].energy} energy!`);
                }
                break;
            case "Refuel":
                if (Number(value) + astronauts[name].energy > 200) {
                    console.log(`${name} refueled their energy by ${200 - astronauts[name].energy}!`);
                    astronauts[name].energy = 200;
                } else {
                    astronauts[name].energy += Number(value);
                    console.log(`${name} refueled their energy by ${value}!`);
                }
                break;
            case "Breathe":
                if (Number(value) + astronauts[name].oxygen > 100) {
                    console.log(`${name} took a breath and recovered ${100 - astronauts[name].oxygen} oxygen!`);
                    astronauts[name].oxygen = 100;
                } else {
                    astronauts[name].oxygen += Number(value);
                    console.log(`${name} took a breath and recovered ${value} oxygen!`);
                }
                break;
        }
    }

    for (const [key, value] of Object.entries(astronauts)) {
        console.log(`Astronaut: ${key}, Oxygen: ${value.oxygen}, Energy: ${value.energy}`);
    }
}

astroAdventure(['3', 'John 50 120', 'Kate 80 180', 'Rob 70 150', 'Explore - John - 50', 'Refuel - Kate - 30', 'Breathe - Rob - 20', 'End']);
astroAdventure(['4', 'Alice 60 100', 'Bob 40 80', 'Charlie 70 150', 'Dave 80 180', 'Explore - Bob - 60', 'Refuel - Alice - 30', 'Breathe - Charlie - 50', 'Refuel - Dave - 40', 'Explore - Bob - 40', 'Breathe - Charlie - 30', 'Explore - Alice - 40', 'End']);