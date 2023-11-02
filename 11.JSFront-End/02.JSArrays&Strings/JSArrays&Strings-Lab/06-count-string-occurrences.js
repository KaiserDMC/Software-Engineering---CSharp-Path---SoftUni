function Occurrences(str, word) {
    let counter = 0;
    const words = str.split(" ");
    
    words.forEach(currentWord => {
        if (currentWord === word) {
            counter++;
        }
    });

    console.log(counter);
}

Occurrences('This is a word and it also is a sentence', 'is');
Occurrences('softuni is great place for learning new programming languages', 'softuni');
