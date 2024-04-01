"use strict";
function evenElements(arr) {
    let evenArr = [];
    for (let i = 0; i < arr.length; i++) {
        if (i % 2 === 0) {
            evenArr.push(arr[i]);
        }
    }
    console.log(evenArr.join(' '));
}
evenElements(['20', '30', '40', '50', '60']); // ['20', '40', '60']
evenElements(['5', '10']); // ['5']
//# sourceMappingURL=06-evenPositionElement.js.map