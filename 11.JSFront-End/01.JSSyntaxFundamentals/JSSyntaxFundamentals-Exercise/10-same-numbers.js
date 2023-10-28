function SameNumbers(number) {
    let numberAsString = number.toString();
    let sum = 0;
    let isSame = true;

    for (let i = 0; i < numberAsString.length; i++) {
        let currentDigit = numberAsString[i];
        sum += Number(currentDigit);

        let nextDigit = numberAsString[i + 1];
        
        if (currentDigit !== nextDigit && nextDigit !== undefined) {
            isSame = false;
        }
    }
    
    console.log(isSame);
    console.log(sum);
}

SameNumbers(2222222); // true, 14