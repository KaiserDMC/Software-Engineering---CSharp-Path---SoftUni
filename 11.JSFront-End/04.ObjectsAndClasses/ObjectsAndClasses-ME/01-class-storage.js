class Storage {
    constructor(capacity) {
        this.capacity = capacity;
        this.storage = [];
    }

    get totalCost() {
        let sum = 0;
        this.storage.forEach(product => sum += product.price * product.quantity);
        return sum;
    }

    addProduct(product) {
        this.storage.push(product);
        this.capacity -= product.quantity;
    }

    getProducts() {
        return this.storage.map(x => JSON.stringify(x)).join("\n");
    }
}