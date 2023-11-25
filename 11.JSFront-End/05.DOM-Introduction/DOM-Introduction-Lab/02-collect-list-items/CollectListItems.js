function extractText() {
    const list = document.querySelectorAll("ul#items li");
    const textArea = document.querySelector("#result");

    for (const listElement of Array.from(list)) {
        textArea.value += listElement.textContent + "\n";
    }
}