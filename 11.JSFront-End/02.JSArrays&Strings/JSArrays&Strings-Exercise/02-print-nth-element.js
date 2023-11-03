function PrintNthElement(elements, number) {
    return elements.map(function (element, index) {
        if (index % number === 0) {
            return element;
        }
        return null;
    }).filter(element => element !== null);
}

PrintNthElement(['5', '20', '31', '4', '20'], 2);