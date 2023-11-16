function addressBook(inputArr) {
    let finalAddress = {};

    for (const element of inputArr) {
        let [name, address] = element.split(":");
        finalAddress[name] = address;
    }

    for (const [key, value] of Object.entries(finalAddress).sort((a, b) => a[0].localeCompare(b[0]))) {
        console.log(`${key} -> ${value}`);
    }
}

addressBook(['Tim:Doe Crossing', 'Bill:Nelson Place', 'Peter:Carlyle Ave', 'Bill:Ornery Rd']);
addressBook(['Bob:Huxley Rd', 'John:Milwaukee Crossing', 'Peter:Fordem Ave', 'Bob:Redwing Ave', 'George:Mesta Crossing', 'Ted:Gateway Way', 'Bill:Gateway Way',
    'John:Grover Rd', 'Peter:Huxley Rd', 'Jeff:Gateway Way', 'Jeff:Huxley Rd']);