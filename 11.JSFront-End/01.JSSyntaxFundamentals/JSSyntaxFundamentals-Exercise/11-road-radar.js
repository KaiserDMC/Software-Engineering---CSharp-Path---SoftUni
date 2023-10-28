function RoadRadar(speed, area){
    let speedLimit = 0;
    
    switch (area){
        case 'motorway':
            speedLimit = 130;
            break;
        case 'interstate':
            speedLimit = 90;
            break;
        case 'city':
            speedLimit = 50;
            break;
        case 'residential':
            speedLimit = 20;
            break;
    }
    let overSpeed = speed - speedLimit;    
    
    if (overSpeed <= 0){
        console.log(`Driving ${speed} km/h in a ${speedLimit} zone`);
    }
    else if (overSpeed <= 20){
        console.log(`The speed is ${overSpeed} km/h faster than the allowed speed of ${speedLimit} - speeding`);
    }
    else if (overSpeed <= 40){
        console.log(`The speed is ${overSpeed} km/h faster than the allowed speed of ${speedLimit} - excessive speeding`);
    }
    else {
        console.log(`The speed is ${overSpeed} km/h faster than the allowed speed of ${speedLimit} - reckless driving`);
    }
}

RoadRadar(40, 'city'); // Driving 40 km/h in a 50 zone
RoadRadar(21, 'residential'); // The speed is 1 km/h faster than the allowed speed of 20 - speeding