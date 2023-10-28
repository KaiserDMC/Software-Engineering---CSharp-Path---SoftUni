function solution(number1, number2) {
    let sum = 0;
    let result = '';

    for (let i = number1; i <= number2; i++) {
        sum += i;
        result += i + ' ';
    }

    console.log(result);
    console.log(`Sum: ${sum}`);
}

solution(5, 10); // 5 6 7 8 9 10