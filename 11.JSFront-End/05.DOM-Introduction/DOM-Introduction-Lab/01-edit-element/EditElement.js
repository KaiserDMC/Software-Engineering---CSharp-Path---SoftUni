function editElement(element, matchingParam, replacer) {
    const elementToEdit = element;
    const match = new RegExp(matchingParam, 'g');
    element.textContent = elementToEdit.textContent.replace(match, replacer);
}