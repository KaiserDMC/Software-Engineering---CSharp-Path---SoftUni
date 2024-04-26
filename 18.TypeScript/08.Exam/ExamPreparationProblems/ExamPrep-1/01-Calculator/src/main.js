"use strict";
function calculator(a, op, b) {
    const mapOfOperations = {
        '+': (a + b).toFixed(2),
        '-': (a - b).toFixed(2),
        '*': (a * b).toFixed(2),
        '/': (a / b).toFixed(2)
    };
    if (mapOfOperations[op] === undefined) {
        throw new Error('Invalid operation');
    }
    console.log(mapOfOperations[op]);
}
calculator(5, '+', 10); // 15.00
calculator(25.5, '-', 3); // 22.50
calculator(9, '*', 2); // 4.50
calculator(7, '/', 5); // 35.00
//# sourceMappingURL=main.js.map