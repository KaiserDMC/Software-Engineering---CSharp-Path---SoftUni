function CookingByNumbers(number, ...operations) {
    let result = number;

    for (let i = 0; i < operations.length; i++) {
        switch (operations[i]) {
            case 'chop':
                result /= 2;
                break;
            case 'dice':
                result = Math.sqrt(result);
                break;
            case 'spice':
                result += 1;
                break;
            case 'bake':
                result *= 3;
                break;
            case 'fillet':
                result *= 0.8;
                break;
        }
        console.log(result);
    }
}

CookingByNumbers('32', 'chop', 'chop', 'chop', 'chop', 'chop'); // 16 8 4 2 1
CookingByNumbers('9', 'dice', 'spice', 'chop', 'bake', 'fillet'); // 3 4 2 6 4.8