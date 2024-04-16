class Box<T> {
    value: T;

    constructor(value: T) {
        this.value = value;
    }

    toString() {
        return `${this.value} is of type ${typeof this.value}.`;
    }
}

let box1 = new Box(['test']);
let box2 = new Box(20);
let box3 = new Box('Hello');

console.log(box1.toString());
console.log(box2.toString());
console.log(box3.toString());
