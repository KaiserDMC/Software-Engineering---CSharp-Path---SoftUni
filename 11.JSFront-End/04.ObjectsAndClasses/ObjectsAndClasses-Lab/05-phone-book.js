function phonebook(inputArr) {
    let finalPhonebook = {};

    for (const element of inputArr) {
        let entry = element.split(" ");
        const name = entry[0];
        const phone = entry[1];

        finalPhonebook[name] = phone;
    }

    for (const finalPhonebookKey in finalPhonebook) {
        console.log(`${finalPhonebookKey} -> ${finalPhonebook[finalPhonebookKey]}`);
    }
}

phonebook(['Tim 0834212554', 'Peter 0877547887', 'Bill 0896543112', 'Tim 0876566344']);
phonebook(['George 0552554', 'Peter 087587', 'George 0453112', 'Bill 0845344']);