function mathOperations(number1, number2, operator) {
    switch (operator) {
        case '+':
            console.log(number1 + number2);
            break;
        case '-':
            console.log(number1 - number2);
            break;
        case '*':
            console.log(number1 * number2);
            break;
        case '/':
            console.log(number1 / number2);
            break;
        case '%':
            console.log(number1 % number2);
            break;
        case '**':
            console.log(number1 ** number2);
            break;
    }
}

mathOperations(5, 6, '+');