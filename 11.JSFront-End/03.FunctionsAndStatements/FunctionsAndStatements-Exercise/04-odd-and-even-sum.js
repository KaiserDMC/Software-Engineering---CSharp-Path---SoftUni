function oddAndEvenSum(num) {
    const digits = num.toString().split("").map(Number)
    
    const sumOdd = digits.filter(n => n % 2 !== 0).reduce((acc, curr) => acc + curr, 0);
    const sumEven = digits.filter(n => n % 2 === 0).reduce((acc, curr) => acc + curr, 0);

    console.log(`Odd sum = ${sumOdd}, Even sum = ${sumEven}`);
}

oddAndEvenSum(1000435);
oddAndEvenSum(3495892137259234);