function Login(inputs) {
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

Login(['Acer', 'login', 'go', 'let me in', 'recA']);
Login(['momo', 'omom']);
Login(['sunny', 'rainy', 'cloudy', 'sunny', 'not sunny']);