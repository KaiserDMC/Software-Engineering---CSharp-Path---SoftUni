type OperationDictionary = {
    [key: string]: string
}

function calculator(a: number, op: string, b: number): void | Error {
    const mapOfOperations: OperationDictionary = {
        '+': (a + b).toFixed(2),
        '-': (a - b).toFixed(2),
        '*': (a * b).toFixed(2),
        '/': (a / b).toFixed(2)
    }

    if (mapOfOperations[op] === undefined) {
        throw new Error('Invalid operation')
    }

    console.log(mapOfOperations[op])
}

calculator(5, '+', 10) // 15.00
calculator(25.5, '-', 3) // 22.50
calculator(9, '*', 2) // 4.50
calculator(7, '/', 5) // 35.00
calculator(7, '**', 5) // 35.00