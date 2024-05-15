function occurrences(str, word) {
    let counter = 0;
    const words = str.split(" ");
    
    words.forEach(currentWord => {
        if (currentWord === word) {
            counter++;
        }
    });

    console.log(counter);
}

occurrences('This is a word and it also is a sentence', 'is');
occurrences('softuni is great place for learning new programming languages', 'softuni');