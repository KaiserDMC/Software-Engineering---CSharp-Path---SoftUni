function Fruit(name, weightInGrams, pricePerKg){
    let weightInKg = weightInGrams / 1000;
    let totalPrice = weightInKg * pricePerKg;
    
    console.log(`I need $${totalPrice.toFixed(2)} to buy ${weightInKg.toFixed(2)} kilograms ${name}.`)
}

Fruit('orange', 2500, 1.80);
Fruit('apple', 1563, 2.35);