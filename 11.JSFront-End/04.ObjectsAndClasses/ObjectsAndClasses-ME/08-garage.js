function garage(inputArr) {
    let parking = {};

    for (const element of inputArr) {
        let [parkingNumber, ...rest] = element.split(" - ");

        if (!parking.hasOwnProperty(parkingNumber)) {
            parking[parkingNumber] = [];
        }

        let car = {};
        for (const KeyValue of rest.join().split(", ")) {
            let [key, value] = KeyValue.split(": ");

            car[key] = value;
        }

        parking[parkingNumber].push(car);
    }

    for (const parkingSpot of Object.keys(parking).sort()) {
        console.log(`Garage № ${parkingSpot}`);

        parking[parkingSpot].forEach(car => {
            let keyValue = [];
            for (const [key, value] of Object.entries(car)) {
                keyValue.push(`${key} - ${value}`);
            }
            console.log("--- " + keyValue.join(", "));
        })
    }
}

garage(['1 - color: blue, fuel type: diesel', '1 - color: red, manufacture: Audi', '2 - fuel type: petrol', '4 - color: dark blue, fuel type: diesel, manufacture: Fiat']);
garage(['1 - color: green, fuel type: petrol', '1 - color: dark red, manufacture: WV', '2 - fuel type: diesel', '3 - color: dark blue, fuel type: petrol']);