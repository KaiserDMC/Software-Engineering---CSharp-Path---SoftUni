function Mining(inputs) {
    let bitcoinPrice = 11949.16;
    let exchangeRatePerGram = 67.51;
    let totalMoney = 0;
    let bitcoinCounter = 0;
    let day = 0;
    let firstDay = 0;

    while (inputs.length > 0) {
        day++;
        let dailyMoney = exchangeRatePerGram * inputs.shift();

        if (day % 3 === 0) {
            totalMoney += dailyMoney * 0.7;
        } else {
            totalMoney += dailyMoney;
        }

        while (totalMoney >= bitcoinPrice) {
            totalMoney -= bitcoinPrice;
            bitcoinCounter++;

            if (bitcoinCounter === 1) {
                firstDay = day;
            }
        }
    }

    console.log(`Bought bitcoins: ${bitcoinCounter}`);
    if (firstDay > 0) {
        console.log(`Day of the first purchased bitcoin: ${firstDay}`);
    }
    console.log(`Left money: ${totalMoney.toFixed(2)} lv.`);
}

Mining([100, 200, 300]);
Mining([50, 100]);
Mining([3124.15, 504.212, 2511.124]);