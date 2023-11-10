function nMatrix(integer) {
    let result = [];
    for (let i = 0; i < integer; i++) {
        result.push(new Array(integer).fill(integer));
    }

    for (let i = 0; i < integer; i++) {
        console.log(result[i].join(' '));
    }
}

nMatrix(3);
nMatrix(7);
nMatrix(2);