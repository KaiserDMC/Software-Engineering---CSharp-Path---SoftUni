function reverseArrayOfNumbers(count, elements){
    const copiedArray = elements.slice(0, count);
    
    console.log(copiedArray.reverse().join(" "))
}

reverseArrayOfNumbers(3, [10, 20, 30, 40, 50]);
reverseArrayOfNumbers(4, [-1, 20, 99, 5]);
reverseArrayOfNumbers(2, [66, 43, 75, 89, 47]);