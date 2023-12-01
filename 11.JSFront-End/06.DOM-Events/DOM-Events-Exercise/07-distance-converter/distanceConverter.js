function attachEventsListeners() {
    const [inputField, convertBtn, outputField] = document.getElementsByTagName("input");
    const [selectedUnit, outputUnit] =  document.getElementsByTagName("select");

    const conversionTable = {
        km: 1000,
        m: 1,
        cm: 0.01,
        mm: 0.001,
        mi: 1609.34,
        yrd: 0.9144,
        ft: 0.3048,
        in: 0.0254,
    };

    convertBtn.addEventListener("click", () => {
        const inputDistance = inputField.value;
        const selectedUnits = selectedUnit.value;
        const outputUnits = outputUnit.value;
        
        const result = inputDistance * conversionTable[selectedUnits] / conversionTable[outputUnits];
        outputField.value = result;
    });
}