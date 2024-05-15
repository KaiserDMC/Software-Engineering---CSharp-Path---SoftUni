function passwordValidator(password) {
    let results = {};
    let validLength = () => password.length >= 6 && password.length <= 10;

    let validSyntax = () => /^[a-zA-Z0-9]+$/.test(password);

    let countDigits = () => {
        let digitCount = 0;

        for (let i = 0; i < password.length; i++) {
            if (/\d/.test(password[i])) {
                digitCount++;
            }
        }

        return digitCount;
    }

    const validPassword = validLength() && validSyntax() && countDigits() >= 2;
    results.messages = [];

    if (validPassword) {
        results.messages.push("Password is valid");
    }
    
    if (!validLength()) {
        results.messages.push("Password must be between 6 and 10 characters");
    }

    if (!validSyntax()) {
        results.messages.push("Password must consist only of letters and digits");
    }

    if (countDigits() < 2) {
        results.messages.push("Password must have at least 2 digits");
    }

    results.errorMessage = results.messages.join("\n")

    console.log(results.errorMessage);
}

passwordValidator('logIn');
passwordValidator('MyPass123');
passwordValidator('Pa$s$s');