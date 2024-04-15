"use strict";
class Animal {
    eat() {
        console.log("eating...");
    }
}
class Dog extends Animal {
    bark() {
        console.log("barking...");
    }
}
class Cat extends Animal {
    meow() {
        console.log("meowing...");
    }
}
function test() {
    const animal = new Animal();
    console.log("Animal -> ");
    animal.eat();
    const dog = new Dog();
    console.log("Dog -> ");
    dog.eat();
    dog.bark();
    const cat = new Cat();
    console.log("Cat -> ");
    cat.eat();
    cat.meow();
}
test();
//# sourceMappingURL=04-hierarchicalInheritance.js.map