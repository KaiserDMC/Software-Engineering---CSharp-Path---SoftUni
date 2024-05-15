function censored(str, word) {
   while (str.includes(word)){
       str = str.replace(word, "*".repeat(word.length))
   }

    console.log(str);
}

censored('A small sentence with some words', 'small');
censored('Find the hidden word', 'hidden');