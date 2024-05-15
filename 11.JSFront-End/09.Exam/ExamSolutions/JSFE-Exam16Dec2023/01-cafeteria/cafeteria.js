function solve(inputArray) {
    const numberOfEmployees = Number(inputArray.shift());
    const baristas = {};

    for (let i = 0; i < numberOfEmployees; i++) {
        const [name, shift, drinks] = inputArray.shift().split(' ');

        if (shift === 'day' || shift === 'night') {
            baristas[name] = {shift, drinks: drinks.split(',')};
        }
    }

    while (inputArray.length > 0) {
        let [command, baristaName, shift, coffeeType] = inputArray.shift().split(' / ');

        if (command === 'Closed') {
            break;
        }
        
        switch (command) {
            case "Prepare":
                if (baristas[baristaName].shift === shift) {
                    if (baristas[baristaName].drinks.includes(coffeeType)) {
                        console.log(`${baristaName} has prepared a ${coffeeType} for you!`);
                    } else {
                        console.log(`${baristaName} is not available to prepare a ${coffeeType}.`);
                    }
                } else {
                    console.log(`${baristaName} is not available to prepare a ${coffeeType}.`);
                }
                break;
            case "Change Shift":
                if (baristas[baristaName]) {
                    const newShift = shift;
                    if (newShift === 'day' || newShift === 'night') {
                        console.log(`${baristaName} has updated his shift to: ${newShift}`);
                        baristas[baristaName].shift = newShift;
                    }
                }
                break;
            case "Learn":
                coffeeType = shift;
                if (baristas[baristaName].drinks.includes(coffeeType)) {
                    console.log(`${baristaName} knows how to make ${coffeeType}.`);
                } else {
                    baristas[baristaName].drinks.push(coffeeType);
                    console.log(`${baristaName} has learned a new coffee type: ${coffeeType}.`);
                }
                break;
        }
    }

    for (const [name, props] of Object.entries(baristas)) {
        console.log(`Barista: ${name}, Shift: ${props.shift}, Drinks: ${props.drinks.join(', ')}`);
    }
}

solve(['3', 'Alice day Espresso,Cappuccino', 'Bob night Latte,Mocha', 'Carol day Americano,Mocha',
    'Prepare / Alice / day / Espresso',
    'Change Shift / Bob / night',
    'Learn / Carol / Latte',
    'Learn / Bob / Latte',
    'Prepare / Bob / night / Latte',
    'Closed']);
solve(['4', 'Alice day Espresso,Cappuccino', 'Bob night Latte,Mocha', 'Carol day Americano,Mocha', 'David night Espresso',
    'Prepare / Alice / day / Espresso',
    'Change Shift / Bob / day',
    'Learn / Carol / Latte',
    'Prepare / Bob / night / Latte',
    'Learn / David / Cappuccino',
    'Prepare / Carol / day / Cappuccino',
    'Change Shift / Alice / night',
    'Learn / Bob / Mocha',
    'Prepare / David / night / Espresso',
    'Closed']);