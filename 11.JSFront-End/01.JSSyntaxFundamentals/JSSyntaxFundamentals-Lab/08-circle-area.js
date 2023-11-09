function circleArea(radius) {

    if (typeof radius !== 'number') {
        console.log(`We can not calculate the circle area, because we receive a ${typeof radius}.`);
        return;
    }

    console.log(`${(Math.PI * radius * radius).toFixed(2)}`);
}

circleArea(5); // 78.54
circleArea('name'); // Error: We can not calculate the circle area, because we receive a string.