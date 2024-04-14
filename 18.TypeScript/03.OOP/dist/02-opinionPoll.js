"use strict";
class Person {
    name;
    age;
    constructor(name, age) {
        this.name = name;
        this.age = age;
    }
    printInfo() {
        console.log(`${this.name} is ${this.age} years old.`);
    }
}
function solvePerson(input) {
    let [name, ageStr] = input.split(' ');
    let age = Number(ageStr);
    let person = new Person(name, age);
    person.printInfo();
}
solvePerson("Peter 12");
solvePerson("Sofia 33");
//# sourceMappingURL=02-opinionPoll.js.map