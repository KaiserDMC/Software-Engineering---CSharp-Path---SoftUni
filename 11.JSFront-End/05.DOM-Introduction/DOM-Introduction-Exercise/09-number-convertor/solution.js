function solve() {
    function decimalToBinary(decimalNumber) {
        return decimalNumber.toString(2);
    }

    function decimalToHexadecimal(decimalNumber) {
        return decimalNumber.toString(16);
    }

    function populateOptions() {
        const selection = document.getElementById("selectMenuTo");
        selection.innerHTML = "";

        // Add default empty option
        const defaultOption = document.createElement("option");
        defaultOption.value = "";
        selection.appendChild(defaultOption);

        // Add binary option
        const binaryOption = document.createElement("option");
        binaryOption.value = "binary";
        binaryOption.textContent = "Binary";
        selection.appendChild(binaryOption);

        // Add hexadecimal option
        const hexadecimalOption = document.createElement("option");
        hexadecimalOption.value = "hexadecimal";
        hexadecimalOption.textContent = "Hexadecimal";
        selection.appendChild(hexadecimalOption);
    }

    let button = document.getElementsByTagName("button")[0];
    populateOptions();

    button.addEventListener("click", () => {
        const numberToConvert = Number(document.getElementById("input").value);


        const optionToConvert = document.getElementById("selectMenuTo").value;
        let convertedNumber;

        switch (optionToConvert) {
            case "binary":
                convertedNumber = decimalToBinary(numberToConvert);
                break;
            case "hexadecimal":
                convertedNumber = decimalToHexadecimal(numberToConvert).toUpperCase();
                break;
        }

        document.getElementById("result").value = convertedNumber;
    })
}