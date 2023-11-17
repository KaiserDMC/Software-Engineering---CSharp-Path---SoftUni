function armies(inputArr) {
    let armyCompositions = {};

    for (const inputArrElement of inputArr) {
        if (inputArrElement.includes(" arrives")) {
            let leaderName = inputArrElement.split(" ").slice(0, inputArrElement.split(" ").length - 1).join(" ");
            
            armyCompositions[leaderName] = {
                armies: [],
                totalArmyCount: 0
            };
        } else if (inputArrElement.includes(" defeated")) {
            let leaderName = inputArrElement.split(" ").slice(0, inputArrElement.split(" ").length - 1).join(" ");

            if (armyCompositions.hasOwnProperty(leaderName)) {
                armyCompositions[leaderName].defeated = true;
            }
        } else if (inputArrElement.includes(": ")) {
            let leaderName = inputArrElement.split(": ")[0];
            let [armyName, armyCount] = inputArrElement.split(": ")[1].split(", ");

            if (armyCompositions.hasOwnProperty(leaderName)) {
                let army = {
                    armyName,
                    armyCount: parseInt(armyCount)
                };

                armyCompositions[leaderName].armies.push(army);
                armyCompositions[leaderName].totalArmyCount += parseInt(armyCount);
            }
        } else if (inputArrElement.includes(" + ")) {
            let [armyName, armyCount] = inputArrElement.split(" + ");
            
            for (const leaderName of Object.keys(armyCompositions)) {
                let foundArmy = armyCompositions[leaderName].armies.find(a => a.armyName === armyName);
               
                if (foundArmy) {
                    foundArmy.armyCount += parseInt(armyCount);
                    armyCompositions[leaderName].totalArmyCount += parseInt(armyCount);
                    break;
                }
            }
        }
    }

    let sortedLeaderEntries = Object.entries(armyCompositions)
        .filter(([_, info]) => !info.defeated)
        .sort((a, b) => b[1].totalArmyCount - a[1].totalArmyCount);

    for (const [leaderName, leaderInfo] of sortedLeaderEntries) {
        let armiesOutputString = "";
        let sortedArmies = leaderInfo.armies.sort((a, b) => b.armyCount - a.armyCount);
       
        for (const army of sortedArmies) {
            armiesOutputString += `\n>>> ${army.armyName} - ${army.armyCount}`;
        }
        
        console.log(`${leaderName}: ${leaderInfo.totalArmyCount}` + armiesOutputString);
    }
}

armies(['Rick Burr arrives', 'Fergus: Wexamp, 30245', 'Rick Burr: Juard, 50000', 'Findlay arrives', 'Findlay: Britox, 34540', 'Wexamp + 6000', 'Juard + 1350', 'Britox + 4500', 'Porter arrives', 'Porter: Legion, 55000', 'Legion + 302', 'Rick Burr defeated', 'Porter: Retix, 3205']);
armies(['Rick Burr arrives', 'Findlay arrives', 'Rick Burr: Juard, 1500', 'Wexamp arrives', 'Findlay: Wexamp, 34540', 'Wexamp + 340', 'Wexamp: Britox, 1155', 'Wexamp: Juard, 43423']);