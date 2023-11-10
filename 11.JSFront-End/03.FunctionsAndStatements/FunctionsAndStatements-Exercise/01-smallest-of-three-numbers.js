function smallestOfThreeNumbers(numOne, numTwo, numThree) {
    const numArray = [Number(numOne), Number(numTwo), Number(numThree)];

    console.log(Math.min(numArray[0], numArray[1], numArray[2]));
}

smallestOfThreeNumbers(2, 5, 3);
smallestOfThreeNumbers(600, 342, 123);
smallestOfThreeNumbers(25, 21, 4);
smallestOfThreeNumbers(2, 2, 2);