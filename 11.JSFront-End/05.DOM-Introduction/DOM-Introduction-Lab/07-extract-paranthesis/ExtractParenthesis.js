function extract(content) {
    const paragraphAsString = document.getElementById(content).textContent;
    const matchReg = /\(([^)]+)\)/g;
    let resultArray = [];

    let match = matchReg.exec(paragraphAsString);
    while (match) {
        resultArray.push(match[1]);
        match = matchReg.exec(paragraphAsString);
    }

    console.log(resultArray.join("; "))
    return resultArray.join("; ");
}