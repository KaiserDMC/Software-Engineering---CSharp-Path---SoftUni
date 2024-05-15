class Person {
    name: string;
    age: number;

    constructor(name: string, age: number) {
        this.name = name;
        this.age = age;
    }

    public printInfo() {
        console.log(`${this.name} is ${this.age} years old.`);
    }
}

function solvePerson(input: string): void {
    let [name, ageStr] = input.split(' ');
    let age = Number(ageStr);

    let person = new Person(name, age);
    person.printInfo();
}

solvePerson("Peter 12");
solvePerson("Sofia 33");