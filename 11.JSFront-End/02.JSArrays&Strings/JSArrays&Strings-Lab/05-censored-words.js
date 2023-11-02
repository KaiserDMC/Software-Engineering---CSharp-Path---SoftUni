function Censored(str, word) {
   while (str.includes(word)){
       str = str.replace(word, "*".repeat(word.length))
   }

    console.log(str);
}

Censored('A small sentence with some words', 'small');
Censored('Find the hidden word', 'hidden');
