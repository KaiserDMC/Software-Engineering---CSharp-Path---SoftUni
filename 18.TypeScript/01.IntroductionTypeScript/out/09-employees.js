"use strict";
class employee {
    name;
    personalId;
    constructor(name) {
        this.name = name;
        this.personalId = name.length;
    }
    print() {
        console.log(`Name: ${this.name} -- Personal Number: ${this.personalId}`);
    }
}
function solveEmployees(input) {
    let employees = [];
    for (let i = 0; i < input.length; i++) {
        employees.push(new employee(input[i]));
    }
    employees.forEach(e => e.print());
}
solveEmployees(['Silas Butler', 'Adnaan Buckley', 'Juan Peterson', 'Brendan Villarreal']);
// Should return:
// Name: Silas Butler -- Personal Number: 12
// Name: Adnaan Buckley -- Personal Number: 14
// Name: Juan Peterson -- Personal Number: 13
// Name: Brendan Villarreal -- Personal Number: 18
solveEmployees(['Samuel Jackson', 'Will Smith', 'Bruce Willis', 'Tom Holland']);
// Should return:
// Name: Samuel Jackson -- Personal Number: 14
// Name: Will Smith -- Personal Number: 10
// Name: Bruce Willis -- Personal Number: 12
// Name: Tom Holland -- Personal Number: 11
//# sourceMappingURL=09-employees.js.map