function flightScheduler(inputArr) {
    let [firstArr, secondArr, thirdArr] = inputArr;
    let flights = {};

    for (const flight of firstArr) {
        let [fltNumber, ...rest] = flight.split(" ");
        let destination = rest.join(" ");

        flights[fltNumber] = {
            Destination: destination,
            Status: "Ready to fly"
        }
    }

    for (const flight of secondArr) {
        let [fltNumber, ...rest] = flight.split(" ");

        if (flights.hasOwnProperty(fltNumber)) {
            flights[fltNumber].Status = rest.join(" ");
        }
    }

    for (const fltNumber of Object.keys(flights)) {
        let flight = flights[fltNumber];

        if (flight.Status === thirdArr[0]) {
            console.log(flight);
        }
    }

}

flightScheduler([['WN269 Delaware', 'FL2269 Oregon', 'WN498 Las Vegas', 'WN3145 Ohio', 'WN612 Alabama', 'WN4010 New York', 'WN1173 California', 'DL2120 Texas', 'KL5744 Illinois', 'WN678 Pennsylvania'], ['DL2120 Cancelled', 'WN612 Cancelled', 'WN1173 Cancelled', 'SK430 Cancelled'], ['Cancelled']]);
flightScheduler([['WN269 Delaware', 'FL2269 Oregon', 'WN498 Las Vegas', 'WN3145 Ohio', 'WN612 Alabama', 'WN4010 New York', 'WN1173 California', 'DL2120 Texas', 'KL5744 Illinois', 'WN678 Pennsylvania'], ['DL2120 Cancelled', 'WN612 Cancelled', 'WN1173 Cancelled', 'SK330 Cancelled'], ['Ready to fly']]);