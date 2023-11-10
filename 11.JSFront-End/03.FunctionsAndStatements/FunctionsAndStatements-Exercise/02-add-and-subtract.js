function addAndSubtract(numOne, numTwo, numThree) {
    let sum = () => numOne + numTwo;
    let subtract = () => sum() - numThree;
    
    console.log(subtract());
}

addAndSubtract(23, 6, 10);
addAndSubtract(1, 17, 30);
addAndSubtract(42, 58, 100);