function ArraySort(elements) {
    elements.sort((a, b) => a.localeCompare(b)).forEach((el, index) => console.log(`${index + 1}.${el}`))
}

ArraySort(["John", "Bob", "Christina", "Ema"]);