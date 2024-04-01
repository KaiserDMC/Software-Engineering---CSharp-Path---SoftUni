"use strict";
function aggregate(arr) {
    let sum = 0;
    let inverseSum = 0;
    let concat = '';
    for (let i = 0; i < arr.length; i++) {
        sum += Number(arr[i]);
        inverseSum += 1 / Number(arr[i]);
        concat += arr[i];
    }
    console.log(sum);
    console.log(inverseSum);
    console.log(concat);
}
aggregate(['1', '2', '3']); // 6 1.8333333333333333 123
aggregate(['2', '4', '8', '16']); // 30 0.9375 24816
//# sourceMappingURL=10-aggregateElements.js.map