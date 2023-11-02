function ReverseArrayOfNumbers(count, elements){
    const copiedArray = elements.slice(0, count);
    
    console.log(copiedArray.reverse().join(" "))
}

ReverseArrayOfNumbers(3, [10, 20, 30, 40, 50]);
ReverseArrayOfNumbers(4, [-1, 20, 99, 5]);
ReverseArrayOfNumbers(2, [66, 43, 75, 89, 47]);
