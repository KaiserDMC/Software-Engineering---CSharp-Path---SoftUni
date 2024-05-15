function printDna(length) {
    let symbols = ["A", "T", "C", "G", "T", "T", "A", "G", "G", "G"];

    for (let i = 1; i <= length; i++) {
        const symbolOne = symbols.shift();
        const symbolTwo = symbols.shift();

        if (i % 4 === 1) {
            console.log(`**${symbolOne}${symbolTwo}**`);
        } else if (i % 2 === 0) {
            console.log(`*${symbolOne}--${symbolTwo}*`);
        } else {
            console.log(`${symbolOne}----${symbolTwo}`);
        }

        symbols.push(symbolOne, symbolTwo);
    }
}

printDna(4);
printDna(10);