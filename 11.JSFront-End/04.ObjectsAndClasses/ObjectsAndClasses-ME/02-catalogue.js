function catalogue(inputArr) {
    let products = {};

    for (const inputArrElement of inputArr) {
        let [product, price] = inputArrElement.split(" : ");
        const startLetter = product[0];
        if (!products.hasOwnProperty(product[0])) {
            products[startLetter] = {};
        }
        products[startLetter][product] = price;
    }

    for (const [startLetter, product] of Object.entries(products).sort()) {
        console.log(startLetter);

        let sortedProducts = Object.entries(product).sort((a, b) => a[0].localeCompare(b[0]));

        for (const [name, price] of sortedProducts) {
            console.log(`  ${name}: ${price}`);
        }
    }
}

catalogue(['Appricot : 20.4', 'Fridge : 1500', 'TV : 1499', 'Deodorant : 10', 'Boiler : 300', 'Apple : 1.25', 'Anti-Bug Spray : 15', 'T-Shirt : 10']);
catalogue(['Omlet : 5.4', 'Shirt : 15', 'Cake : 59']);