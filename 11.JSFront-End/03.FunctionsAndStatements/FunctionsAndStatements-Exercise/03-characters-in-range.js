function charsInRange(charOne, charTwo) {
    const intCharOne = charOne.charCodeAt(0);
    const intCharTwo = charTwo.charCodeAt(0);
    let result = "";

    for (let i = Math.min(intCharOne, intCharTwo) + 1; i < Math.max(intCharOne, intCharTwo); i++) {
        result += `${String.fromCharCode(i)} `;
    }

    console.log(result);
}

charsInRange('a', 'd');
charsInRange('#', ':');
charsInRange('C', '#');