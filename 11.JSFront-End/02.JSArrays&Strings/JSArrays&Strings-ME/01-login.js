function login(inputs) {
    let username = inputs.shift();
    let password = username.split("").reverse().join("");
    let incorrectCounter = 0;

    for (const input of inputs) {
        if (password === input) {
            console.log(`User ${username} logged in.`);
            break;
        } else {
            incorrectCounter++;
            if (incorrectCounter > 3) {
                console.log(`User ${username} blocked!`);
                break;
            } else {
                console.log(`Incorrect password. Try again.`);
            }
        }
    }
}

login(['Acer', 'login', 'go', 'let me in', 'recA']);
login(['momo', 'omom']);
login(['sunny', 'rainy', 'cloudy', 'sunny', 'not sunny']);