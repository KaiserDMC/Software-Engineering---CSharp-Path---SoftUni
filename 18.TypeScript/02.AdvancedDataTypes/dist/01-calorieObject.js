"use strict";
function calorieObject(arr) {
    let products = [];
    for (let i = 0; i < arr.length; i += 2) {
        products.push({ productName: arr[i], calories: Number(arr[i + 1]) });
    }
    console.log(`{ ${products.map(p => `"${p.productName}": ${p.calories}`).join(', ')} }`);
}
calorieObject(['Yoghurt', '48', 'Rise', '138', 'Apple', '52']);
calorieObject(['Potato', '93', 'Skyr', '63', 'Cucumber', '18', 'Milk', '42']);
//# sourceMappingURL=01-calorieObject.js.map