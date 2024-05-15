function colorize() {
    const arrayOfElements = document.querySelectorAll("table tr");

    for (let i = 1; i < arrayOfElements.length; i++) {
        if (i % 2 !== 0) {
            arrayOfElements[i].style.background = "teal";
        }
    }
}