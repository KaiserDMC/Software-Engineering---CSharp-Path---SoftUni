type CityProduct = {
    town: string;
    product: string;
    price: number;
}

function lowestPricesInCities(arr: string[]): void {
    let products: CityProduct[] = [];

    for (let i = 0; i < arr.length; i++) {
        let [town, product, price] = arr[i].split(' | ');
        const convertedPrice = Number(price);

        let currentProduct = products.find(p => p.product === product);

        if (currentProduct) {
            if (currentProduct.price > convertedPrice) {
                currentProduct.price = convertedPrice;
                currentProduct.town = town;
            }
        } else {
            products.push({town, product, price: convertedPrice});
        }
    }

    products.forEach(p => {
        console.log(`${p.product} -> ${p.price} (${p.town})`);
    });
}

lowestPricesInCities(['Sample Town | Sample Product | 1000', 'Sample Town | Orange | 2', 'Sample Town | Peach | 1', 'Sofia | Orange | 3', 'Sofia | Peach | 2', 'New York | Sample Product | 1000.1', 'New York | Burger | 10']);
lowestPricesInCities(['Sample Town | Orange | 2', 'Sofia | Orange | 2']);