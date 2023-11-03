function PascalSplitter(sentence) {
   const words = sentence.split(/(?=[A-Z])/).join(", ");
   
   console.log(words);
}

PascalSplitter('SplitMeIfYouCanHaHaYouCantOrYouCan');
PascalSplitter('HoldTheDoor');
PascalSplitter('ThisIsSoAnnoyingToDo');