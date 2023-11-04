function PyramidKingDjoser(base, increment) {
    let stone = 0;
    let marble = 0;
    let lapis = 0;
    let gold = 0;
    let step = 0;


    for (let i = base; i >= 1; i -= 2) {
        step++;

        if (i - 2 <= 0) {
            gold = i ** 2 * increment;
            break;
        }

        stone += (i - 2) ** 2 * increment;

        if (step % 5 === 0) {
            lapis += (i ** 2 - (i - 2) ** 2) * increment;
        } else {
            marble += (i ** 2 - (i - 2) ** 2) * increment;
        }
    }

    console.log(`Stone required: ${Math.ceil(stone)}`);
    console.log(`Marble required: ${Math.ceil(marble)}`);
    console.log(`Lapis Lazuli required: ${Math.ceil(lapis)}`);
    console.log(`Gold required: ${Math.ceil(gold)}`);
    console.log(`Final pyramid height: ${Math.floor(step * increment)}`);
}

PyramidKingDjoser(11, 1);
PyramidKingDjoser(11, 0.75);
PyramidKingDjoser(12, 1);
PyramidKingDjoser(23, 0.5);