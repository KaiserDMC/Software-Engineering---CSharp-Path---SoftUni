function arraySort(elements) {
    elements.sort((a, b) => a.localeCompare(b)).forEach((el, index) => console.log(`${index + 1}.${el}`))
}

arraySort(["John", "Bob", "Christina", "Ema"]);