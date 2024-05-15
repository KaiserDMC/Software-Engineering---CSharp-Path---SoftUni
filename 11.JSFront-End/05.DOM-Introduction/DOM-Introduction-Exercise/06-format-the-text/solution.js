function solve() {
    const textToFormat = document.getElementById("input").value;
    const arraysOfText = textToFormat.split(".");
    const outputField = document.getElementById("output");
    let output = [];

    while (arraysOfText.length > 0) {
        const currentText = arraysOfText.shift();

        if (currentText.length > 1) {
            output.push(currentText);
        }
    }

    if (output.length <= 3) {
        let paragraph = output.join(".") + ".";
        let paragraphElement = document.createElement("p");
        paragraphElement.innerText = paragraph;
        outputField.appendChild(paragraphElement);
    } else {
        for (let i = 0; i < output.length; i += 3) {
            const chunk = output.slice(i, i + 3);
            let paragraph = chunk.join(".") + ".";
            let paragraphElement = document.createElement("p");
            paragraphElement.innerText = paragraph;
            outputField.appendChild(paragraphElement);
        }
    }
}