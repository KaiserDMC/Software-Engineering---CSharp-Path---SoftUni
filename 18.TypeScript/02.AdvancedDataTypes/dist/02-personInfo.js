"use strict";
function personInfo(firstN, lastN, age) {
    return {
        firstName: firstN,
        lastName: lastN,
        age: Number(age)
    };
}
personInfo("Peter", "Pan", "20"); // { firstName: 'Peter', lastName: 'Pan', age: 20 }
personInfo("George", "Smith", "18"); // { firstName: 'George', lastName: 'Smith', age: 18 }
console.log(personInfo("Peter", "Pan", "20")); // { firstName: 'Peter', lastName: 'Pan', age: 20 }
//# sourceMappingURL=02-personInfo.js.map