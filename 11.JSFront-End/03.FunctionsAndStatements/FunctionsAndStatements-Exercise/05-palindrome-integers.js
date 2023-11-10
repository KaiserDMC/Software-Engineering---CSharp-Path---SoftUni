function palindromeIntegers(integers) {
    for (const integer of integers) {
        let reverseInt = integer.toString().split("");

        const areSame = integer.toString() === reverseInt.reverse().join("");
        console.log(areSame);
    }
}

palindromeIntegers([123, 323, 421, 121]);
palindromeIntegers([32, 2, 232, 1010]);