function GladiatorExpenses(lostFights, helmetPrice, swordPrice, shieldPrice, armorPrice) {
    let expenses = 0;
    let shieldBrakes = 0;

    for (let i = 1; i <= lostFights; i++) {
        if (i % 2 === 0) {
            expenses += helmetPrice;
        }
        
        if (i % 3 === 0) {
            expenses += swordPrice;
        }
        
        if (i % 6 === 0) {
            expenses += shieldPrice;
            shieldBrakes++;
        }
        
        if (shieldBrakes === 2) {
            expenses += armorPrice;
            shieldBrakes = 0;
        }
    }
    
    console.log(`Gladiator expenses: ${expenses.toFixed(2)} aureus`);
}

GladiatorExpenses(7, 2, 3, 4, 5); // 16.00 aureus
GladiatorExpenses(23, 12.50, 21.50, 40, 200); // 608.00 aureus