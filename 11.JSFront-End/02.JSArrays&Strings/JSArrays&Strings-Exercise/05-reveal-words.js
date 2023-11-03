function Reveal(words, sentence) {
    words = words.split(', ');

    for (const word of words) {
        sentence = sentence.split(" ").map((s) => {
            if (s.length === word.length && s === "*".repeat(s.length)) {
                return word;
            } else {
                return s;
            }
        }).join(" ");
    }

    console.log(sentence);
}

Reveal('great', 'softuni is ***** place for learning new programming languages');
Reveal('great, learning', 'softuni is ***** place for ******** new programming languages');
