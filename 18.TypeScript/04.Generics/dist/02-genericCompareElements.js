"use strict";
class CompareElements {
    value;
    counter = 0;
    constructor(value) {
        this.value = value;
    }
    compare(comparator) {
        this.value.forEach((element) => {
            if (element === comparator) {
                this.counter++;
            }
        });
        return this.counter;
    }
}
let c = new CompareElements(['a', 'b', 'ab', 'abc', 'cba', 'b']);
console.log(c.compare('b'));
let d = new CompareElements([1, 2, 3, 4, 5, 1, 1]);
console.log(d.compare(1));
//# sourceMappingURL=02-genericCompareElements.js.map