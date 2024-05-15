function carWash(commands) {
    let cleanValue = 0;

    for (let i = 0; i < commands.length; i++) {
        switch (commands[i]) {
            case "soap":
                cleanValue += 10;
                break;
            case "water":
                cleanValue *= 1.2;
                break;
            case "vacuum cleaner":
                cleanValue *= 1.25;
                break;
            case "mud":
                cleanValue *= 0.9;
                break;
        }
    }
    
    console.log(`The car is ${cleanValue.toFixed(2)}% clean.`)
}

carWash(['soap', 'soap', 'vacuum cleaner', 'mud', 'soap', 'water']);
carWash(["soap", "water", "mud", "mud", "water", "mud", "vacuum cleaner"]);