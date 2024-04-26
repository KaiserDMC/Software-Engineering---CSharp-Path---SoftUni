type TownPrice = {
    [townName: string]: number
}

type ResultT = {
    [key: string]: TownPrice
}

function solve(input: string[]) {
    const result: ResultT = {};
    
    for (let i = 0; i < input.length; i++) {
        let [town, product, price] = input[i].split(' | ');
        const convertedPrice = Number(price);

        if (!result[product]) {
           result[product] = {};
        }

        if (!result[product][town]) {
            result[product][town] = convertedPrice;
        } else {
            if (result[product][town] > convertedPrice) {
                result[product][town] = convertedPrice;
            }
        }
    }

    const products = Object.entries(result);
    
    for (const [product, towns] of products) {
        const sortedTowns = Object.entries(towns).sort((a, b) => a[1] - b[1]);
        console.log(`${product} -> ${sortedTowns[0][1]} (${sortedTowns[0][0]})`);
    }
}

solve(['Sample Town | Sample Product | 1000', 'Sample Town | Orange | 2', 'Sample Town | Peach | 1', 'Sofia | Orange | 3', 'Sofia | Peach | 2', 'New York | Sample Product | 1000.1', 'New York | Burger | 10']);
solve(['Sample Town | Orange | 2', 'Sofia | Orange | 2']);