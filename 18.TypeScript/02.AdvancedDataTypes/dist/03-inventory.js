"use strict";
function inventory(arr) {
    let heroes = [];
    arr.forEach(hero => {
        let [name, level, items] = hero.split(' / ');
        heroes.push({ name, level: Number(level), items: items ? items.split(', ') : null });
    });
    heroes.sort((a, b) => a.level - b.level);
    heroes.forEach(hero => {
        console.log(`Hero: ${hero.name}`);
        console.log(`level => ${hero.level}`);
        if (hero.items) {
            console.log(`items => ${hero.items.join(', ')}`);
        }
    });
}
inventory(['Isacc / 25 / Apple, GravityGun', 'Derek / 12 / BarrelVest, DestructionSword', 'Hes / 1 / Desolator, Sentinel, Antara']);
inventory(['Batman / 2 / Banana, Gun', 'Superman / 18 / Sword', 'Poppy / 28 / Sentinel, Antara']);
//# sourceMappingURL=03-inventory.js.map