function calculator(number1, operator, number2) {
    let result = 0;

    switch (operator) {
        case '+':
            result = number1 + number2;
            break;
        case '-':
            result = number1 - number2;
            break;
        case '*':
            result = number1 * number2;
            break;
        case '/':
            result = number1 / number2;
            break;
    }

    console.log(result.toFixed(2));
}

calculator(5, '+', 10); // 15
calculator(25.5, '-', 3); // 22.5