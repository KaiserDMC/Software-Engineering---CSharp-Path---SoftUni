function Rotation(elements, rotations) {

    for (let i = 0; i < rotations; i++) {
        elements.push(elements.shift());
    }
    
    console.log(elements.join(" "))
}

Rotation([51, 47, 32, 61, 21], 2);
Rotation([32, 21, 61, 1], 4);
Rotation([2, 4, 15, 31], 5);
