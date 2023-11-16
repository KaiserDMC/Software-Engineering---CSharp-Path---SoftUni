function piccolo(inputArr) {
    let parkingLot = {};

    for (const inputArrElement of inputArr) {
        let [direction, carNumber] = inputArrElement.split(", ");

        if (direction === "IN") {
            parkingLot[carNumber] = carNumber
        } else {
            parkingLot[carNumber] = null;
        }
    }

    if (Object.values(parkingLot).every(value => value === null)) {
        console.log(`Parking lot is Empty`);
        return;
    }

    const sortedCarNumbers = Object.keys(parkingLot).sort();

    for (const carNumber of sortedCarNumbers) {
        if (parkingLot[carNumber] !== null)
            console.log(carNumber);
    }
}

piccolo(['IN, CA2844AA', 'IN, CA1234TA', 'OUT, CA2844AA', 'IN, CA9999TT', 'IN, CA2866HI', 'OUT, CA1234TA', 'IN, CA2844AA', 'OUT, CA2866HI', 'IN, CA9876HH', 'IN, CA2822UU']);
piccolo(['IN, CA2844AA', 'IN, CA1234TA', 'OUT, CA2844AA', 'OUT, CA1234TA']);