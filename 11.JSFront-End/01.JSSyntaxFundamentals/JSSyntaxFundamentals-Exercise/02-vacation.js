function vacation(numberOfPeople, typeOfVacation, day) {
    let totalPrice;
    let singlePrice = 0;

    switch (typeOfVacation) {
        case 'Students':
            if (day === 'Friday') {
                singlePrice = 8.45;
            } else if (day === 'Saturday') {
                singlePrice = 9.80;
            } else if (day === 'Sunday') {
                singlePrice = 10.46;
            }
            break;
        case 'Business':
            if (day === 'Friday') {
                singlePrice = 10.90;
            } else if (day === 'Saturday') {
                singlePrice = 15.60;
            } else if (day === 'Sunday') {
                singlePrice = 16;
            }
            break;
        case 'Regular':
            if (day === 'Friday') {
                singlePrice = 15;
            } else if (day === 'Saturday') {
                singlePrice = 20;
            } else if (day === 'Sunday') {
                singlePrice = 22.50;
            }
            break;
    }

    totalPrice = singlePrice * numberOfPeople;

    if (numberOfPeople >= 30 && typeOfVacation === 'Students') {
        totalPrice -= totalPrice * 0.15;
    } else if (numberOfPeople >= 100 && typeOfVacation === 'Business') {
        totalPrice -= singlePrice * 10;
    } else if (numberOfPeople >= 10 && numberOfPeople <= 20 && typeOfVacation === 'Regular') {
        totalPrice -= totalPrice * 0.05;
    }

    console.log(`Total price: ${totalPrice.toFixed(2)}`);
}

vacation(30, "Students", "Sunday"); // Total price: 266.73
vacation(40, "Regular", "Saturday"); // Total price: 800.00