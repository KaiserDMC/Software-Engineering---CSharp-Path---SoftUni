function solve() {
    const textToCassify = document.getElementById("text").value;
    const convention = document.getElementById("naming-convention").value;
    let textToDisplay;

    switch (convention) {
        case "Camel Case":
            textToDisplay = textToCassify.toLowerCase();
            textToDisplay = textToDisplay.split(" ").reduce((s, c) => s + (c.charAt(0).toUpperCase() + c.slice(1)));
            break;
        case "Pascal Case":
            textToDisplay = textToCassify.replace(/\w+/g,
                function toPascalCase(string) {
                    return `${string}`
                        .toLowerCase()
                        .replace(new RegExp(/[-_]+/, 'g'), ' ')
                        .replace(new RegExp(/[^\w\s]/, 'g'), '')
                        .replace(
                            new RegExp(/\s+(.)(\w*)/, 'g'),
                            ($1, $2, $3) => `${$2.toUpperCase() + $3}`
                        )
                        .replace(new RegExp(/\w/), s => s.toUpperCase());
                }).replace(/\s/g, "");
            break;
        default:
            textToDisplay = "Error!";
            break;
    }

    document.getElementById("result").textContent = textToDisplay;
}