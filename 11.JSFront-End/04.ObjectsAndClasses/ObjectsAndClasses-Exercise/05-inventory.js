function heroInventory(inputArr) {
    let heroes = [];

    for (const element of inputArr) {
        let [heroName, heroLevel, items] = element.split(" / ");

        let hero = {
            heroName,
            heroLevel: parseInt(heroLevel),
            items
        }

        heroes.push(hero);
    }

    let sortedHeroes = heroes.sort((a, b) => a.heroLevel - b.heroLevel);

    for (const hero of sortedHeroes) {
        console.log(`Hero: ${hero.heroName}\nlevel => ${hero.heroLevel}\nitems => ${hero.items}`);
    }
}

heroInventory(['Isacc / 25 / Apple, GravityGun', 'Derek / 12 / BarrelVest, DestructionSword', 'Hes / 1 / Desolator, Sentinel, Antara']);
heroInventory(['Batman / 2 / Banana, Gun', 'Superman / 18 / Sword', 'Poppy / 28 / Sentinel, Antara']);