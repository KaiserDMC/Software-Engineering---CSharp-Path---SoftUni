function wordsUppercase(text) {
    let result = text.toUpperCase().match(/\w+/g); //Match all words in text, g - global
    console.log(result.join(', '));
}

wordsUppercase('Hi, how are you?'); // HI, HOW, ARE, YOU