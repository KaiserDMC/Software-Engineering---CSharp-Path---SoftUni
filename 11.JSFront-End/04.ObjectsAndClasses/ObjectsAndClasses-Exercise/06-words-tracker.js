function wordsTracker(inputArr) {
    let wordsToCheck = inputArr[0].split(" ");
    let wordTrack = {};

    for (const word of wordsToCheck) {
        wordTrack[word] = {counter: 0};
    }

    inputArr.shift();

    for (const word of inputArr) {
        if (wordTrack.hasOwnProperty(word)) {
            wordTrack[word].counter += 1;
        }
    }

    const sortedWords = Object.keys(wordTrack).sort((a, b) => wordTrack[b].counter - wordTrack[a].counter);

    for (const word of sortedWords) {
        console.log(`${word} - ${wordTrack[word].counter}`);
    }
}

wordsTracker(['this sentence', 'In', 'this', 'sentence', 'you', 'have', 'to', 'count', 'the', 'occurrences', 'of', 'the', 'words', 'this', 'and', 'sentence', 'because', 'this', 'is', 'your', 'task']);
wordsTracker(['is the', 'first', 'sentence', 'Here', 'is', 'another', 'the', 'And', 'finally', 'the', 'the', 'sentence']);