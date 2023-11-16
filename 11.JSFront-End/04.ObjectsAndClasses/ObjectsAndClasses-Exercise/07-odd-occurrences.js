function oddOccurrences(inputString) {
    let words = {};
    let output = [];

    for (const inputStr of inputString.split(" ")) {
        let lowerCaseStr = inputStr.toLowerCase();

        if (words.hasOwnProperty(lowerCaseStr)) {
            words[lowerCaseStr].counter++;
        } else {
            words[lowerCaseStr] = {counter: 0};
        }
    }

    for (const word in words) {
        if (words[word].counter % 2 === 0) {
            output.push(word.toString());
        }
    }

    console.log(output.join(" "));
}

oddOccurrences('Java C# Php PHP Java PhP 3 C# 3 1 5 C#');
oddOccurrences('Cake IS SWEET is Soft CAKE sweet Food');