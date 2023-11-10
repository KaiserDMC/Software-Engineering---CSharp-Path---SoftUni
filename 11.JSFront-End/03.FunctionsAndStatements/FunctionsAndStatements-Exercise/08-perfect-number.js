function perfectNumber(number) {
    let isPerfect = false;
    const isNumberEven = () => number % 2 === 0;

    if (isNumberEven()) {
        let dec2bin = () => {
            return (number >>> 0).toString(2);
        }

        const onesCount = dec2bin().toString().split('1').length - 1;
        const zerosCount = dec2bin().toString().split('0').length - 1;

        isPerfect = onesCount === zerosCount + 1;
    } // Odd Perfect numbers do no exist!

    if (isPerfect) {
        console.log(`We have a perfect number!`);
    } else {
        console.log(`It's not so perfect.`);
    }
}

perfectNumber(6);
perfectNumber(28);
perfectNumber(1236498);