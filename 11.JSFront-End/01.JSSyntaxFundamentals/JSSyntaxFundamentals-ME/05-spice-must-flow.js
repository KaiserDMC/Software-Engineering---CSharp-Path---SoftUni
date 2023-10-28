function SpiceMustFlow(startingYield){
    let totalAmount = 0;
    let days = 0;
    
    while(startingYield >= 100){
        totalAmount += startingYield - 26;
        startingYield -= 10;
        days++;
    }
    
    if(totalAmount >= 26){
        totalAmount -= 26;
    }
    
    console.log(days);
    console.log(totalAmount);
}

SpiceMustFlow(111); // 2, 134
SpiceMustFlow(450); // 36, 8938