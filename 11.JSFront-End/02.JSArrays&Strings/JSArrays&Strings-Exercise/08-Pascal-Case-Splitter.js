function pascalSplitter(sentence) {
   const words = sentence.split(/(?=[A-Z])/).join(", ");
   
   console.log(words);
}

pascalSplitter('SplitMeIfYouCanHaHaYouCantOrYouCan');
pascalSplitter('HoldTheDoor');
pascalSplitter('ThisIsSoAnnoyingToDo');