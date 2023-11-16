function convertToObject(jsonString) {
    let person = JSON.parse(jsonString);

    for (const [key, value] of Object.entries(person)) {
        console.log(`${key}: ${value}`);
    }
}

convertToObject('{"name": "George", "age": 40, "town": "Sofia"}');
convertToObject('{"name": "Peter", "age": 35, "town": "Plovdiv"}');