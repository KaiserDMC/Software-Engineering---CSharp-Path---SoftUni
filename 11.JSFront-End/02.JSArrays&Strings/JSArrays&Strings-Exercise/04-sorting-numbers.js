function sortingNumbers(elements) {
    elements.sort((a, b) => a - b);
    const resultArray = [];

    let left = 0;
    let right = elements.length - 1;

    while (left <= right) {
        if (left !== right) {
            resultArray.push(elements[left]); 
            resultArray.push(elements[right]); 
        } else {
            resultArray.push(elements[left]);
        }
        left++;
        right--;
    }

    return resultArray;
}

sortingNumbers([1, 65, 3, 52, 48, 63, 31, -3, 18, 56]);