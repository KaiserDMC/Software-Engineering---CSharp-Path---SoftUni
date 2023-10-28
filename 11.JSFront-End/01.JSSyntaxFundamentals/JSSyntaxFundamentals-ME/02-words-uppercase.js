function WordsUppercase(text) {
    let result = text.toUpperCase().match(/\w+/g); //Match all words in text, g - global
    console.log(result.join(', '));
}

WordsUppercase('Hi, how are you?'); // HI, HOW, ARE, YOU