"use strict";
class Employee {
    name;
    salary;
    position;
    department;
    email;
    age;
    constructor(name, salary, position, department, email, age) {
        this.name = name;
        this.salary = salary;
        this.position = position;
        this.department = department;
        this.email = email;
        this.age = age;
    }
    printInfo() {
        console.log(`${this.name} ${this.salary.toFixed(2)} ${this.email ? this.email : "n/a"} ${this.age ? this.age : -1}`);
    }
}
class Department {
    name;
    employees;
    constructor(name, employees = []) {
        this.name = name;
        this.employees = employees;
        this.name = name;
        this.employees = employees;
    }
    addEmployee(employee) {
        if (employee) {
            this.employees.push(employee);
        }
    }
    averageSalary() {
        return this.employees.reduce((acc, curr) => acc + curr.salary, 0) / this.employees.length;
    }
    printEmployees() {
        this.employees.sort((a, b) => b.salary - a.salary).forEach(employee => employee.printInfo());
    }
}
function solveEmployee(employeeCount, input) {
    let departments = {};
    let employee;
    let dep = '';
    for (let i = 0; i < employeeCount; i++) {
        if (input[i].split(' ').length === 4) {
            let [name, salaryStr, position, department] = input[i].split(' ');
            let salary = Number(salaryStr);
            dep = department;
            employee = new Employee(name, salary, position, department);
        }
        else if (input[i].split(' ').length === 6) {
            let [name, salaryStr, position, department, email, ageStr] = input[i].split(' ');
            let salary = Number(salaryStr);
            let age = Number(ageStr);
            dep = department;
            employee = new Employee(name, salary, position, department, email, age);
        }
        else if (input[i].split(' ').length === 5) {
            if (input[i].includes('@')) {
                let [name, salaryStr, position, department, email] = input[i].split(' ');
                let salary = Number(salaryStr);
                dep = department;
                employee = new Employee(name, salary, position, department, email);
            }
            else {
                let [name, salaryStr, position, department, ageStr] = input[i].split(' ');
                let salary = Number(salaryStr);
                let age = Number(ageStr);
                dep = department;
                employee = new Employee(name, salary, position, department, undefined, age);
            }
        }
        if (!departments[dep]) {
            departments[dep] = new Department(dep);
        }
        departments[dep].addEmployee(employee);
    }
    let departmentWithHighestAverage;
    let highestAverageSalary = 0;
    for (const departmentName in departments) {
        const department = departments[departmentName];
        const averageSalary = department.averageSalary();
        if (averageSalary > highestAverageSalary) {
            highestAverageSalary = averageSalary;
            departmentWithHighestAverage = department;
        }
    }
    if (departmentWithHighestAverage) {
        console.log(`Highest Average Salary: ${departmentWithHighestAverage.name}`);
        departmentWithHighestAverage.printEmployees();
    }
    else {
        console.log("No employees found.");
    }
}
solveEmployee(4, ["Peter 120.00 Dev Development peter@abv.bg 28", "Tina 333.33 Manager Marketing 33", "Sam 840.20 ProjectLeader Development sam@sam.com", "George 0.20 Freeloader Nowhere 18"]);
solveEmployee(6, ["Silver 496.37 Temp Coding silver@yahoo.com", "Sam 610.13 Manager Sales", "John 609.99 Manager Sales john@abv.bg 44", "Venci 0.02 Director BeerDrinking beer@beer.br 23", "Andre 700.00 Director Coding", "Popeye 13.3333 Sailor SpinachGroup popeye@pop.ey"]);
//# sourceMappingURL=05-companyRoster.js.map