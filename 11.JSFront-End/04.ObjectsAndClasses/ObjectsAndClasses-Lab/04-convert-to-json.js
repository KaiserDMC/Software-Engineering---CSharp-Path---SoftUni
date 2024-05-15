function convertToJson(firstName, lastName, hairColor) {
    const person = {
        name: firstName,
        lastName,
        hairColor
    }

    console.log(JSON.stringify(person));
}

convertToJson('George', 'Jones', 'Brown');
convertToJson('Peter', 'Smith', 'Blond');