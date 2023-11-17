function sequencing(input) {
    let finalCollection = [];

    for (const inputElement of input) {
        let sortedArray = JSON.parse(inputElement).sort((a, b) => b - a);

        if (!finalCollection.some(arr => JSON.stringify(arr) === JSON.stringify(sortedArray))) {
            finalCollection.push(sortedArray);
        }
    }

    finalCollection.sort((a, b) => a.length - b.length);
    
    console.log(finalCollection.map(array => `[${array.join(", ")}]`).join("\n"));
}

sequencing(["[-3, -2, -1, 0, 1, 2, 3, 4]", "[10, 1, -17, 0, 2, 13]", "[4, -3, 3, -2, 2, -1, 1, 0]"]);
sequencing(["[7.14, 7.180, 7.339, 80.099]", "[7.339, 80.0990, 7.140000, 7.18]", "[7.339, 7.180, 7.14, 80.099]"]);