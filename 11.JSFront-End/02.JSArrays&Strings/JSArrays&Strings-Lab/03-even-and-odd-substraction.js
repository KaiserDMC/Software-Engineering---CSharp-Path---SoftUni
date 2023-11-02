function Subtraction(elements) {
    const arrayEven = elements.filter(elements => elements % 2 === 0);
    const arrayOdd = elements.filter(elements => elements % 2 !== 0);

    let sumEven = arrayEven.reduce((acc, curr) => acc + curr, 0);
    let sumOdd = arrayOdd.reduce((acc, curr) => acc + curr, 0);

    console.log(sumEven - sumOdd);
}

Subtraction([1, 2, 3, 4, 5, 6]);
Subtraction([3, 5, 7, 9]);
Subtraction([2, 4, 6, 8, 10]);
