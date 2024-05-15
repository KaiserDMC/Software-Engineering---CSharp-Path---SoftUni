function numberModification(number) {
    const digits = number.toString().split("").map(Number);

    let averageValueDigits = digits.reduce((acc, curr) => acc + curr, 0) / (digits.length);

    while (averageValueDigits <= 5) {
        digits.push(9);
        averageValueDigits = digits.reduce((acc, curr) => acc + curr, 0) / (digits.length);
    }

    console.log(Number(digits.join("")));
}

numberModification(101);
numberModification(5835);