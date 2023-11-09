function stringSubstring(word, sentence) {
    let found = false;

    sentence.split(" ").map((se) => {
        if (se.toLowerCase() === word) {
            console.log(word);
            found = true;
        }
    });

    if (!found) {
        console.log(`${word} not found!`);
    }
}

stringSubstring('javascript', 'JavaScript is the best programming language');
stringSubstring('python', 'JavaScript is the best programming language');