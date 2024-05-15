function hashTag(sentence) {
    const words = sentence.split(" ").filter((s) => {
        return s.startsWith("#") && !/\d/.test(s.slice(1)) && s.length > 1;
    }).map((s) => s.slice(1)).join("\n");

    console.log(words);
}

hashTag('Nowadays everyone uses # to tag a #special word in #socialMedia');
hashTag('The symbol # is known #variously in English-speaking #regions as the #number sign');