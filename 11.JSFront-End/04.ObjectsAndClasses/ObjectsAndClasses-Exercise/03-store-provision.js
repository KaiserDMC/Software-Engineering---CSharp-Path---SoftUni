function storeProvision(stockLocalStore, orderedProducts) {
    let products = {};

    for (let i = 0; i < stockLocalStore.length; i += 2) {
        products[stockLocalStore[i]] =  Number(stockLocalStore[i + 1]);
    }

    for (let i = 0; i < orderedProducts.length; i += 2) {
        if (products.hasOwnProperty(orderedProducts[i])) {
            products[orderedProducts[i]] += Number(orderedProducts[i + 1]);
        } else {
            products[orderedProducts[i]] =  Number(orderedProducts[i + 1]);
        }
    }

    for (const [key, value] of Object.entries(products)) {
        console.log(`${key} -> ${value}`);
    }
}

storeProvision(['Chips', '5', 'CocaCola', '9', 'Bananas', '14', 'Pasta', '4', 'Beer', '2'], ['Flour', '44', 'Oil', '12', 'Pasta', '7', 'Tomatoes', '70', 'Bananas', '30']);
storeProvision(['Salt', '2', 'Fanta', '4', 'Apple', '14', 'Water', '4', 'Juice', '5'], ['Sugar', '44', 'Oil', '12', 'Apple', '7', 'Tomatoes', '7', 'Bananas', '30']);