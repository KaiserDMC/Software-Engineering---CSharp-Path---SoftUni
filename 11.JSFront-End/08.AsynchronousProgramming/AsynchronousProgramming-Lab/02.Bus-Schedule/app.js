function solve() {
    const informationField = document.getElementById("info");
    const baseUrl = "http://localhost:3030/jsonstore/bus/schedule";
    const departureBtn = document.getElementById("depart");
    const arrivalBtn = document.getElementById("arrive");

    let nextStop = "depot";
    let nextName = "Depot";

    async function depart() {
        try {
            let response = await fetch(`${baseUrl}/${nextStop}`);
            let data = await response.json();
            informationField.textContent = `Next stop ${data.name}`;
            nextStop = data.next;
            nextName = data.name;

            departureBtn.disabled = true;
            arrivalBtn.disabled = false;
        } catch {
            departureBtn.disabled = true;
            informationField.textContent = "Error";
        }
    }

    function arrive() {
        informationField.textContent = `Arriving at ${nextName}`;

        departureBtn.disabled = false;
        arrivalBtn.disabled = true;
    }

    return {
        depart,
        arrive
    };
}

let result = solve();