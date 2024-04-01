"use strict";
function calculate(num1, num2, operator) {
    switch (operator) {
        case '+':
            return num1 + num2;
        case '-':
            return num1 - num2;
        case '*':
            return num1 * num2;
        case '/':
            return num1 / num2;
        case '%':
            return num1 % num2;
        case "**":
            return num1 ** num2;
    }
}
console.log(calculate(5, 6, '+')); // 11
console.log(calculate(3, 5.5, '*')); // 16.5
//# sourceMappingURL=05-mathOperations.js.map