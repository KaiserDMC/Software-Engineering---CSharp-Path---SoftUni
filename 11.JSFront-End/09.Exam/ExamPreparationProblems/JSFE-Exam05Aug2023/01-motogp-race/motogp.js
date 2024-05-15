function solve(inputArray) {
    let numberOfRacers = Number(inputArray.shift());
    let racers = {};

    for (let i = 0; i < numberOfRacers; i++) {
        let [name, fuel, position] = inputArray.shift().split('|');
        fuel = Number(fuel);

        if (fuel > 100) {
            fuel = 100;
        }

        position = Number(position);

        racers[name] = {fuel, position};
    }

    while (inputArray.length > 0) {
        let command = inputArray.shift();
        let commandArray = command.split(' - ');

        if (commandArray[0] === 'Finish') {
            break;
        }

        switch (commandArray[0]) {
            case "StopForFuel":
                stopForFuel(commandArray[1], commandArray[2], commandArray[3]);
                break;
            case "Overtaking":
                overtake(commandArray[1], commandArray[2]);
                break;
            case "EngineFail":
                engineFail(commandArray[1], commandArray[2]);
                break;
        }
    }

    for (const racer of Object.entries(racers)) {
        console.log(`${racer[0]}`);
        console.log(`  Final position: ${racer[1].position}`);
    }

    function stopForFuel(riderName, minimumFuel, newPosition) {
        minimumFuel = Number(minimumFuel);
        newPosition = Number(newPosition);

        if (racers[riderName].fuel < minimumFuel) {
            racers[riderName].position = newPosition;
            console.log(`${riderName} stopped to refuel but lost his position, now he is ${newPosition}.`);
        } else {
            console.log(`${riderName} does not need to stop for fuel!`);
        }
    }

    function overtake(riderOne, riderTwo) {
        if (racers[riderOne].position < racers[riderTwo].position) {
            let tempPosition = racers[riderOne].position;
            racers[riderOne].position = racers[riderTwo].position;
            racers[riderTwo].position = tempPosition;

            console.log(`${riderOne} overtook ${riderTwo}!`);
        }
    }

    function engineFail(riderName, lapsLeft) {
        lapsLeft = Number(lapsLeft);
        delete racers[riderName];
        console.log(`${riderName} is out of the race because of a technical issue, ${lapsLeft} laps before the finish.`);
    }
}


solve(["3", "Valentino Rossi|100|1", "Marc Marquez|90|2", "Jorge Lorenzo|80|3",
    "StopForFuel - Valentino Rossi - 50 - 1",
    "Overtaking - Marc Marquez - Jorge Lorenzo",
    "EngineFail - Marc Marquez - 10",
    "Finish"])
solve(["4", "Valentino Rossi|100|1", "Marc Marquez|90|3", "Jorge Lorenzo|80|4", "Johann Zarco|80|2",
    "StopForFuel - Johann Zarco - 90 - 5",
    "Overtaking - Marc Marquez - Jorge Lorenzo",
    "EngineFail - Marc Marquez - 10",
    "Finish"])
