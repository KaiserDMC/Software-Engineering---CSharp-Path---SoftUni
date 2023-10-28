function CircleArea(radius) {

    if (typeof radius !== 'number') {
        console.log(`We can not calculate the circle area, because we receive a ${typeof radius}.`);
        return;
    }

    console.log(`${(Math.PI * radius * radius).toFixed(2)}`);
}

CircleArea(5); // 78.54
CircleArea('name'); // Error: We can not calculate the circle area, because we receive a string.