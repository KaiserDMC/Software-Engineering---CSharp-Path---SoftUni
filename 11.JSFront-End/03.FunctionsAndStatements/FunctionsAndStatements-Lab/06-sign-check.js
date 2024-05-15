function signCheck(numOne, numTwo, numThree) {
    const signs = [Math.sign(numOne), Math.sign(numTwo), Math.sign(numThree)];

    const countNegatives = signs.filter(sign => sign === -1).length;

    if (countNegatives % 2 === 0) {
        console.log("Positive");
    } else {
        console.log("Negative");
    }
}

signCheck(5, 12, -15);
signCheck(-6, -12, 14);
signCheck(-1, -2, -3);
signCheck(-5, 1, 1);