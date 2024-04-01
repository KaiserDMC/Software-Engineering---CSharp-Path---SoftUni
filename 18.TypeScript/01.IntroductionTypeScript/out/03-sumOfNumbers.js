"use strict";
function sumOfNumbers(nStr, mStr) {
    const n = parseInt(nStr);
    const m = parseInt(mStr);
    let sum = 0;
    const min = Math.min(n, m);
    const max = Math.max(n, m);
    for (let i = min; i <= max; i++) {
        sum += i;
    }
    console.log(sum);
}
sumOfNumbers("1", "5"); // 15
sumOfNumbers("-8", "20"); // 174
//# sourceMappingURL=03-sumOfNumbers.js.map