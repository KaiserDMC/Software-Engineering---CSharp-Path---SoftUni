function catCreator(inputArr) {
    class Cat {
        constructor(name, age) {
            this.name = name;
            this.age = age;
        }

        meow() {
            console.log(`${this.name}, age ${this.age} says Meow`);
        }
    }

    for (const inputArrElement of inputArr) {
        let [catName, catAge] = inputArrElement.split(" ");

        const cat = new Cat(catName, catAge);
        cat.meow();
    }
}

catCreator(['Mellow 2', 'Tom 5']);
catCreator(['Candy 1', 'Poppy 3', 'Nyx 2']);