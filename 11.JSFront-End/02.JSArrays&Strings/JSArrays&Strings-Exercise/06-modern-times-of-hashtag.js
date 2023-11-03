function HashTag(sentence) {
    const words = sentence.split(" ").filter((s) => {
        return s.startsWith("#") && !/\d/.test(s.slice(1)) && s.length > 1;
    }).map((s) => s.slice(1)).join("\n");

    console.log(words);
}

HashTag('Nowadays everyone uses # to tag a #special word in #socialMedia');
HashTag('The symbol # is known #variously in English-speaking #regions as the #number sign');
