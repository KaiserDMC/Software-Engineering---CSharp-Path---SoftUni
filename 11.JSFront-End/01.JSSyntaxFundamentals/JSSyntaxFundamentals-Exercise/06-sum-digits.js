function sumDigits(number) {
    let sum = 0;
    let numberAsString = number.toString();

    for (let i = 0; i < numberAsString.length; i++) {
        sum += Number(numberAsString[i]);
    }

    console.log(sum);
}

sumDigits(245678); // 32