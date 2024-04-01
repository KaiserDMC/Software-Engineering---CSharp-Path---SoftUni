function calculate(num1: number, num2: number, operator: string) {
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