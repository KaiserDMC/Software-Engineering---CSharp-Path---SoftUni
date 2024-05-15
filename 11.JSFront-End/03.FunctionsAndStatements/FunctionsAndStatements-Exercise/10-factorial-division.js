function factorialDivision(numOne, numTwo) {
    const factorial = (x) => {
        if (x === 0 || x === 1) {
            return 1;
        } else {
            return x * factorial(x - 1);
        }
    };

    const division = factorial(numOne) / factorial(numTwo);

    console.log(`${division.toFixed(2)}`)
}

factorialDivision(5, 2);
factorialDivision(6, 2);