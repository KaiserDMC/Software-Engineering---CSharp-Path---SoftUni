function StringSubstring(word, sentence) {
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

StringSubstring('javascript', 'JavaScript is the best programming language');
StringSubstring('python', 'JavaScript is the best programming language');