function pointsValidation(coordinates) {
    const [x1, y1, x2, y2] = coordinates;
    const calculateDistance = (x1, y1, x2, y2) => Math.sqrt(Math.pow(x2 - x1, 2) + Math.pow(y2 - y1, 2));
    const isDistanceValid = (x1, y1, x2, y2) => Number.isInteger(calculateDistance(x1, y1, x2, y2));

    const printValidity = (pointA, pointB, isValid) => {
        const formatPoint = (x, y) => `{${x === 0 ? '0' : x}, ${y === 0 ? '0' : y}}`;

        console.log(`${formatPoint(pointA[0], pointA[1])} to ${formatPoint(pointB[0], pointB[1])} is ${isValid ? 'valid' : 'invalid'}`);
    };

    const points = [
        [x1, y1, '0, 0'],
        [x2, y2, '0, 0'],
        [x1, y1, x2, y2]
    ];

    printValidity(points[0], [0, 0], isDistanceValid(x1, y1, 0, 0));
    printValidity(points[1], [0, 0], isDistanceValid(x2, y2, 0, 0));
    printValidity(points[0], points[1], isDistanceValid(x1, y1, x2, y2));
}

pointsValidation([3, 0, 0, 4]);
pointsValidation([2, 1, 1, 1]);